using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Test.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        [Display(Name ="Roll No.")]
        public int RollNo { get; set; }
        [Required]
        [Range(0, 100,ErrorMessage="Percentage should be between 0 to 100")]
        public decimal Percentage { get; set; }
    }
}
