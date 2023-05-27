using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Apoteka.Models;

public class Order
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("User")]
    public int CustomerId { get; set; }
    public User User { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime OrderDate { get; set; }
	public OrderType OrderType { get; set; }
    public PaymentType PaymentType { get; set; }
	public double TotalPrice { get; set; }
	public string DeliveryAddress { get; set; }

    public Order() { }
    
}