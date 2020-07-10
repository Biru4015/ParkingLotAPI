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
    /// This controller class is created for Security.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        MSMQ msmq = new MSMQ();
        public IParkingManager Manager;
        public SecurityController(IParkingManager manager)
        {
            this.Manager = manager;
        }

        /// <summary>
        /// This method is created for adding parking details.
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ParkinglotDetails(Parking parking)
        {
            string message;
            var res = this.Manager.ParkinglotDetails(parking);
            object result;
            if (!res.Equals(null))
            {
                message = "Successful";
                msmq.SendMessage("UnParking vehicle charges:", res);
                result = Ok(new { message, res });
            }            
            else
            {
                return this.BadRequest(new { error = "Details adding can't be possible" });
            }
            return (IActionResult)result;
        }

        /// <summary>
        /// This method is created for getting parking details by vehicles number.
        /// </summary>
        /// <param name="Vehiclenum"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetParkingDetailsByNum")]
        public IActionResult GetParkingDetailsByNum(String Vehiclenum)
        {
            string message;
            var res = this.Manager.GetParkingDetailsByNum(Vehiclenum);
            if (!res.Equals(null))
            {
                Log.Information("list is displayed");
                message = "Successful";
                return this.Ok(new { message, res });
            }
            else
            {
                message = "Details can't be show,something went wrong.";
                return BadRequest(new { message });
            }
        }

        /// <summary>
        /// This method is created for getting vehicle details by vehicle type.
        /// </summary>
        /// <param name="VehicleType"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetParkingDetailsByVehicleType")]
        public IActionResult GetParkingDetailsByVehicleType(int VehicleType)
        {
            var res = this.Manager.GetParkingDetailsByVehicleType(VehicleType);
            string message;
            if (!res.Equals(null))
            {

                Log.Information("list is displayed");
                message = "Successful";
                return this.Ok(new { message, res });
            }
            else
            {
                message = "Details can't be show,something went wrong.";
                return BadRequest(new { message });
            }
        }
    }
}