using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace topCoders.Models
{
    public class Coder
    {
        [Key]
        public int Id { get;set; }
        [Required(ErrorMessage = "Please put a correct name!")]
        [MinLength(2)]
        [MaxLength(100)]
        public string? Name { get;set; }
        [Required(ErrorMessage = "Please put a correct age!")]
        public int Age { get;set; }
    }
}
