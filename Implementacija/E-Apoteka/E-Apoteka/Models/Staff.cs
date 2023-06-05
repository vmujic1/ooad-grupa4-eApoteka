using Microsoft.AspNetCore.Identity;
using System;

namespace E_Apoteka.Models;

public class Staff: IdentityUser
{
    public String FirstName { get; set;}
    public String LastName { get; set;}
    public List<Prescription> Prescriptions { get; set;}
    public Staff() { }
}
