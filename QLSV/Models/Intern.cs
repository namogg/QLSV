using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace QLSV.Models
{
    public class Intern
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InternId { get; set; }
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
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public Intern()
        {

        }
        public Intern(InternDTO internDTO)
        {
            this.Employee = new Employee(internDTO.Name, internDTO.room, internDTO.gender, internDTO.adress, internDTO.Birth);
            this.Majors = internDTO.Majors;
            this.Semester = internDTO.Semester;
            this.University_name = internDTO.University_name;
        }
    }
}
