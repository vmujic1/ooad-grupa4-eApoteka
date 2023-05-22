using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Apoteka.Models
{
    public class MedicinePrescription
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int MedicineId { get; set; }

        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }
    }
}