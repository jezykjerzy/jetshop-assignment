using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRental.DAL.Models
{
    // TODO All ids could be long
    public class RentalPayment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public CarReturn  CarReturn { get; set; }
    }
}
