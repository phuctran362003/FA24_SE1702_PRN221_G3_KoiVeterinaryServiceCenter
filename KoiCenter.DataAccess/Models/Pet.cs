﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiCenter.Data.Models;

public partial class Pet
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? Age { get; set; }

    public int? PetTypeId { get; set; }

    public string Breed { get; set; }

    public string ImageUrl { get; set; }

    public string Color { get; set; }

    public double? Length { get; set; }

    public double? Weight { get; set; }

    public int? Quantity { get; set; }

    public DateTime? LastHealthCheck { get; set; }

    public int? OwnerId { get; set; }

    public int? HealthStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string CreatedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User Owner { get; set; }

    public virtual PetType PetType { get; set; }
}