using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RobokaBimeBazar.API.Json.Input
{
    public class UpdateClassStudentInfo
    {
        public string ChatId { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string NationalCode { get; set; }
    }
}