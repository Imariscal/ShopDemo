namespace Shop.Application.BussinesProcess.Base.Contracts;

public interface IQueryHandler<TQuery, TResult>
{
    Task<TResult> Handle(TQuery query);
}