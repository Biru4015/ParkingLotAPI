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
    /// <summary>
    /// This controller class contains the code of showing vacant slot of vehicles.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        public IParkingManager Manager;
        public SlotController(IParkingManager manager)
        {
            this.Manager = manager;
        }

        /// <summary>
        /// This method is created for getting list of vacant slots.
        /// </summary>
        /// <returns></returns>
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