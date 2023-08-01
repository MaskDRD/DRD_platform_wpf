using platform.UtlMicroservices;
using System;
using System.Security.Cryptography;

namespace platform.AuthMicroservices.service
{
    sealed class AuthService: Singleton<AuthService>
    {
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
            Console.WriteLine(today.ToString());
            string token = today.ToString() + userId.ToString();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(token);
            byte[] hash = new SHA256CryptoServiceProvider().ComputeHash(data);
            return Convert.ToBase64String(hash);
        }

        public void register() { }
        public void authorization() { }
        public void authentication() { }
    }
}
