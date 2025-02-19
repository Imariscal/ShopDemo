using Shop.CrossCutting.Exceptions;
using MapsterMapper;
using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.Domain.DTOs.ShopStore;
using Shop.Domain.Repositories.Base;
using Shop.Domain.BusinessRules.Base;
using Shop.Domain.DTOs.Client;
using Mapster;
using Shop.Domain.Entities;
using Shop.Domain.ViewModels;


namespace Shop.Application.BussinesProcess.ShopStore.Command
{
    public class PutShopStoreCommand(Guid Id, ShopStoreDTO shop) : ICommand<ShopStoreViewModel>
    {
        public Guid Id { get; set; } = Id;
        public ShopStoreDTO ShopStore { get; private set; } = shop;
    }

    public class PutShopStoreCommandHandler(
    IWriteOnlyRepository<Guid, Domain.Entities.ShopStore> repository,
    IReadOnlyRepository<Guid, Domain.Entities.ShopStore> readOnlyRepository,
    IMapper mapper,
    IValidationStrategy<ShopStoreDTO> validationStrategy) : ICommandHandler<PutShopStoreCommand, ShopStoreViewModel>
    {
        public async Task<ShopStoreViewModel> Handle(PutShopStoreCommand command)
        {
            ArgumentNullException.ThrowIfNull(command.Id);
            ArgumentNullException.ThrowIfNull(command.ShopStore);

            Validate(command.ShopStore);

            var result = await readOnlyRepository.GetAsync(command.Id) ?? throw new NotFoundException("Shop Store was not found");
            command.ShopStore.Adapt(result);

            await repository.Modify(result);

            return  mapper.Map<ShopStoreViewModel>(result);
        }

        private void Validate(ShopStoreDTO shopStore)
        {
            var validationResult = validationStrategy.Validate(shopStore);
            if (!validationResult.IsValid) throw new BusinessValidationException(validationResult.Errors);
        }
    }

}
