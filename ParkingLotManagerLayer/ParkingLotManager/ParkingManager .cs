using ParkingLotManagerLayer.IParkingLotManager;
using ParkingLotModelLayer;
using ParkingLotRepositoryLayer.IParkingLotRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagerLayer.ParkingLotManager
{
    /// <summary>
    /// This class contains the code of manager layer.
    /// </summary>
    public class ParkingManager : IParkingManager
    {
        /// <summary>
        /// Calling  IParkingRepository class
        /// </summary>
        private readonly IParkingRepository Parking;

        /// <summary>
        /// This is paramter constructor.
        /// </summary>
        /// <param name="Parking"></param>
        public ParkingManager(IParkingRepository Parking)
        {
            this.Parking = Parking;
        }

        public object GetParkingDetail()
        {
            return this.Parking.GetParkingDetail();
        }

        public object GetParkingDetailsByColor(String color)
        {
            return this.Parking.GetParkingDetailsByColor(color);
        }

        public object GetParkingDetailsByParkingId(int parkingId)
        {
            return this.Parking.GetParkingDetailsByParkingId(parkingId);
        }

        public object GetParkingDetailsByNum(String Vehiclenum)
        {
            return this.Parking.GetParkingDetailsByNum(Vehiclenum);
        }

        public object GetParkingDetailsByVehicleType(int VehicleType)
        {
            return this.Parking.GetParkingDetailsByVehicleType(VehicleType);
        }

        public object ParkinglotDetails(Parking parking)
        {
            return this.Parking.ParkinglotDetails(parking);
        }

        public object UnParking(int parkingID)
        {
            return this.Parking.UnParking(parkingID);
        }

        public object ListOfVacantSlot()
        {
            return this.Parking.ListOfVacantSlot();
        }

        public object SlotIsEmptyOrNot()
        {
            return this.Parking.SlotIsEmptyOrNot();
        }
    }
}
