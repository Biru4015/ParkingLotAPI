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
        MSMQ msmq = new MSMQ();

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
        public IActionResult ParkinglotDetails(Parking parking)
        {
            string message;
            var res = this.Manager.ParkinglotDetails(parking);
            try
            {
                if (!res.Equals(null))
                {
                    message = "Successful";
                    msmq.SendMessage("Vehcile number " + parking.VehicleNumber + " Parking is done.", res);
                    return this.Ok(new { message, res });
                }
                message = "Details adding can't be possible";
                return BadRequest(new { message });
            }
            catch(CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }

        /// <summary>
        /// This me
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetParkingDetailsByColor")]
        public IActionResult GetParkingDetailsByColor(string color)
        {
            string message;
            var res = this.Manager.GetParkingDetailsByColor(color);
            try
            {
                if (!res.Equals(null))
                {
                    Log.Information("list is displayed");
                    message = "Successful";
                    return this.Ok(new { message, res });
                }
                message = "List of details can't be possible to show ,something went wrong.";
                return BadRequest(new { message });
            }
            catch(CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }

        /// <summary>
        /// This method is  created for getting parking details by vehicle number.
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
                message = "List of details can't be possible to show ,something went wrong.";
                return BadRequest(new { message });
            }
            catch(CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
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
            var res = this.Manager.GetParkingDetailsByVehicleType(VehicleType);
            try
            {
                if (!res.Equals(null))
                {
                    Log.Information("list is displayed");
                    message = "Successful";
                    return this.Ok(new { message, res });
                }
                message = "List of details can't be possible to show ,something went wrong.";
                return BadRequest(new { message });
            }
            catch(CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }
    }
}