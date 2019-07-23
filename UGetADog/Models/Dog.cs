using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UGetADog.Models
{
    public class Dog
    {
        [key]
        public int DogID { get; set; }

        public int ID { get; set; }
        [ForeignKey("ID")]

        //useless - shachar recommand on removing 
        public virtual Giver CurrGiver{ get; set; }

        [Required(ErrorMessage = "Dog name is requried")]
        [Display(Name = "Dog Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "dog age is requried")]
        [Display(Name = "dog age")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public double ? Age { get; set; }

        [Required(ErrorMessage = "dog breed is requried")]
        [Display(Name = "dog breed")]
        public string Breed { get; set; }

    
        [Display(Name = "is dog trained")]
        public bool Trained { get; set; }

        [Display(Name = "is dog immune")]
        public bool Immune { get; set; }

        [Display(Name = "is dog Castrated")]
        public bool Castrated { get; set; }

        [DisplayFormat(NullDisplayText = "Not gender specified")]
        public string Gender { get; set; }

        
    }
}