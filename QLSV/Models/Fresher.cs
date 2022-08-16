using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace QLSV.Models
{
    public class Fresher: Employee
    {
        [StringLength(10, MinimumLength = 1)]
        [Required]
        public string Graduation_rank { get; set; }
        [StringLength(10, MinimumLength = 1)]
        [Required]
        public string Education { get; set; }
        [Display(Name = "Graduation date")]
        [DataType(DataType.Date)]
        public DateTime Graduation_date { get; set; }

    }
}
