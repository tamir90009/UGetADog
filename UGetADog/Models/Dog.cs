using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UGetADog.Models
{
    public class Dog
    {
        public int DogID { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public string Race { get; set; }
        public bool Trained { get; set; }
        public bool Immune { get; set; }
        public bool Castrated { get; set; }
        public string Gender { get; set; }
        public Giver Owner { get; set; }
    }
}