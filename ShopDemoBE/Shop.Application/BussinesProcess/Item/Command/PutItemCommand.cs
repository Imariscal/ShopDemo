using Shop.CrossCutting.Exceptions;
using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Domain.DTOs.ShopStore;
using Shop.Domain.Repositories.Base;
using Shop.Domain.BusinessRules.Base; 
using Mapster;
using Shop.Domain.DTOs.Item;
using Shop.Domain.ViewModels;
using Shop.Domain.Entities;


namespace Shop.Application.BussinesProcess.Item.Command
{
    public class PutItemCommand(Guid Id, ItemDTO item) : ICommand<ItemViewModel>
    {
        public Guid Id { get; set; } = Id;
        public ItemDTO Item { get; private set; } = item;
    }

    public class PutItemCommandHandler(
    IWriteOnlyRepository<Guid, Domain.Entities.Item> repository,
    IReadOnlyRepository<Guid, Domain.Entities.Item> readOnlyRepository, IMapper mapper,
    IValidationStrategy<ItemDTO> validationStrategy) : ICommandHandler<PutItemCommand, ItemViewModel>
    {
        public async Task<ItemViewModel> Handle(PutItemCommand command)
        {
            ArgumentNullException.ThrowIfNull(command.Id);
            ArgumentNullException.ThrowIfNull(command.Item);

            Validate(command.Item);

            var result = await readOnlyRepository.GetAsync(command.Id) ?? throw new NotFoundException("Item was not found");
            command.Item.Adapt(result);

            await repository.Modify(result);

            return mapper.Map<ItemViewModel>(result);
        }

        private void Validate(ItemDTO item)
        {
            var validationResult = validationStrategy.Validate(item);
            if (!validationResult.IsValid) throw new BusinessValidationException(validationResult.Errors);
        }
    }

}
