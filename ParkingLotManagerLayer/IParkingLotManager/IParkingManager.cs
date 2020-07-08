using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagerLayer.IParkingLotManager
{
    public interface IParkingManager
    {
        object GetParkingDetail();
        object GetParkingDetailsById(int parkingId);
        object GetParkingDetailsByNum(String Vehiclenum);
        object GetParkingDetailsByVehicleType(int VehicleType);
        object ParkinglotDetails(Parking parking);
        object UnParking(int parkingID);
        object ListOfVacantSlot();
    }
}
