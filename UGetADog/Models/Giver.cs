﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UGetADog.Models
{
    public class Giver
    {
        public int GiverID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Double Rating { get; set; }
    }
}