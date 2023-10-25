﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CargoRequestAPI.Models;

public class Recipient
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
}