using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace E_Apoteka.Models;

public class User: IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public DateTime Birthdate { get; set; }
    public string InsuranceNumber { get; set; }

    public List<Prescription> Prescriptions { get; set; }
    public List<Order> Orders { get; set; }
    public List<Comment> Comments { get; set; }
    public Cart? Cart { get; set; }

    public User() {}
}
