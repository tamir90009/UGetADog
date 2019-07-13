using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UGetADog.Models
{
    public class UGetADogDBContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Giver> Givers { get; set; }
        public DbSet<Adopter> Adopters { get; set; }
        public DbSet<User> Users { get; set; }

   
    }
}