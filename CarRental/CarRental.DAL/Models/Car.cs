using CarRental.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.DAL.Model
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)"), Required]
        public string Name { get; set; }

        [Required]
        public CarCategory Category { get; set; }

        [Required]
        public bool Available { get; set; }

        [Required]
        public long TotalMilageKm { get; set; }
    }
}