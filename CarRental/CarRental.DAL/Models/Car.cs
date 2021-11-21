﻿using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Model
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Name{ get; set; }
    }
}