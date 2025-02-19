
using Shop.CrossCutting.Exceptions;
using Shop.Domain.BusinessRules.Base;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Domain.DTOs.Client;
using Shop.Domain.Entities;
using Shop.Domain.Repositories.Base;
using Mapster;
using MapsterMapper;
using Shop.Domain.ViewModels;


namespace Catalog.Application.BussinesProcess.Employee
{
    public class PutClientCommand(Guid Id, ClientDTO _client) : ICommand<ClientViewModel>
    {
        public Guid Id { get; set; } = Id;
        public ClientDTO Client { get; private set; } = _client;
    }

    public class PutClientCommandHandler(
    IWriteOnlyRepository<Guid, Client> repository,
    IReadOnlyRepository<Guid, Client> readOnlyRepository, IMapper mapper,
    IValidationStrategy<ClientDTO> validationStrategy) : ICommandHandler<PutClientCommand, ClientViewModel>
    {
        public async Task<ClientViewModel> Handle(PutClientCommand command)
        {
            ArgumentNullException.ThrowIfNull(command.Id);
            ArgumentNullException.ThrowIfNull(command.Client);

            Validate(command.Client);

            var result = await readOnlyRepository.GetAsync(command.Id) ?? throw new NotFoundException("Client was not found");
            command.Client.Adapt(result);

            await repository.Modify(result);

            return mapper.Map<ClientViewModel>(result);
        }

        private void Validate(ClientDTO employeeDTO)
        {
            var validationResult = validationStrategy.Validate(employeeDTO);
            if (!validationResult.IsValid) throw new BusinessValidationException(validationResult.Errors);
        }
    }

}
