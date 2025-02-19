﻿ 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shop.Domain.Entities.Base.Contracts;
 
namespace Shop.Domain.Entities.Base;

public abstract class Auditable<T> : BaseEntity<T>, IAuditable<T>
{
    [Required]
    [StringLength(50)]
    public string CreatedBy { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "smalldatetime")]
    public DateTime CreationDate { get; set; }

    [StringLength(50)]
    public string LastModifiedBy { get; set; } = string.Empty;

    [Column(TypeName = "smalldatetime")]
    public DateTime LastModificationDate { get; set; }

    [StringLength(50)]
    public string? DeletedBy { get; set; }

    [StringLength(50)]
    public DateTime? DeletionDate { get; set; }

    [Required]
    public bool Active { get; set; }
}
