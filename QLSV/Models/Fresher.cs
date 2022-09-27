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

        }
        public Fresher(FresherDTO fresherDTO)
        {
            this.Employee = new Employee(fresherDTO.Name, fresherDTO.room, fresherDTO.gender, fresherDTO.adress, fresherDTO.Birth);
            this.Graduation_date = fresherDTO.Graduation_date;
            this.Graduation_rank = fresherDTO.Graduation_rank;
            this.Education = fresherDTO.Education;
        }
    }
}
