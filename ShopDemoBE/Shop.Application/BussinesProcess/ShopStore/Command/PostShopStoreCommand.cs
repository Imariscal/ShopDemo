using Shop.CrossCutting.Exceptions; 
using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts; 
using Shop.Domain.DTOs.ShopStore; 
using Shop.Domain.Repositories.Base;
using Shop.Domain.BusinessRules.Base;
using Shop.Domain.DTOs.Client;
using Shop.Domain.ViewModels;

namespace Shop.Application.BussinesProcess.ShopStore.Command
{
    public class PostShopStoreCommand(ShopStoreDTO _shopStore) : ICommand<ShopStoreViewModel>
    {
        public ShopStoreDTO shopStore { get; set; } = _shopStore;
     
    } 

    public class PostShopStoreCommandHandler(
       IWriteOnlyRepository<Guid, Domain.Entities.ShopStore> repository,
       IValidationStrategy<ShopStoreDTO> validationStrategy, IMapper mapper) : ICommandHandler<PostShopStoreCommand, ShopStoreViewModel>
    {
        public async Task<ShopStoreViewModel> Handle(PostShopStoreCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);
            Validate(command.shopStore);

            var shopStore = mapper.Map<Domain.Entities.ShopStore>(command.shopStore);
            await repository.AddAsync(shopStore);

            return mapper.Map<ShopStoreViewModel>(shopStore);
        }

        private void Validate(ShopStoreDTO shopStore)
        {
            var validationResult = validationStrategy.Validate(shopStore);
            if (!validationResult.IsValid) throw new BusinessValidationException(validationResult.Errors);
        }
    }
}
