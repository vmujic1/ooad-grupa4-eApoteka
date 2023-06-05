using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Apoteka.Models;

public class Cart
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("AspNetUser")]
    public string UserId { get; set; }
    public User User { get; set; }
    public double TotalPrice { get; set; }
    public Cart() { }
}