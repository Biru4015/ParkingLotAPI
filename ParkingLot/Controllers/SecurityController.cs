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
            try
            {
                if (!res.Equals(null))
                {
                    message = "Parking details is added.";
                    msmq.SendMessage("Vehcile number " + parking.VehicleNumber + " Parking is done.", res);
                    return this.Ok(new { message, res });
                }
                message = "Details adding can't be possible";
                return this.BadRequest(new { message});
            }
            catch(CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }

        /// <summary>
        /// This method is created for getting parking details by vehicles number.
        /// </summary>
        /// <param name="Vehiclenum"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetParkingDetailsByNum")]
        public IActionResult GetParkingDetailsByNum(string Vehiclenum)
        {
            string message;
            var res = this.Manager.GetParkingDetailsByNum(Vehiclenum);
            try
            {
                if (!res.Equals(null))
                {
                    Log.Information("list is displayed");
                    message = "Successful";
                    return this.Ok(new { message, res });
                }
                message = "Details can't be show,something went wrong.";
                return BadRequest(new { message });
            }
            catch(CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
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
            try
            {
                if (!res.Equals(null))
                {

                    Log.Information("list is displayed");
                    message = "Successful";
                    return this.Ok(new { message, res });
                }        
                message = "Details can't be show,something went wrong.";
                return BadRequest(new { message });
            }
            catch(CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }
    }
}