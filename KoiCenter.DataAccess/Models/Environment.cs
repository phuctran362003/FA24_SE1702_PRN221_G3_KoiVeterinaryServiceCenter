﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiCenter.Data.Models;

public partial class Environment
{
    public int Id { get; set; }

    public string EnvironmentType { get; set; }

    public virtual ICollection<PetType> PetTypes { get; set; } = new List<PetType>();
}