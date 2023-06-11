using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Apoteka.Models
{
    public class ProductPrescription
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public ProductPrescription() { }
    }
}