using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace QLSV.Models
{
    public class InternDTO:EmployeeDTO
    {
        [Key]
        public int ID { get; set; }
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Majors { get; set; }
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Semester { get; set; }
        [StringLength(20, MinimumLength = 1)]
        [Required]
        [Display(Name = "University Name")]
        public string University_name { get; set; }
        public InternDTO()
        {

        }
    }
}
