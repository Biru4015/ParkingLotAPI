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
        [Route("ParkinglotDetails")]
        public IActionResult ParkinglotDetails(Parking parking)
        {
            string message;
            var res = this.Manager.ParkinglotDetails(parking);
            if (!res.Equals(null))
            {
                message = "Successful";
                msmq.SendMessage("UnParking vehicle charges:", res);
                return this.Ok(new {  message, res });
            }
            else
            {
                message = "Details adding can't be possible";
                return BadRequest(new { message });
            }
            
        }

        /// <summary>
        /// This me
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetParkingDetailsByColor")]
        public IActionResult GetParkingDetailsByColor(String color)
        {
            string message;
            var res = this.Manager.GetParkingDetailsByColor(color);
            if (!res.Equals(null))
            {
                Log.Information("list is displayed");
                message = "Successful";
                return this.Ok(new { message, res });
            }
            else
            {
                message = "List of details can't be possible to show ,something went wrong.";
                return BadRequest(new { message });
            }
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
            var res = this.Manager.GetParkingDetailsByNum(Vehiclenum);
            if (!res.Equals(null))
            {
                Log.Information("list is displayed");
                message = "Successful";
                return this.Ok(new {  message, res });
            }
            else
            { 
                message = "List of details can't be possible to show ,something went wrong.";
                return BadRequest(new { message });
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
            if (!res.Equals(null))
            {
                Log.Information("list is displayed");
                message = "Successful";
                return this.Ok(new { message, res });
            }
            else
            {
                message = "List of details can't be possible to show ,something went wrong.";
                return BadRequest(new { message });
            }
        }
    }
}