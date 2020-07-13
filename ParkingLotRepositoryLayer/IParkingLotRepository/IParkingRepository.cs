using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotRepositoryLayer.IParkingLotRepository
{
    /// <summary>
    /// This inertface contains the code for business layer.
    /// </summary>
    public interface IParkingRepository
    {
        
        IEnumerable<Parking> GetParkingDetail();

        IList<Parking> GetParkingDetailsByColor(string color);

        IEnumerable<Parking> GetParkingDetailsByParkingId(int parkingId);
        
        IEnumerable<Parking> GetParkingDetailsByNum(string VehicleNumber);
        
        IEnumerable<Parking> GetParkingDetailsByVehicleType(int VehicleType);
        
        object ParkinglotDetails(Parking parking);
        
        object UnParking(int parkingID);

        object ListOfVacantSlot();

        object SlotIsEmptyOrNot();
    }
}
