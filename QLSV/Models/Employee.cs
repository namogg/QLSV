using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLSV.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }
        public string Room { get; set; }
        [RegularExpression(@"^[F,M]")]
        [StringLength(1)]
        [Required]
        public string Gender { get; set; }
        public string Adress { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }
        public List<Certificate> Certificates { get; set; }
        public Employee() { }
        public Employee(string Name,string room,string gender,string adress,DateTime Birth)
        {
            this.Name =Name;
            this.Room = room;
            this.Gender = gender;
            this.Adress = adress;
            this.Birth = Birth;
            List<Certificate> ListCertificate = new List<Certificate>();
        }
    }
}
