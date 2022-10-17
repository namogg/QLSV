using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace QLSV.Models
{
    public class ExperienceDTO:EmployeeDTO
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Years of Experience")]
        [Required]
        public int ExpInYear { get; set; }
        [Display(Name = "Professional Skill")]
        [StringLength(20, MinimumLength = 1)]
        [Required]
        public string ProSkill { get; set; }
        public ExperienceDTO()
        {

        }
    }
}
