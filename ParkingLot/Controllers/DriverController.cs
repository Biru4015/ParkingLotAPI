using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLotManagerLayer.IParkingLotManager;
using ParkingLotModelLayer;

namespace ParkingLot.Controllers
{
    /// <summary>
    /// This is Driver controller class.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        MSMQ msmq = new MSMQ();

        public IParkingManager Manager;
        public DriverController(IParkingManager manager)
        {
            this.Manager = manager;
        }

        /// <summary>
        /// This method is created for Adding parking details.
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Parkinglot")]
        public IActionResult ParkinglotDetails(Parking parking)
        {
            string message;
            var res = this.Manager.ParkinglotDetails(parking);
            if (!res.Equals(null))
            {
                message = "Successful";
                msmq.SendMessage("UnParking vehicle charges:", res);
                return this.Ok(new { message, res });
            }
            else
            {
                message = "Can't add vehcile details something went wrong.";
                return BadRequest(new {  message });
            }
        }

        /// <summary>
        /// This method is created for unparking the vehicles by parkingId.
        /// </summary>
        /// <param name="parkingID"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UnParking")]
        public IActionResult UnParking(int parkingID)
        {
            string message;
            var res = this.Manager.UnParking(parkingID);
            if (!res.Equals(null))
            {
                message = "Successful";
                return this.Ok(new { message, res });
            }
            else
            {
                message = "Vehciles can't be parked getting some errors.";
                return BadRequest(new {  message });
            }
        }
    }
}