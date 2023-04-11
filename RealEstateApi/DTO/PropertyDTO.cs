﻿using System.ComponentModel.DataAnnotations;

namespace RealEstateApi.DTO
{
    public class PropertyDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string UrlImages { get; set; }
        public Double PriceifSale { get; set; }
        public Double PriceifRent { get; set; }
        public List<Appointment>? Appointments { get; set; }
        //relationships 
        [ForeignKey("PropertytypesId")]
        public int? PropertytypesID { get; set; }
        public PropertyTypes? Propertytypes { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }

    }
}