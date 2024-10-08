﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiCenter.Data.Models;

public partial class Veterinarian
{
    public int UserId { get; set; }

    public string Specialization { get; set; }

    public string LicenseNumber { get; set; }

    public int? YearsOfExperience { get; set; }

    public string ClinicAddress { get; set; }

    public string ProfilePictureUrl { get; set; }

    public decimal? Rating { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string CreatedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; }

    public virtual ICollection<VeterinarianAvailability> VeterinarianAvailabilities { get; set; } = new List<VeterinarianAvailability>();
}