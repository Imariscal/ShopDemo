using Microsoft.AspNetCore.Mvc;
using Shop.API.Execution.Answers.Contracts;
using Shop.API.Execution;
using System.Net;
using Shop.Application.Services.Contracts;
using Shop.Domain.DTOs.Client;
using Shop.Domain.DTOs.Item;
using Shop.Domain.ViewModels;

namespace Shop.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ItemController(IITemService service) : Controller
    {
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetEmployeeData()
        {
            async Task<IEnumerable<ItemViewModel>> predicate() => await service.GetItemDataAsync();
            var response = await SafeExecutor<IEnumerable<ItemViewModel>>.ExecAsync(predicate);
            return ProcessResponse(response);
        }


        [HttpGet]
        [Route("GetItemById/{itemId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemById(Guid itemId)
        {
            async Task<ItemViewModel> predicate() => await service.GetItemByIdAsync(itemId);
            var response = await SafeExecutor<ItemViewModel>.ExecAsync(predicate);
            return ProcessResponse(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetEmployeeData(ItemDTO item)
        {
            async Task<ItemViewModel> predicate() => await service.PostItem(item);
            var response = await SafeExecutor<ItemViewModel>.ExecAsync(predicate);
            return ProcessResponse(response);
        }

        [HttpPut("{itemId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateEmployee(Guid itemId, [FromBody] ItemDTO item)
        {
            async Task<ItemViewModel> predicate() => await service.UpdteItem(itemId, item);
            var response = await SafeExecutor<ItemViewModel>.ExecAsync(predicate);
            return ProcessResponse(response);
        }

        [HttpDelete("{itemId}")] 
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteItem(Guid itemId)
        {
            async Task predicate() => await service.DeleteItem(itemId);
            var response = await SafeExecutor.ExecAsync(predicate);
            return ProcessResponse(response);
        }

        protected ActionResult ProcessResponse<T>(IAnswerBase<T> response) where T : class
        {
            if (response.Success) return Ok(response);
            else return BadRequest(response);
        }
    }
}
