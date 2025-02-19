using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.CrossCutting.Exceptions; 
using Shop.Domain.Repositories.Base;
 
namespace Shop.Application.BussinesProcess.Client.Command
{
    public class DeleteClientCommand(Guid clientId) : ICommand<bool>
    {
        public Guid ClientId { get; set; } = clientId;
    }

    public class DeleteClientCommandHandler(
        IWriteOnlyRepository<Guid, Domain.Entities.Client> repository,
        IReadOnlyRepository<Guid, Domain.Entities.Client> readOnlyRepository) : ICommandHandler<DeleteClientCommand, bool>
    {
        public async Task<bool> Handle(DeleteClientCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);
            var result = await readOnlyRepository.GetAllMatchingAsync(u => u.Id == command.ClientId);
            var client = result.FirstOrDefault() ?? throw new NotFoundException("Clieant was not found");

            await repository.Remove(client);

            return true;
        }
    }
}
