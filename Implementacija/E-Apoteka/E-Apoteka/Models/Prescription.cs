using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Apoteka.Models;

public class Prescription
{
    [Key]
    public int Id { get; set; }

    List<Medicine> medicines;
    [ForeignKey("User")]
    public int UserId { get; set; }

    [ForeignKey("Staff")]
    public int StaffId { get; set; }
    int Amount { get; set; }
    string InsuranceNumber { get; set; }
    DateTime IssueDate { get; set; }
    DateTime ExpirationDate { get; set; }
}