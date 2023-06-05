using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Apoteka.Models;

public class Comment
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [ForeignKey("AspNetUser")]
    public string UserId { get; set; }
    public User User { get; set; }

    public string Text { get; set; }
    public string Rating { get; set; }
    public DateTime CommentDate { get; set; }
    public Comment() { }

}