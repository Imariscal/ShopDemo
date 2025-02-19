using Shop.CrossCutting.Exceptions;
using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Domain.Repositories.Base;
using Shop.Domain.BusinessRules.Base;
using Shop.Domain.DTOs.Item;
using Shop.Domain.ViewModels;

namespace Shop.Application.BussinesProcess.Item.Command
{
    public class PostItemCommand(ItemDTO item) : ICommand<ItemViewModel>
    {
        public ItemDTO Item { get; set; } = item;
    }
    public class PostItemCommandHandler(
       IWriteOnlyRepository<Guid, Domain.Entities.Item> repository,
       IValidationStrategy<ItemDTO> validationStrategy, IMapper mapper) : ICommandHandler<PostItemCommand, ItemViewModel>
    {
        public async Task<ItemViewModel> Handle(PostItemCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);
            Validate(command.Item);

            var shopStore = mapper.Map<Domain.Entities.Item>(command.Item);
            await repository.AddAsync(shopStore);

            return mapper.Map<ItemViewModel>(shopStore);
        }

        private void Validate(ItemDTO item)
        {
            var validationResult = validationStrategy.Validate(item);
            if (!validationResult.IsValid) throw new BusinessValidationException(validationResult.Errors);
        }
    }
}
