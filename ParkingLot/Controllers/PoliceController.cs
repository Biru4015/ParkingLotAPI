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
    /// This controller class is created for Police.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceController : ControllerBase
    {
        public IParkingManager Manager;
        public PoliceController(IParkingManager manager)
        {
            this.Manager = manager;
        }

        /// <summary>
        /// This method is created for adding parking details.
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This me
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetParkingDetailsById")]
        public IActionResult GetParkingDetailsById(int Id)
        {
            string message;
            bool success;
            var res = this.Manager.GetParkingDetailsById(Id);
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

        /// <summary>
        /// This method is  created for getting parking details by vehicle number.
        /// </summary>
        /// <param name="Vehiclenum"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This method is created for getting parking details by vehicles type.
        /// </summary>
        /// <param name="VehicleType"></param>
        /// <returns></returns>
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