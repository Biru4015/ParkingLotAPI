using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagerLayer.IParkingLotManager
{
    public interface IParkingManager
    {
        object GetParkingDetail();
        object GetParkingDetailsByColor(string color);
        object GetParkingDetailsByParkingId(int parkingId);
        object GetParkingDetailsByNum(string Vehiclenum);
        object GetParkingDetailsByVehicleType(int VehicleType);
        object ParkinglotDetails(Parking parking);
        object UnParking(int parkingID);
        object ListOfVacantSlot();

        object SlotIsEmptyOrNot();
    }
}
