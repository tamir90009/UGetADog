using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UGetADog.Models
{
    public enum DgGender
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "Female")]
        Female
    }

    public enum DogSize
    {
        [Display(Name = "Small")]
        Small,
        [Display(Name = "Medium")]
        Medium,
        [Display(Name = "Large")]
        Large

    }
    public class Dog
    {
        [key]
        public int DogID { get; set; }

        public int GID { get; set; }
        [ForeignKey("GID")]

        //useless - shachar recommand on removing 
        public virtual Giver CurrGiver { get; set; }

        [Required(ErrorMessage = "Dog name is requried")]
        [Display(Name = "Dog Name")]
        [RegularExpression(@"^(([A-za-zא-ת]+[\s]{1}[A-za-zא-ת]+)|([A-Za-zא-ת]+))$", ErrorMessage = "Please enter valid name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "dog age is requried")]
        [Display(Name = "dog age")]
        [Range(0, 120, ErrorMessage = "Please enter valid integer Number")]
        public double? Age { get; set; }

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
        public DogGender? Gender { get; set; }

        [DisplayFormat(NullDisplayText = "No Size specified")]
        public DogSize Size { get; set; }

        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Upload File")]
        

        public string File { get; set; }


    }
}