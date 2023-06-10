using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Apoteka.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

	[ForeignKey("Manufacturer")]
	public int ManufacturerId { get; set; }
	public Manufacturer? Manufacturer { get; set; }

	public double Price { get; set; }

    public double Rating { get; set; }

    public int Stock { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public string Description { get; set; }

    public List<Comment>? Comments { get; set; }

    public string ImageUrl { get; set; }

    public Product() { }

}