using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLotManagerLayer.IParkingLotManager;
using Serilog;

namespace ParkingLot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        public IParkingManager Manager;
        public SlotController(IParkingManager manager)
        {
            this.Manager = manager;
        }
        [HttpGet]
        [Route("ListOfVacantSlot")]
        public IActionResult ListOfVacantSlot()
        {
            var res = this.Manager.ListOfVacantSlot();
            string message;
            bool success;
            object result;
            if (!res.Equals(null))
            {
                Log.Information("Vacant slot is displayed");
                success = true;
                message = "Successful";
                result= Ok(new { success, message, res });
            }
            else
            {
                success = false;
                message = "Vacant slot can't by by displayed";
                return BadRequest(new { success, message });
            }
            return (IActionResult)result;
        }
    }
}