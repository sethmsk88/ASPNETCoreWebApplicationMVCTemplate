using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreWebApplicationMVCTemplate.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9_.+-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        [Required]
        public Branch? Branch { get; set; } // Question mark makes Branch nullable
        public Gender Gender { get; set; }
        public string Section { get; set; }
        [Display(Name = "Home Address")]
        public string Address { get; set; }
        [NotMapped]
        public IEnumerable<Gender> AllGenders { set; get; }
    }
}
