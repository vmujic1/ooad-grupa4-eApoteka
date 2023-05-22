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

    [ForeignKey("User")]
    public int UserId { get; set; }

    public string Text { get; set; }
    public string rating { get; set; }
    public DateTime CommentDate { get; set; }

}