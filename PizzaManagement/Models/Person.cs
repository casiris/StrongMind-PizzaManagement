using System;
using System.Collections.Generic;

namespace PizzaManagement.Models;

public partial class Person
{
    public string Username { get; set; } = null!;

    public string? Pw { get; set; }

    public string? AccessLevel { get; set; }
}
