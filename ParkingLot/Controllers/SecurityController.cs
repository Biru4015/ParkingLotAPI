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
    public class SecurityController : ControllerBase
    {
        public IParkingManager Manager;
        public SecurityController(IParkingManager manager)
        {
            this.Manager = manager;
        }

        [HttpPost]
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
                return this.BadRequest(new { error = "Details adding can't be possible" });
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
                return this.BadRequest(new { error = "Details can't be show,something went wrong." });
            }
            return (IActionResult)result;
        }

        [HttpGet]
        [Route("GetParkingDetailsByVehicleType")]
        public IActionResult GetParkingDetailsByVehicleType(int VehicleType)
        {
            var res = this.Manager.GetParkingDetailsByVehicleType(VehicleType);
            object result;
            if (!res.Equals(null))
            {
                string message;
                bool success;
                Log.Information("list is displayed");
                success = true;
                message = "Successful";
                result = Ok(new { success, message, res });
            }
            else
            {
                return this.BadRequest(new { error = "Details can't be show,something went wrong" });
            }
            return (IActionResult)result;
        }
    }
}