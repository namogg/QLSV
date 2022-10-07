using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace QLSV.Models
{
    
    public class Experience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExperienceId { get; set; }
        [Display(Name = "Years of experience")]
        public int ExpInYear { get; set; }
        [Display(Name = "Professional Skill")]
        [StringLength(20, MinimumLength = 1)]
        [Required]
        public string ProSkill { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public Experience()
        {
        }

        public Experience(ExperienceDTO experienceDTO)
        {
            this.Employee = new Employee(experienceDTO.Name, experienceDTO.room, experienceDTO.gender, experienceDTO.adress, experienceDTO.Birth);
            this.ExpInYear = experienceDTO.ExpInYear;
            this.ProSkill = experienceDTO.ProSkill;
            this.Employee.Certificates = experienceDTO.Certificates;
        }
    }
}
