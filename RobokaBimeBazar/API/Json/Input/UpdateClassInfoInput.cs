using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RobokaBimeBazar.API.Json.Input
{
    public class UpdateClassInfoInput
    {
        public string ChatId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Region { get; set; }

        public string SchoolName { get; set; }
    }

  
}