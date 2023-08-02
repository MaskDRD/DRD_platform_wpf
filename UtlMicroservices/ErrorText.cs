
using System.ComponentModel;

namespace platform.UtlMicroservices
{
    public class ErrorText
    {
        public static string UserNikUnique(string nik) {
            return "Ник" + nik + "уже существует";
        }

        public static string UserNikUnique()
        {
            return "Ник уже существует";
        }
        public static string UserLoginUnique()
        {
            return "Логин уже существует";
        }
        public static string UserEmailUnique()
        {
            return "емайл уже существует";
        }
    }
}
