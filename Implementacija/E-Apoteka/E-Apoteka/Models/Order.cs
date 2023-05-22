using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Apoteka.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    public List<Product> Products { get; set; }

    [ForeignKey("User")]
    public int CustomerId { get; set; }
    public int Amount { get; set; }
    public string OrderStatus { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string DeliveryAddress { get; set; }
    public OrderType OrderType { get; set; }
}