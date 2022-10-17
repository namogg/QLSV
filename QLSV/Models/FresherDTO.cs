using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.EntityFrameworkCore;

namespace QLSV.Models
{
    public class FresherDTO:EmployeeDTO
    {   
        [Key]
        public int ID { get; set; }
        [Display(Name = "Graduation rank")]
        public string GraduationRank { get; set; }
        [StringLength(10, MinimumLength = 1)]
        [Required]
        public string Education { get; set; }
        [Display(Name = "Graduation date")]

        [DataType(DataType.Date)]
        public DateTime GraduationDate { get; set; }
        public FresherDTO()
        {

        }
    } 
}
