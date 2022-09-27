using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace QLSV.Models
{
    public class Certificate
    {   
        public int CertificateID { get; set; }
        [Display(Name = "Certificate Name")]
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string CertificateName { get; set; }
        [Display(Name = "Certificate Rank")]
        [StringLength(10, MinimumLength = 1)]
        [Required]
        public string CertificateRank { get; set; }
        [Display(Name = "Graduation Date")]
        [DataType(DataType.Date)]
        public DateTime GraduationDate { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public Certificate()
        {

        }
    }
}
