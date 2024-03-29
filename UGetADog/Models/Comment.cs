﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UGetADog.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int? GiverID { get; set; }


        [ForeignKey("GiverID")]
        public virtual Giver Giver { get; set; }

        [Required(ErrorMessage = "your name is requried")]
        [Display(Name = "Sender Name")]
        public string Sendername { get; set; }
        
        [Display(Name = "Dog Name")]
        public string DogName { get; set; }

        [Required(ErrorMessage = "Enter the comment's content")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}