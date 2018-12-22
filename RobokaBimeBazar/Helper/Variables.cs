using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace RobokaBimeBazar.Helper
{
    public static class Variables
    {
        public static string GetValue(string key) => ConfigurationManager.AppSettings[key];

        public static string ConnectionString => ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public static double RateSeconds => double.Parse(GetValue("RateSeconds"));
        public static Dictionary<string,double> RatePerUrl => GetValue("RatePerUrl")?.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries).Select(part => part.Split('=')).ToDictionary(split => split[0].ToLower(), split => double.Parse(split[1]));
    }
}