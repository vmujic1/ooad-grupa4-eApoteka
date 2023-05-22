using System;

namespace E_Apoteka.Models;

public class Medicine : Product
{
    public DateTime ExpirationDate { get; set; }
    public double Weight { get; set; }
    public List<Category> Categories { get; set; }
    public List<Prescription> Prescriptions { get; set; }
}