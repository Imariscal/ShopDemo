using Shop.Application.BussinesProcess.Base.Contracts;
using Shop.CrossCutting.Exceptions;
using Shop.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.BussinesProcess.ShopStore.Command
{
    public class DeleteShopStoreCommand(Guid shopStoreId) : ICommand<bool>
    {
        public Guid ShopStoreId { get; set; } = shopStoreId;
    }

    public class DeleteShopStoreCommandHandler(
        IWriteOnlyRepository<Guid, Domain.Entities.ShopStore> repository,
        IReadOnlyRepository<Guid, Domain.Entities.ShopStore> readOnlyRepository) : ICommandHandler<DeleteShopStoreCommand, bool>
    {
        public async Task<bool> Handle(DeleteShopStoreCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);
            var result = await readOnlyRepository.GetAllMatchingAsync(u => u.Id == command.ShopStoreId);
            var client = result.FirstOrDefault() ?? throw new NotFoundException("Shop Store was not found");

            await repository.Remove(client);

            return true;
        }
    }
}
