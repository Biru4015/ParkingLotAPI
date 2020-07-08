using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotModelLayer
{
    /// <summary>
    /// This class contains the queries.
    /// </summary>
    public class Queries
    {
        /// <summary>
        /// Insert Query
        /// </summary>
        public static string insertParkingDetailsQuery= "insert into PARKINGLOTAPI.Parking(Id ,ParkingSLot ,VehicleNumber ,EntryTime ,VehicleId ,ParkingId ,RoleId ,Disabled ,ExitTime) values(:Id,:ParkingSLot,:VehicleNumber,:EntryTime,:VehicleId,:ParkingId,:RoleId,:Disabled,:ExitTime)";

        /// <summary>
        /// Update Query
        /// </summary>
        public static string updateByIDQuery= "UPDATE PARKINGLOTAPI.Parking SET Disabled = 'TRUE',ExitTime=current_timestamp WHERE ID=";
      
        /// <summary>
        /// Select Queries
        /// </summary>
        public static string selectquery = "SELECT * FROM PARKINGLOTAPI.Parking";
        public static string selectByIdQuery = "Select * from PARKINGLOTAPI.Parking where Id=";
        public static string selectByRoleIDQuery= "Select * from PARKINGLOTAPI.Roles where RolesId =";
        public static string selectByVehcileTypeQuery= "Select * from PARKINGLOTAPI.Parking where PVehicleId=";
        public static string selectByVehcileNumberQuery= "Select * from PARKINGLOTAPI.Parking where VehicleNumber=";
        public static string selectByParkingIDQuery= "Select * from PARKINGLOTAPI.Parking where Id=";
    }
}