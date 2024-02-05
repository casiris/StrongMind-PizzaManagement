using System;
using System.Collections.Generic;

namespace PizzaManagement.Models;

public partial class Pizza
{
    public string PizzaName { get; set; } = null!;

    public int? Topping1 { get; set; }

    public int? Topping2 { get; set; }

    public int? Topping3 { get; set; }

    public virtual Topping? Topping1Navigation { get; set; }

    public virtual Topping? Topping2Navigation { get; set; }

    public virtual Topping? Topping3Navigation { get; set; }
}
