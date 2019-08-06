using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UGetADog.Models
{
    public class FullGiver
    {
        public Giver giver { get; set; }
        public User user { get; set; }
    }
}