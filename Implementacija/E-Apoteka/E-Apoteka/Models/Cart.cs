using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Apoteka.Models;

public class Cart
{
    [Key]
    public int Id { get; set; }

    List<Dictionary<Medicine, int>> products;

    [ForeignKey("User")]
    public int UserId { get; set; }
    double TotalPrice { get; set; }
}