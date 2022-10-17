using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.EntityFrameworkCore;

namespace QLSV.Models
{
    public class EmployeeDTO
    {
        [Key]
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }
        public string Room { get; set; }
        [RegularExpression(@"^[F,M]")]
        [StringLength(1)]
        [Required]
        public string Gender { get; set; }
        public string Adress { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }
        public List<Certificate> Certificates { get; set; }
        public EmployeeDTO()
        {

        }
    }
}
