using Shop.Domain.DTOs.Contracts;
namespace Shop.Domain.DTOs.Base;

public abstract class BaseCrudDTO<T> : IBaseCrudDTO<T>
{
    public required T Id { get; set; }
}