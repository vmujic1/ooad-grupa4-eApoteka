using System;

namespace E_Apoteka.Models;

public class Staff
{
    public int Id { get; set;}
    public String Name { get; set;}
    public String Surname { get; set;}
    public String  Username { get; set;}

    public String Password { get; set;}

    public String Email { get; set;}

    public String PhoneNumber { get; set;}

    public Role Role { get; set;}

}
