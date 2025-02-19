
using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.CrossCutting.Exceptions;
using Shop.Domain.BusinessRules.Base;
using Shop.Domain.DTOs.Client;
using Shop.Domain.Repositories.Base;
using Shop.Domain.ViewModels;


namespace Shop.Application.BussinesProcess.Client.Command
{
    public class PostClientCommand(ClientViewModel _client) :  ICommand<ClientViewModel>
    {
        public ClientViewModel client { get; set; } = _client;   
    }

    public class PostClientCommandHandler(
       IWriteOnlyRepository<Guid, Domain.Entities.Client> repository,
       IValidationStrategy<ClientDTO> validationStrategy, IMapper mapper) 
        : ICommandHandler<PostClientCommand, ClientViewModel>
    {
        public async Task<ClientViewModel> Handle(PostClientCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);
            Validate(command.client);

            var client = mapper.Map<Domain.Entities.Client>(command.client);
            await repository.AddAsync(client);

            return mapper.Map<ClientViewModel>(client);
        }

        private void Validate(ClientDTO clientDTO)
        {
            var validationResult = validationStrategy.Validate(clientDTO);
            if (!validationResult.IsValid) throw new BusinessValidationException(validationResult.Errors);
        }
    }
}
