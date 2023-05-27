using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Apoteka.Models;

public class Prescription
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    [ForeignKey("Staff")]
    public int StaffId { get; set; }
    public int Amount { get; set; }
    public string InsuranceNumber { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpirationDate { get; set; }

    public Prescription() { }
}