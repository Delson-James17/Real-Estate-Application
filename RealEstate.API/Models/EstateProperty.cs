
using System.ComponentModel.DataAnnotations;

namespace RealEstate.API.Models
{
    public class EstateProperty
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string UrlImages { get; set; }
        public Double PriceifSale { get; set; }
        public Double PriceifRent { get; set; }

        public EstateProperty()
        {
            
        }
        public EstateProperty(int id, string name, string description, string address, string urlImages, double priceifSale, double priceifRent)
        {
            Id = id;
            Name = name;
            Description = description;
            Address = address;
            UrlImages = urlImages;
            PriceifSale = priceifSale;
            PriceifRent = priceifRent;
        }
    }
}
