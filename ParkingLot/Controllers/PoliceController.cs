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
    public class PoliceController : ControllerBase
    {
        public IParkingManager Manager;
        public PoliceController(IParkingManager manager)
        {
            this.Manager = manager;
        }

        [HttpPost]
        [Route("ParkinglotDetails")]
        public IActionResult ParkinglotDetails(Parking parking)
        {
            string message;
            bool success;
            var res = this.Manager.ParkinglotDetails(parking);
            object result;
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
        [Route("GetParkingDetailsByNum")]
        public IActionResult GetParkingDetailsByNum(String Vehiclenum)
        {
            string message;
            bool success;
            var res = this.Manager.GetParkingDetailsByNum(Vehiclenum);
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
                message = "List of details can't be possible to show ,something went wrong.";
                return BadRequest(new { success, message });
            }
            return (IActionResult)result;
        }

        [HttpGet]
        [Route("GetParkingDetailsByVehicleType")]
        public IActionResult GetParkingDetailsByVehicleType(int VehicleType)
        {
            string message;
            bool success;
            var res = this.Manager.GetParkingDetailsByVehicleType(VehicleType);
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
                message = "List of details can't be possible to show ,something went wrong.";
                return BadRequest(new { success, message });
            }
            return (IActionResult)result;
        }
    }
}