using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UGetADog.Models
{
    public class Giver
    {
        [key]
        public int GiverID { get; set; }

        public int UID { get; set; }
        [ForeignKey("UID")]
        public virtual User UserID { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }

    
        public Double Rating { get; set; }

        public ICollection<Dog> Dogs{ get; set; }
    }
}