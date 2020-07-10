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
    /// This is Owner Controller class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        public IParkingManager Manager;
        public OwnerController(IParkingManager manager)
        {
            this.Manager = manager;
        }

        /// <summary>
        /// This method is created for adding parking details.
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Parkinglot")]
        public IActionResult ParkinglotDetails(Parking parking)
        {
            bool success;
            string message;
            object result;
            var res = this.Manager.ParkinglotDetails(parking);
            if (!res.Equals(null))
            {
                success = true;
                message = "Successful";
                result = Ok(new { success, message, res });
            }
            else
            {
                success = false;
                message = "Details adding can't be possible";
                return BadRequest(new { success, message });
            }
            return (IActionResult)result;
        }

        /// <summary>
        /// This method is created for getting parking details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDetail")]
        public IActionResult GetParkingDetail()
        {
            var res = this.Manager.GetParkingDetail();
            string message;
            bool success;
            object result;
            if (!res.Equals(null))
            {
                Log.Information("list is displayed");
                success = true;
                message = "Successful";
                result = Ok(new { success, message, res });
            }
            else
            {
                success = false;
                message = "List displaying can't be possible";
                return BadRequest(new { success, message });
            }
            return (IActionResult)result;
        }

        /// <summary>
        /// This method is created for getting parking parking details by parkingId.
        /// </summary>
        /// <param name="parkingId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetParkingDetailsById")]
        public IActionResult GetParkingDetailsByParkingId(int parkingId)
        {
            string message;
            bool success;
            var res = this.Manager.GetParkingDetailsByParkingId(parkingId);
            object result;
            if (!res.Equals(null))
            {
                Log.Information("list is displayed");
                success = true;
                message = "Successful";
                result = Ok(new { success, message, res });
            }
            else
            {
                success = false;
                message = "Errors occured in getting deatils.";
                return BadRequest(new { success, message });
            }
            return (IActionResult)result;
        }

        /// <summary>
        /// This method is created is Unparking the vehicles by parkingId.
        /// </summary>
        /// <param name="parkingID"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UnParking")]
        public IActionResult UnParking(int parkingID)
        {
            string message;
            bool success;
            var res = this.Manager.UnParking(parkingID);
            object result;
            if(!res.Equals(null))
            {
                success = true;
                message = "Successful";
                result = Ok(new { success, message, res });
            }
            else
            {
                success = false;
                message = "Vehciles can't be parked getting some errors.";
                return BadRequest(new { success, message });
            }
            return (IActionResult)result;
        }
    }
}