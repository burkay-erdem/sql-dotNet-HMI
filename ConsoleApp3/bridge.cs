using System;
namespace ConsoleApp3
{
    public class bridge
    {
        public static string servername { get; set; }
        public static string serverdbname { get; set; }
        public static string servertbname { get; set; }
        public static string serveruserpassword { get; set; }
        public static string serverusername { get; set; }
        public static string uid { get; set; }
        public static string value { get; set; }
        public static string boxno { get; set; }
        public static string boxid { get; set; }
        public static string status { get; set; }
        public static string sqlstatus { get; set; }
        public static string errormessage { get; set; }
        public static string databasename { get; set; }
        public static string boxid_bridge { get; set; }
        public static Boolean Connect { set; get; } = false;
        public static Boolean Userconnecterror { set; get; } = false;
        public static Boolean userconnect { set; get; } = false;
        public static Boolean datachanged { get; set; } = false;
        public static Boolean flinkonline { get; set; } = false;
        public static Boolean sqloffline { get; set; } = false;
    }
}
