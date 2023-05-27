using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace E_Apoteka.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Medicine> Medicines { get;}

        public Manufacturer() { }
	}
}