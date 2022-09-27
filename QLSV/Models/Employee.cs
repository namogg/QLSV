﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
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
        public string room { get; set; }
        [RegularExpression(@"^[F,M]")]
        [StringLength(1)]
        [Required]
        public string gender { get; set; }
        public string adress { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }
        //public List<Certificate> Certificates { get; set; }
        public Employee(string Name,string room,string gender,string adress,DateTime Birth)
        {
            this.Name =Name;
            this.room = room;
            this.gender = gender;
            this.adress = adress;
            this.Birth = Birth;
            //List<Certificate> ListCertificate = new List<Certificate>();
        }
    }
}
