using Microsoft.Extensions.Logging; 
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Application.Services.Base.Contracts;
using Shop.Domain.DTOs.Contracts;
using Shop.Domain.Entities.Base.Contracts;

namespace Shop.Catalogos.Retail.Application.Services.Base;

public abstract class BaseApplicationService<BaseDTO, TEntity, TKey>(
    IMediator mediator,
    ILogger<IBaseApplicationService<BaseDTO>> logger) : IBaseApplicationService<BaseDTO> 
        where BaseDTO : class, IBaseDTO
        where TEntity : class, IBaseEntity<TKey>
{
    protected readonly IMediator _mediator = mediator;
    protected readonly ILogger<IBaseApplicationService<BaseDTO>> _logger = logger;
}