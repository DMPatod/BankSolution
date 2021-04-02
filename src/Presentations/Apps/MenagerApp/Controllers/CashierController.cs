using CashierManagement.Cashiers;
using CashierManagement.DomainEvents;
using CashierManagementApplicationLayer.ConnectCashier.ManagementScenarios;
using CashierManagementApplicationLayer.ManagementScenarios.GetCashier;
using CashierManagementInfractureLayer.DatabaseContext.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> Get([FromQuery] Guid guid)
        {
            var getCommand = new CashierGetCommand(guid);
            var cashier = await messageHandler.SendAsync(getCommand, CancellationToken.None);
            return StatusCode((int)HttpStatusCode.OK, cashier);
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
