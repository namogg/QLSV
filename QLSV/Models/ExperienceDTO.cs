﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace QLSV.Models
{
    public class ExperienceDTO
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
        [Display(Name = "Years of Experience")]
        [Required]
        public int ExpInYear { get; set; }
        [Display(Name = "Professional Skill")]
        [StringLength(20, MinimumLength = 1)]
        [Required]
        public string ProSkill { get; set; }

        public ExperienceDTO()
        {

        }
    }
}