using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLotManagerLayer.IParkingLotManager;
using ParkingLotModelLayer;
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
        public IActionResult ListOfVacantSlot()
        {
            var res = this.Manager.ListOfVacantSlot();
            string message;
            try
            {
                if (!res.Equals(null))
                {
                    Log.Information("Vacant slot is displayed");
                    message = "Successful";
                    return this.Ok(new { message, res });
                }
                message = "Something went error.";
                return BadRequest(new { message });
            }
            catch(CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }

        [HttpGet]
        [Route("SlotIsEmptyOrNot")]
        public IActionResult SlotIsEmptyOrNot()
        {
            var res = this.Manager.SlotIsEmptyOrNot();
            string message;
            try
            {
                if (!res.Equals(null))
                {
                    Log.Information("Vacant slot is displayed");
                    message = "Successful";
                    return this.Ok(new { message, res });
                }
                message = "Something went error.";
                return BadRequest(new { message });
            }
            catch (CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }
    }
}