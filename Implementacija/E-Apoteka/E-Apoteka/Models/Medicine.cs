using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Apoteka.Models;

public class Medicine : Product
{
    public DateTime ExpirationDate { get; set; }
    public double Weight { get; set; }
    public Medicine() { }
}