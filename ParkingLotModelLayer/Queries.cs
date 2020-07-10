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
        public static string insertParkingDetailsQuery= "insert into PARKINGLOTAPIS.Parking(Id ,ParkingSLot,Color,VehicleNumber ,EntryTime ,VehicleId ,ParkingId ,RoleId ,Disabled ,ExitTime) values(:Id,:ParkingSLot,:Color,:VehicleNumber,:EntryTime,:VehicleId,:ParkingId,:RoleId,:Disabled,:ExitTime)";

        /// <summary>
        /// Update Query
        /// </summary>
        public static string updateByIDQuery= "UPDATE PARKINGLOTAPIS.Parking SET Disabled = 'TRUE',ExitTime=current_timestamp WHERE ID=";
      
        /// <summary>
        /// Select Queries
        /// </summary>
        public static string selectquery = "SELECT * FROM PARKINGLOTAPIS.Parking";
        public static string selectByColorQuery = "Select * from PARKINGLOTAPIS.Parking where color=";
        public static string selectByParkingsIdQuery = "Select * from PARKINGLOTAPIS.Parking where parkingId=";
        public static string selectByRoleIDQuery= "Select * from PARKINGLOTAPIS.Roles where RolesId =";
        public static string selectByVehcileTypeQuery= "Select * from PARKINGLOTAPIS.Parking where VehicleId=";
        public static string selectByVehcileNumberQuery= "Select * from PARKINGLOTAPIS.Parking where VehicleNumber=";
        public static string selectByParkingIDQuery= "Select * from PARKINGLOTAPIS.Parking where Id=";
    }
}