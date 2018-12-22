using System.Configuration;

namespace RobokaBimeBazar.Utility
{
    public static class Variables
    {
        public static string GetValue(string key) => ConfigurationManager.AppSettings[key];

        public static string ConnectionString => ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public static string ReplyTimeout => GetValue("ReplyTimeout");
    }
}