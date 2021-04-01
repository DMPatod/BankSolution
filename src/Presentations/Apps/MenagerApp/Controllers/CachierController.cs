using CashierManagement.Cashiers;
using CashierManagement.DomainEvents;
using CashierManagementApplicationLayer.ConnectCashier.ManagementScenarios;
using CashierManagementInfractureLayer.DatabaseContext.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MenagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CachierController : ControllerBase
    {
        private readonly IDomainMessageHandler messageHandler;
        public CachierController(IDomainMessageHandler messageHandler)
        {
            this.messageHandler = messageHandler;
        }
        [HttpPost]
        public async Task<IActionResult> Connect([FromForm] CashierDTO cashierDTO)
        {
            var connectCommand = new CashierConnectCommand(new IpAddress(cashierDTO.Address), cashierDTO?.StoredAmount ?? 0.0m);
            var cachierId = await messageHandler.SendAsync(connectCommand, CancellationToken.None);
            return StatusCode((int)HttpStatusCode.Created, cachierId);
        }
    }
}
