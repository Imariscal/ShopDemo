using Shop.Application.BussinesProcess.Base.Contracts; 
using Shop.CrossCutting.Exceptions;
using Shop.Domain.Repositories.Base;
 

namespace Shop.Application.BussinesProcess.Item.Command
{
 
    public class DeleteItemCommand(Guid itemId) : ICommand<bool>
    {
        public Guid ItemId { get; set; } = itemId;
    }

    public class DeleteItemCommandHandler(
      IWriteOnlyRepository<Guid, Domain.Entities.Item> repository,
      IReadOnlyRepository<Guid, Domain.Entities.Item> readOnlyRepository) : ICommandHandler<DeleteItemCommand, bool>
    {
        public async Task<bool> Handle(DeleteItemCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);
            var result = await readOnlyRepository.GetAllMatchingAsync(u => u.Id == command.ItemId);
            var client = result.FirstOrDefault() ?? throw new NotFoundException("Item was not found");

            await repository.Remove(client);

            return true;
        }
    }
}
