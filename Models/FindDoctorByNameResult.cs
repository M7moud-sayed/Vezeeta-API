﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VezeetaAPI.Models
{
    public partial class FindDoctorByNameResult
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string DoctorName { get; set; }
        public string Gender { get; set; }
        [StringLength(50)]
        public string Degree { get; set; }
        [Column("Fees", TypeName = "decimal(10,2)")]
        public decimal? Fees { get; set; }
        [StringLength(100)]
        public string Image { get; set; }
        [StringLength(100)]
        public string MainSpecialty { get; set; }
        [StringLength(50)]
        public string SubSpecialty { get; set; }
        [StringLength(50)]
        public string ClinicName { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string Governorate { get; set; }
        [StringLength(50)]
        public string Street { get; set; }
    }
}
