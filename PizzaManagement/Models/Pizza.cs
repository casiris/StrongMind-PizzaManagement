using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PizzaManagement.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Pizza Name")]
        public string PizzaName { get; set; }

        // Foreign key for Topping1
        public int? Topping1Id { get; set; }

        // Foreign key for Topping2
        public int? Topping2Id { get; set; }

        // Foreign key for Topping3
        public int? Topping3Id { get; set; }

        // Navigation property for Topping1
        [ForeignKey("Topping1Id")]
        [DisplayName("Topping 1")]
        public Topping? Topping1 { get; set; }

        // Navigation property for Topping2
        [ForeignKey("Topping2Id")]
        [DisplayName("Topping 2")]
        public Topping? Topping2 { get; set; }

        // Navigation property for Topping3
        [ForeignKey("Topping3Id")]
        [DisplayName("Topping 3")]
        public Topping? Topping3 { get; set; }
    }
}
