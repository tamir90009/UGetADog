using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace UGetADog.Models
{

    public class ML
    {
        [Key]
        //created from comment table 
        public int ML_ID { get; set; }
        public int UserID { get; set; }
        public int DogID { get; set; }
        public Double Age { get; set; }
        public DogGender? Gender { get; set; }
        public String FirstName { get; set; }
        public String Breed { get; set; }

    }
}