using Microsoft.AspNetCore.Mvc;
using Shop.API.Execution.Answers.Contracts;
using Shop.API.Execution;
using System.Net;
using Shop.Application.Services.Contracts;
using Shop.Domain.DTOs.Client;
using Shop.Domain.Entities;
using Shop.Domain.ViewModels;

namespace Shop.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController(IClientService service) : Controller
    {
        [HttpGet]
        [Route("ById")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetClientData(Guid clientId)
        {
            async Task<ClientViewModel> predicate() => await service.GetClientByIdAsync(clientId);
            var response = await SafeExecutor<ClientViewModel>.ExecAsync(predicate);
            return ProcessResponse(response);
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetClientData()
        {
            async Task<IEnumerable<ClientViewModel>> predicate() => await service.GetClientDataAsync();
            var response = await SafeExecutor<IEnumerable<ClientViewModel>>.ExecAsync(predicate);
            return ProcessResponse(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetClientData(ClientViewModel client)
        {
            async Task<ClientViewModel> predicate() => await service.PostClient(client);
            var response = await SafeExecutor<ClientViewModel>.ExecAsync(predicate);
            return ProcessResponse(response);
        }

        [HttpPut("{clientId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateClient([FromRoute] Guid clientId, [FromBody] ClientDTO client)
        {
             async Task<ClientViewModel> predicate() => await service.UpdateClient(clientId, client);
            var response = await SafeExecutor<ClientViewModel>.ExecAsync(predicate);
            return ProcessResponse(response);
        }

        [HttpPost]
        [Route("AddItemToClient")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddItemToShopStore(Guid clientIt, Guid itemId)
        {

            async Task<ClientViewModel> predicate() => await service.PostItemToClient(clientIt, itemId);
            var response = await SafeExecutor<ClientViewModel>.ExecAsync(predicate);
            return ProcessResponse(response);
        }


        [HttpPost]
        [Route("DeleteItemToClient")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteItemToShopStore(Guid clientIt, Guid itemId)
        {
            async Task<ClientViewModel> predicate() => await service.DeleteItemToClient(clientIt, itemId);
            var response = await  SafeExecutor < ClientViewModel > .ExecAsync(predicate);
            return ProcessResponse(response);
        }

        [HttpDelete("{clientId}")] 
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteClient(Guid clientId)
        {
            async Task predicate() => await service.DeleteClient(clientId);
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
