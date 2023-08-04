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

        private List<string> CheckUserCreate(Dictionary<string, object> body) {
            List<string> errors = new List<string>();
            Dictionary<string, object> userCheck = bdMySqlService.GetDictionarySql(AuthConfigBd.UserCheck(), body);
            if ((bool)userCheck["check_login_"] == true)
            {
                errors.Add(ErrorText.UserLoginUnique());
            }

            if ((bool)userCheck["check_email_"] == true)
            {
                errors.Add(ErrorText.UserEmailUnique());
            }

            if ((bool)userCheck["check_nik_"] == true)
            {
                errors.Add(ErrorText.UserNikUnique());
            }
            return errors;
        }
        
        private List<string> CheckUserGet(DateTime dateToken, Boolean checkActive, Boolean CheckConfEmail, int userId) 
        {
            List<string> errors = new List<string>();
            if(userId > 0)
            {
                errors.Add(ErrorText.TokenNotValid());
            }
            if (checkActive)
            {
                errors.Add(ErrorText.UserNotActive());
            }
            if (CheckConfEmail)
            {
                errors.Add(ErrorText.UserNotConfEmail());
            }
            if (dateToken < DateTime.Now)
            {
                errors.Add(ErrorText.TokenTimeNoValid());
            }
            return errors;
        }

        public void Register(string login, string password, string nik, string email) {
            // подготовка данных;
            Dictionary<string, object> body = new Dictionary<string, object>() 
            {
                { "login", login},
                { "email", email },
                { "nik", nik }
                
            };
            // проверка валидации при регистрации
            List<string> errors = CheckUserCreate(body);
            if (errors.Count != 0)
            {
                Console.WriteLine(errors);
                return;
            }
            // функционал создания пользователя
            body["password"] = HashPassword(password);
            Dictionary<string, object> userCreate = bdMySqlService.GetDictionarySql(AuthConfigBd.UserCreate(), body);
            int id_user = (int)userCreate["id"];
            // функционал создания токена  
            string token = GenerateToken(id_user);
            Dictionary<string, object> bodyToken = new Dictionary<string, object>
            {
                { "value", token },
                { "id_user", id_user }
            };
            Dictionary<string, object> tokenCreate = bdMySqlService.GetDictionarySql(AuthConfigBd.TokenCreate(), bodyToken);

            Dictionary<string, object> userGetWhereTokenId = bdMySqlService.GetDictionarySql(AuthConfigBd.UserGetWhereTokenId(), tokenCreate);
            List<string> errorsUser =  CheckUserGet(
                (DateTime)userGetWhereTokenId["token_date"],
                (bool)userGetWhereTokenId["check_active"],
                (bool)userGetWhereTokenId["check_conf_email"], 
                (int)userGetWhereTokenId["id"]
                );
            if (errorsUser.Count != 0)
            {
                Console.WriteLine(errorsUser);
                return;
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
