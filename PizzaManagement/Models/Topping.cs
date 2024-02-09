using Microsoft.EntityFrameworkCore;
using PizzaManagement.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace PizzaManagement.Models
{
    public class UniqueTopping : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            if (dbContext.Toppings.Any(x => x.ToppingName == (string)value))
            {
                return new ValidationResult("That topping already exists.");
            }
            return ValidationResult.Success;
        }
    }

    public class Topping
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Topping")]
        [Column(TypeName = "nvarchar(20)")]
        [MaxLength(20)]
        [UniqueTopping]
        public string ToppingName { get; set; }
    }
}
