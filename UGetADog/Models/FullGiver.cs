using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UGetADog.Models
{
    public class FullGiver
    {
        public Giver giver { get; set; }
        public User user { get; set; }
        /*public IEnumerable<Giver> giver { get; set; }
        public IEnumerable<User> user { get; set; }*/
    }
}