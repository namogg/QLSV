using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace QLSV.Models
{
    public class Intern: Employee
    {   [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Majors { get; set; }
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Semester { get; set; }
        [StringLength(20, MinimumLength = 1)]
        [Required]
        public string University_name { get; set; }
    }
}
