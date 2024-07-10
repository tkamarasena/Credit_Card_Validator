using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository.Models;

public partial class ValidationRequest
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string CreditCardNumber { get; set; } = null!;

    public bool IsValid { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RequestDate { get; set; }
}
