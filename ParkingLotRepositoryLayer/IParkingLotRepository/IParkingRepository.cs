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

        IEnumerable<Parking> GetParkingDetailsById(int Id);

        IEnumerable<Parking> GetParkingDetailsByParkingId(int parkingId);
        
        IEnumerable<Parking> GetParkingDetailsByNum(String VehicleNumber);
        
        IEnumerable<Parking> GetParkingDetailsByVehicleType(int VehicleType);
        
        object ParkinglotDetails(Parking parking);
        
        object UnParking(int parkingID);

        object ListOfVacantSlot();
    }
}
