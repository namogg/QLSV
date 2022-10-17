using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace QLSV.Models
{
    public class Fresher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FresherID { get; set; }
        [Display(Name = "Graduation Rank")]
        [StringLength(10, MinimumLength = 1)]
        [Required]
        public string Graduation_rank { get; set; }
        [StringLength(10, MinimumLength = 1)]
        [Required]
        public string Education { get; set; }
        [Display(Name = "Graduation date")]
        [DataType(DataType.Date)]
        public DateTime Graduation_date { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public Fresher()
        {
            Employee = new Employee();
        }
        public Fresher(string Name,string room, string gender, string adress,DateTime Birth, DateTime Graduation_date,string Graduation_rank,string Education)
        {
            this.Employee = new Employee(Name, room, gender, adress,Birth);
            this.Graduation_date = Graduation_date;
            this.Graduation_rank = Graduation_rank;
            this.Education = Education;
        }
        public Fresher(FresherDTO fresherDTO)
        {
            this.Employee = new Employee(fresherDTO.Name, fresherDTO.Room, fresherDTO.Gender, fresherDTO.Adress, fresherDTO.Birth);
            this.Graduation_date = fresherDTO.GraduationDate;
            this.Graduation_rank = fresherDTO.GraduationRank;
            this.Education = fresherDTO.Education;
            this.Employee.Certificates= fresherDTO.Certificates;
        }
    }
}
