using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotRepositoryLayer.IParkingLotRepository
{
    public interface IParkingRepository
    {
        IEnumerable<Parking> GetDetail();
        IEnumerable<Parking> GetParkingById(int parkingId);
        IEnumerable<Parking> GetParkingByNum(String Vehiclenum);
        IEnumerable<Parking> GetParkingByVType(int VehicleType);
        object Parkinglot(Parking parking);
        object UnParking(int parkingID);
    }
}
