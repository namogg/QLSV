﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace QLSV.Models
{
    public class InternDTO
    {
        [Key]
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
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Majors { get; set; }
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Semester { get; set; }
        [StringLength(20, MinimumLength = 1)]
        [Required]
        public string University_name { get; set; }

        public InternDTO()
        {

        }
    }
}