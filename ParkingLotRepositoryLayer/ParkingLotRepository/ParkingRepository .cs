using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using ParkingLotModelLayer;
using ParkingLotRepositoryLayer.IParkingLotRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ParkingLotRepositoryLayer.ParkingLotRepository
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly IConfiguration configuration;
        public ParkingRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<Parking> GetParkingDetail()
        {
            List<Parking> list = new List<Parking>();
            var commandText = Queries.selectquery;
            using (var _db = new OracleConnection(configuration["UserConnectionStrings:UserDbConnection"]))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Parking parking = new Parking();
                    parking.Id = Convert.ToInt32(reader["Id"]);
                    parking.ParkingSLot = Convert.ToInt32(reader["ParkingSLot"]);
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.PVehicleId = Convert.ToInt32(reader["PVehicleId"]);
                    parking.PParkingId = Convert.ToInt32(reader["PParkingId"]);
                    parking.PRoleId = Convert.ToInt32(reader["PRoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                }
                _db.Close();
                return list;
            }
        }

        public IEnumerable<Parking> GetParkingDetailsById(int parkingId)
        {
            List<Parking> list = new List<Parking>();
            var commandText = "Select * from PARKINGLOTAPI.Parking where Id=" + parkingId + "";
            using (var _db = new OracleConnection(configuration["UserConnectionStrings:UserDbConnection"]))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Parking parking = new Parking();
                    parking.Id = Convert.ToInt32(reader["Id"]);
                    parking.ParkingSLot = Convert.ToInt32(reader["ParkingSLot"]);
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.PVehicleId = Convert.ToInt32(reader["PVehicleId"]);
                    parking.PParkingId = Convert.ToInt32(reader["PParkingId"]);
                    parking.PRoleId = Convert.ToInt32(reader["PRoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                }
                _db.Close();
                return list;
            }
        }

        public IEnumerable<Parking> GetParkingDetailsByNum(String Vehiclenum)
        {
            List<Parking> list = new List<Parking>();
            var commandText = "Select * from PARKINGLOTAPI.Parking where VehicleNumber=" + Vehiclenum + "";
            using (var _db = new OracleConnection(configuration["UserConnectionStrings:UserDbConnection"]))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Parking parking = new Parking();
                    parking.Id = Convert.ToInt32(reader["Id"]);
                    parking.ParkingSLot = Convert.ToInt32(reader["ParkingSLot"]);
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.PVehicleId = Convert.ToInt32(reader["PVehicleId"]);
                    parking.PParkingId = Convert.ToInt32(reader["PParkingId"]);
                    parking.PRoleId = Convert.ToInt32(reader["PRoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                }
                _db.Close();
                return list;
            }
        }

        public IEnumerable<Parking> GetParkingDetailsByVehicleType(int VehicleType)
        {
            List<Parking> list = new List<Parking>();
            var commandText = "Select * from PARKINGLOTAPI.Parking where PVehicleId=" + VehicleType + "";
            using (var _db = new OracleConnection(configuration["UserConnectionStrings:UserDbConnection"]))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Parking parking = new Parking();
                    parking.Id = Convert.ToInt32(reader["Id"]);
                    parking.ParkingSLot = Convert.ToInt32(reader["ParkingSLot"]);
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.PVehicleId = Convert.ToInt32(reader["PVehicleId"]);
                    parking.PParkingId = Convert.ToInt32(reader["PParkingId"]);
                    parking.PRoleId = Convert.ToInt32(reader["PRoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                }
                _db.Close();
                return list;
            }
        }

        public object ParkinglotDetails(Parking parking)
        {
            var commandText = Queries.insertParkingDetailsQuery;
            using (var _db = new OracleConnection(configuration["UserConnectionStrings:UserDbConnection"]))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                cmd.Parameters.Add("Id", parking.Id);
                cmd.Parameters.Add("ParkingSLot", parking.ParkingSLot);
                cmd.Parameters.Add("VehicleNumber", parking.VehicleNumber);
                cmd.Parameters.Add("EntryTime", parking.EntryTime);
                cmd.Parameters.Add("PVehicleId", parking.PVehicleId);
                cmd.Parameters.Add("PParkingId", parking.PParkingId);
                cmd.Parameters.Add("PRoleId", parking.PRoleId);
                cmd.Parameters.Add("Disabled", parking.Disabled);
                cmd.Parameters.Add("ExitTime", parking.ExitTime);
                _db.Open();
                cmd.ExecuteNonQuery();
                _db.Close();
                return "sucessfull added";
            }
        }

        public object UnParking(int parkingID)
        {
            var commandText = "UPDATE PARKINGLOTAPI.Parking SET Disabled = 'TRUE',ExitTime=current_timestamp WHERE ID=" + parkingID + "";
            using (var _db = new OracleConnection(configuration["UserConnectionStrings:UserDbConnection"]))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                _db.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("Disabled", "True");
                cmd.Parameters.Add("ExitTime", "current_timestamp");
                cmd.ExecuteNonQuery();
                _db.Close();
            }

            List<Parking> list = new List<Parking>();
            Parking parking = new Parking();
            var commandTexts = "Select * from PARKINGLOT.Parking where Id=" + parkingID + "";
            using (var _db = new OracleConnection(configuration["UserConnectionStrings:UserDbConnection"]))
            using (OracleCommand cmd = new OracleCommand(commandTexts, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    parking.Id = Convert.ToInt32(reader["Id"]);
                    parking.ParkingSLot = Convert.ToInt32(reader["ParkingSLot"]);
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.PVehicleId = Convert.ToInt32(reader["PVehicleId"]);
                    parking.PParkingId = Convert.ToInt32(reader["PParkingId"]);
                    parking.PRoleId = Convert.ToInt32(reader["PRoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                }
                _db.Close();
            }
            Roles roles = new Roles();
            System.TimeSpan diff = parking.ExitTime.Subtract(parking.EntryTime);
            var differenceInTime = diff.TotalHours;
            List<Roles> list1 = new List<Roles>();
            var Charges = "Select Charges from Roles where RolesId =" + parking.PRoleId + "";
            using (var _db = new OracleConnection(configuration["UserConnectionStrings:UserDbConnection"]))
            using (OracleCommand cmd = new OracleCommand(Charges, _db))
            {
                cmd.Connection = _db;
                cmd.CommandType = CommandType.Text;
                _db.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    roles.RolesId = Convert.ToInt32(reader["RolesId"]);
                    roles.Role = reader["Role"].ToString();
                    roles.Charges = Convert.ToInt32(reader["Charges"]);
                    list1.Add(roles);
                }
                _db.Close();
                if (differenceInTime <= 1)
                {
                    return Charges;
                }
                else
                {
                    return Math.Round(Convert.ToDouble(Charges) * differenceInTime);
                }
            }
        }
    }
}
