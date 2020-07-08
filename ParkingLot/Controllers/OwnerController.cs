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
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        public IParkingManager Manager;
        public OwnerController(IParkingManager manager)
        {
            this.Manager = manager;
        }

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

        [HttpGet]
        [Route("GetParkingDetailsById")]
        public IActionResult GetParkingDetailsById(int parkingId)
        {
            string message;
            bool success;
            var res = this.Manager.GetParkingDetailsById(parkingId);
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