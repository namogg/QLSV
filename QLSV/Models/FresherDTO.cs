using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace QLSV.Models
{
    public class FresherDTO
    {   [Key]
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }
        public string room { get; set; }
        [RegularExpression(@"^[F,M]")]
        [StringLength(1)]
        [Required]
        public string gender { get; set; }
        public string adress { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }
        [StringLength(10, MinimumLength = 1)]
        [Required]
        public string Graduation_rank { get; set; }
        [StringLength(10, MinimumLength = 1)]
        [Required]
        public string Education { get; set; }
        [Display(Name = "Graduation date")]

        [DataType(DataType.Date)]
        public DateTime Graduation_date { get; set; }

        public FresherDTO()
        {

        }
    } 
}
