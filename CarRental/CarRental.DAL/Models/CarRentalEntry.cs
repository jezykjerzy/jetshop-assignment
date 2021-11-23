using CarRental.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRental.DAL.Models
{
    // TODO Handle better DateTime
    // TODO Project should be named CarRentalApi
    public class CarRentalEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Car Car { get; set; }

        [Required]

        public DateTime StartDate { get; set; }

        [Required]

        public DateTime ProvidedUserEndDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public DateTime CustomerDateOfBirth { get; set; }

        [Required]
        public long CurrentCarMilageKm { get; set; }

        //TODO add customer idetification

    }
}
