using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotModelLayer
{
    public class Queries
    {
        public static string selectquery= "SELECT * FROM PARKINGLOTAPI.Parking";
        public static string insertParkingDetailsQuery= "insert into PARKINGLOTAPI.Parking(Id ,ParkingSLot ,VehicleNumber ,EntryTime ,PVehicleId ,PParkingId ,PRoleId ,Disabled ,ExitTime) values(:Id,:ParkingSLot,:VehicleNumber,:EntryTime,:PVehicleId,:PParkingId,:PRoleId,:Disabled,:ExitTime)";
    }
}
