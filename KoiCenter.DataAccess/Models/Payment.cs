﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiCenter.Data.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? OrderId { get; set; }

    public int? SystemTransactionId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? Tax { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string CreatedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Order Order { get; set; }

    public virtual SystemTransaction SystemTransaction { get; set; }
}