﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoRequestAPI.Models;

public class Recipient
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
    [Required]
    public string? Address { get; set; }
}