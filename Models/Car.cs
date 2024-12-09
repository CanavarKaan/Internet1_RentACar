using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internet1_RentACar.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [ValidateNever]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public string PhotoUrl { get; set; }


    }
}
