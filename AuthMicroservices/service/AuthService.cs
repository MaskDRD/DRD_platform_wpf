using platform.AuthMicroservices.config;
using platform.BdMicroservices.Cache;
using platform.BdMicroservices.service;
using platform.UtlMicroservices;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace platform.AuthMicroservices.service
{
    sealed class AuthService: Singleton<AuthService>
    {

       private readonly BdService bdMySqlService = BdConnectCache.Instance.connectBd["DefaultConnection"];
        private string HashPassword(string password)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hash = new SHA256CryptoServiceProvider().ComputeHash(data);
            return Convert.ToBase64String(hash);
        }
        private bool CheckPassword(string password, string password_check)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hash = new SHA256CryptoServiceProvider().ComputeHash(data);
            return Convert.ToBase64String(hash).Equals(password_check);
        }
        private string GenerateToken(int userId)
        {
            DateTime today = DateTime.Now;
            string token = today.ToString() + userId.ToString();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(token);
            byte[] hash = new SHA256CryptoServiceProvider().ComputeHash(data);
            return Convert.ToBase64String(hash);
        }

        public void Register(Dictionary<string, object> body) {
            Dictionary<string, object> userCheck = bdMySqlService.GetDictionarySql(AuthConfigBd.UserCheck(), body);
            List<string> errors = new List<string>();
            if ((Boolean)userCheck["check_login_"] == false)
            {
                errors.Add(ErrorText.UserLoginUnique());
            }

            if ((Boolean)userCheck["check_email_"] == false)
            {
                errors.Add(ErrorText.UserEmailUnique());
            }
                
            if ((Boolean)userCheck["check_nik_"] == false)
            {
                errors.Add(ErrorText.UserNikUnique());
            }

            if(errors.Count == 0)
            {
                Console.WriteLine(errors);
            }
            // 1. запрос к бд UserCheck 
            // 2. свободны ли значения уникальных полей.
            // 2.1 заняты и вывести ошибки.
            // 3 иначе запрос TokenCreate и UserCreate и UserGetWhereId
        }

        public void Authorization(string login, string password) {
            // 1. запрос (получить пользователя по login и password
            // 2. проверить если ли ошибки
            // 2.1 да вывести их и return
            // 3. иначе: запрос TokenCreate и UserGetWhereId 
        }

        public void Authentication() {
            // 1 запрос UserGetWhereTokenValue
            // 1.1 пользователя нет вывести ошибку.
            // 2 иначе проверить check_active, check_conf_email, token_date и вывести ошибки при необходимости
            // 3 все ок, продлить время жизни токена.
        }
    }
}
