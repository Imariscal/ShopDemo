
using Shop.Domain.Entities.Base.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Entities.Base;

public abstract class BaseEntity<T> : IBaseEntity<T>
{
    [Key]
    public required T Id { get; set; }
}
