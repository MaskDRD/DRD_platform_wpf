
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
            return "Емайл уже существует";
        }
        public static string UserNotActive()
        {
            return "Пользователь забанен";
        }
        public static string UserNotConfEmail()
        {
            return "Пользователь забанен";
        }
        public static string TokenNotValid()
        {
            return "Токен не валиден";
        }
        public static string TokenTimeNoValid()
        {
            return "Срок действия токена закончен";
        }
    }
}
