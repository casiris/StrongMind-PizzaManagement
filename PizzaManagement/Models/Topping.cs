using System;
using System.Collections.Generic;

namespace PizzaManagement.Models;

public partial class Topping
{
    public int Id { get; set; }

    public string? ToppingName { get; set; }

    public virtual ICollection<Pizza> PizzaTopping1Navigations { get; set; } = new List<Pizza>();

    public virtual ICollection<Pizza> PizzaTopping2Navigations { get; set; } = new List<Pizza>();

    public virtual ICollection<Pizza> PizzaTopping3Navigations { get; set; } = new List<Pizza>();
}
