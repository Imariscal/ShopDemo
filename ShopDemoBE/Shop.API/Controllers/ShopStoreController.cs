using Microsoft.AspNetCore.Mvc;
using Shop.API.Execution.Answers.Contracts;
using Shop.API.Execution;
using System.Net;
using Shop.Application.Services.Contracts;
using Shop.Domain.DTOs.ShopStore;
using Shop.Domain.ViewModels;

namespace Shop.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShopStoreController(IShopStoreService service) : Controller
    {
        [HttpGet] 
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetEmployeeData()
        {
            async Task<IEnumerable<ShopStoreViewModel>> predicate() => await service.GetShopStoreDataAsync();
            var response = await SafeExecutor<IEnumerable<ShopStoreViewModel>>.ExecAsync(predicate);
            return ProcessResponse(response);
        }

        [HttpGet]
        [Route("GetShopStoreById/{shopStoreId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetShopStoreById(Guid shopId)
        {
            async Task<ShopStoreViewModel> predicate() => await service.GetShopStoreByIdAsync(shopId);
            var response = await SafeExecutor<ShopStoreViewModel>.ExecAsync(predicate);
            return ProcessResponse(response);
        }

        [HttpPost] 
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetEmployeeData(ShopStoreDTO shopStore)
        {
            async Task<ShopStoreViewModel> predicate() => await service.PostShopStore(shopStore);
            var response = await SafeExecutor<ShopStoreViewModel>.ExecAsync(predicate);
            return ProcessResponse(response);
        }

        [HttpPut("{shopStoreId}")] 
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateEmployee(Guid shopStoreId, [FromBody] ShopStoreDTO shopStore)
        {
            async Task<ShopStoreViewModel> predicate() => await service.PutShopStore(shopStoreId, shopStore);
            var response = await SafeExecutor<ShopStoreViewModel>.ExecAsync(predicate);
            return ProcessResponse(response);
        }


        [HttpDelete("{shopStoreId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteItem(Guid shopStoreId)
        {
            async Task predicate() => await service.DeleteShopStore(shopStoreId);
            var response = await SafeExecutor.ExecAsync(predicate);
            return ProcessResponse(response);
        }


        [HttpPost]
        [Route("AddItemToShopStore")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddItemToShopStore(Guid shopStoreId, Guid itemId)
        {
            async Task<ShopStoreViewModel> predicate() => await service.PostItemToShopStore(shopStoreId, itemId);
            var response = await SafeExecutor<ShopStoreViewModel>.ExecAsync(predicate);
            return ProcessResponse(response);
        }


        [HttpPost]
        [Route("DeleteItemToShopStore")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteItemToShopStore(Guid shopStoreId, Guid itemId)
        {
            async Task<ShopStoreViewModel> predicate() => await service.DeleteItemToShopStore(shopStoreId, itemId);
            var response = await SafeExecutor<ShopStoreViewModel>.ExecAsync(predicate);
            return ProcessResponse(response);
        }

        protected ActionResult ProcessResponse<T>(IAnswerBase<T> response) where T : class
        {
            if (response.Success) return Ok(response);
            else return BadRequest(response);
        }
    }
}
