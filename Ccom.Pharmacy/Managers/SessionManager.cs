using System;

namespace Ccom.Pharmacy.Managers
{
    public static class SessionManager
    {
        //private static SessionManager _instance;

        //public static SessionManager Instance()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new SessionManager();
        //    }
        //    return _instance;
        //}

        //public static void ReSet()
        //{
        //    _instance = null;
        //}

        public static Guid SessionId { get; set; }
    }
}
