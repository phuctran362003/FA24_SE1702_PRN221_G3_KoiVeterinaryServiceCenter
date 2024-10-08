﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiCenter.Data.Models;

public partial class ServiceCategory
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ServiceType { get; set; }

    public string ApplicableTo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string CreatedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}