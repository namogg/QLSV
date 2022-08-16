using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace QLSV.Models
{
    public class Experience: Employee
    {
        [Display(Name = "Years of experience")]
        public int ExpInYear { get; set; }
        [Display(Name = "Professional Skill")]
        [StringLength(20, MinimumLength = 1)]
        [Required]
        public string ProSkill { get; set; }
    }
}
