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
        public IActionResult ParkinglotDetails(Parking parking)
        {
            string message;
            var res = this.Manager.ParkinglotDetails(parking);
            try
            {
                if (!res.Equals(null))
                {
                    message = "Successful";
                    msmq.SendMessage("Vehcile number "+parking.VehicleNumber+" Parking is done.", res);
                    return this.Ok(new { message, res });
                }
                message = "Can't add vehcile details something went wrong.";
                return this.BadRequest(new {message });
            }
            catch(CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }

        /// <summary>
        /// This method is created for unparking the vehicles by parkingId.
        /// </summary>
        /// <param name="parkingID"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UnParking(int parkingID)
        {
            string message;
            var parkingCharge = this.Manager.UnParking(parkingID);
           try
           {
                if (!parkingCharge.Equals(null))
                {
                    msmq.SendMessage("Parking Id "+parkingID+" UnParking vehicle charges=", parkingCharge);
                    message = "Successful";
                    return this.Ok(new { message, parkingCharge });
                }
                message = "Please check again something went wrong";
                return this.BadRequest(new { message});

           }
           catch(CustomException)
           {
               return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
           }
        }
    }
}