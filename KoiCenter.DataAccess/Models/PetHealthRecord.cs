﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiCenter.Data.Models;

public partial class PetHealthRecord
{
    public int Id { get; set; }

    public int? OrderItemId { get; set; }

    public DateTime? CheckUpDate { get; set; }

    public string HealthStatus { get; set; }

    public string Diagnosis { get; set; }

    public string Treatment { get; set; }

    public DateTime? NextCheckUpDate { get; set; }

    public string Notes { get; set; }

    public virtual OrderItem OrderItem { get; set; }
}