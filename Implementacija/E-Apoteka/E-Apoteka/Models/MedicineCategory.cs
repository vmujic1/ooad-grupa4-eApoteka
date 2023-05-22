﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Apoteka.Models
{
    public class MedicineCategory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int MedicineId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
    }
}