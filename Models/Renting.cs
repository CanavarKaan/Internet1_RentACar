using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internet1_RentACar.Models
{
    public class Renting
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        [ValidateNever]
        public int CarId { get; set; }
        [ForeignKey("CarId")]

        [ValidateNever]
        public Car Car { get; set; }
    }
}
