using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRental.DAL.Models
{
    public class CarReturn
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public CarRentalEntry CarRental { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        public long CurrentCarMilageKm { get; set; }
    }
}
