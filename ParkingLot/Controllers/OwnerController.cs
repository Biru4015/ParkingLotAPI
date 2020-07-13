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
        MSMQ msmq = new MSMQ();

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
                message= "Details adding can't be possible"; 
                return BadRequest(new { message });
            }
            catch(CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }

        /// <summary>
        /// This method is created for getting parking details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetParkingDetail()
        {
            var res = this.Manager.GetParkingDetail();
            string message;
            try
            {
                if (!res.Equals(null))
                {
                    Log.Information("list is displayed");
                    message = "Successful";
                    return this.Ok(new { message, res });
                }
                message = "List displaying can't be possible";
                return BadRequest(new { message });
            }
            catch(CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
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
            try
            {
                if (!res.Equals(null))
                {
                    Log.Information("list is displayed");
                    success = true;
                    message = "Successful";
                    return this.Ok(new { success, message, res });
                }
                message = "Errors occured in getting deatils.";
                return BadRequest(new { message });
            }
            catch(CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }

        /// <summary>
        /// This method is created is Unparking the vehicles by parkingId.
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
                    message = "Successful";
                    msmq.SendMessage("Parking Id " + parkingID + " UnParking vehicle charges=", parkingCharge);
                    return this.Ok(new { message, parkingCharge });
                }   
                message = "Vehciles can't be parked getting some errors.";
                return BadRequest(new { message });
            }
            catch(CustomException)
            {
                return BadRequest(CustomException.ExceptionType.INVALID_INPUT);
            }
        }
    }
}