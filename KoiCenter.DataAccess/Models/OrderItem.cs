﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiCenter.Data.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? PetId { get; set; }

    public int? ServiceId { get; set; }

    public int? ProductId { get; set; }

    public int? VeterinarianId { get; set; }

    public decimal? Price { get; set; }

    public decimal? TravelCost { get; set; }

    public string Location { get; set; }

    public string Status { get; set; }

    public DateTime? AppointmentDateTime { get; set; }

    public virtual Order Order { get; set; }

    public virtual Pet Pet { get; set; }

    public virtual ICollection<PetHealthRecord> PetHealthRecords { get; set; } = new List<PetHealthRecord>();

    public virtual Product Product { get; set; }

    public virtual Service Service { get; set; }

    public virtual Veterinarian Veterinarian { get; set; }
}