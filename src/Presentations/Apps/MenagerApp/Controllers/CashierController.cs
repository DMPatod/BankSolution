using BuildBlocks.DomainEvents;
using CashierManagement.Cashiers;
using CashierManagementApplicationLayer.ManagementScenarios.ConnectCashier;
using CashierManagementApplicationLayer.ManagementScenarios.GetCashier;
using CashierManagementInfractureLayer.DatabaseContext.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MenagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashierController : ControllerBase
    {
        private readonly IDomainMessageHandler messageHandler;
        public CashierController(IDomainMessageHandler messageHandler)
        {
            this.messageHandler = messageHandler;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var getCommand = new CashierGetCommand(id);
            var cashier = await messageHandler.SendAsync(getCommand, CancellationToken.None);
            return StatusCode((int)HttpStatusCode.OK, cashier);
        }
        [HttpPost]
        public async Task<IActionResult> Connect([FromForm] CashierDTO cashierDTO)
        {
            var address = new IpAddress(cashierDTO.Ip, cashierDTO.Port);

            var connectCommand = new CashierConnectCommand(address, cashierDTO.StoredAmount);
            var cachierId = await messageHandler.SendAsync(connectCommand, CancellationToken.None);
            return StatusCode((int)HttpStatusCode.Created, cachierId);
        }
    }
}
