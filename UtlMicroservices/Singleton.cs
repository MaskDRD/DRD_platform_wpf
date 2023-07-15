namespace platform.UtlMicroservices
{
    /// <summary>
    /// Класс создающий паттерн Singleton (для service, и др. объектов который могут сущестововать в 1 экземпляре.
    /// </summary>
    public class Singleton<T> where T : new()
    {
        private static T _instance;
        /// <summary>
        ///  Объект для обращения к единому экземпляру класса.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }
    }
}
