﻿using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using ParkingLotModelLayer;
using ParkingLotRepositoryLayer.IParkingLotRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ParkingLotRepositoryLayer.ParkingLotRepository
{
    /// <summary>
    /// This class contains the code of business layer
    /// </summary>
    public class ParkingRepository : IParkingRepository
    {

        private readonly IConfiguration configuration;
        public ParkingRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        readonly List<Int32> slotList = new List<Int32>();

        /// <summary>
        /// This method is created for Adding Parking details in database
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        public object ParkinglotDetails(Parking parking)
        {

            var commandText = Queries.insertParkingDetailsQuery;
            using (var _db = new OracleConnection(configuration["UserConnectionStrings:UserDbConnection"]))
            using (OracleCommand cmd = new OracleCommand(commandText, _db))
            {
                cmd.Connection = _db;
                cmd.Parameters.Add("Id", parking.Id);
                cmd.Parameters.Add("ParkingSLot", parking.ParkingSLot);
                cmd.Parameters.Add("Color", parking.Color);
                cmd.Parameters.Add("VehicleNumber", parking.VehicleNumber);
                cmd.Parameters.Add("EntryTime", parking.EntryTime);
                cmd.Parameters.Add("VehicleId", parking.VehicleId);
                cmd.Parameters.Add("ParkingId", parking.ParkingId);
                cmd.Parameters.Add("RoleId", parking.RoleId);
                cmd.Parameters.Add("Disabled", parking.Disabled);
                cmd.Parameters.Add("ExitTime", parking.ExitTime);
                _db.Open();
                cmd.ExecuteNonQuery();
                _db.Close();
                if (slotList.Contains(parking.ParkingSLot)) { }
                slotList.Add(parking.ParkingSLot);
                return "Added successfully in database";
            }
        }
            
        /// <summary>
        /// This method is created for Adding unparking details in database
        /// </summary>
        /// <param name="parkingID"></param>
        /// <returns></returns>
        public object UnParking(int parkingID)
        {
            var commandText = Queries.updateByIDQuery + parkingID + "";
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
            var commandTexts = Queries.selectByParkingIDQuery + parkingID + "";
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
                    parking.Color = reader["Color"].ToString();
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.VehicleId = Convert.ToInt32(reader["VehicleId"]);
                    parking.ParkingId = Convert.ToInt32(reader["ParkingId"]);
                    parking.RoleId = Convert.ToInt32(reader["RoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                    slotList.Remove(parking.ParkingSLot);
                }
                _db.Close();
            }
            Roles roles = new Roles();
            System.TimeSpan diff = parking.ExitTime.Subtract(parking.EntryTime);
            var differenceInTime = diff.TotalHours;
            List<Roles> list1 = new List<Roles>();
            var Charges = Queries.selectByRoleIDQuery + parking.RoleId + "";
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
                    return roles.Charges;
                }
                return Math.Round(Convert.ToDouble(roles.Charges) * differenceInTime);
            }
        }

        /// <summary>
        /// This method is created for getting details of parking.
        /// </summary>
        /// <returns></returns>
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
                    parking.Color = reader["Color"].ToString();
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.VehicleId = Convert.ToInt32(reader["VehicleId"]);
                    parking.ParkingId = Convert.ToInt32(reader["ParkingId"]);
                    parking.RoleId = Convert.ToInt32(reader["RoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                }
                _db.Close();
                return list;
            }
        }

        /// <summary>
        /// This method is created for getting parking details by parkingId
        /// </summary>
        /// <param name="parkingId"></param>
        /// <returns></returns>
        public IList<Parking> GetParkingDetailsByColor(string color)
        {
            List<Parking> list = new List<Parking>();
            color = color.Replace('"', ' ').Trim();
            var commandText = Queries.selectByColorQuery  + "'" +color + "'";
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
                        parking.Color = reader["Color"].ToString();
                        parking.VehicleNumber = reader["VehicleNumber"].ToString();
                        parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                        parking.VehicleId = Convert.ToInt32(reader["VehicleId"]);
                        parking.ParkingId = Convert.ToInt32(reader["ParkingId"]);
                        parking.RoleId = Convert.ToInt32(reader["RoleId"]);
                        parking.Disabled = reader["Disabled"].ToString();
                        parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                        list.Add(parking);
                }         
                _db.Close();
                return list;
            }
        }

        /// <summary>
        /// This method is created for getting parking details by parkingId
        /// </summary>
        /// <param name="parkingId"></param>
        /// <returns></returns>
        public IEnumerable<Parking> GetParkingDetailsByParkingId(int parkingId)
        {
            List<Parking> list = new List<Parking>();
            var commandText = Queries.selectByParkingIDQuery + parkingId +"";
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
                    parking.Color = reader["Color"].ToString();
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.VehicleId = Convert.ToInt32(reader["VehicleId"]);
                    parking.ParkingId = Convert.ToInt32(reader["ParkingId"]);
                    parking.RoleId = Convert.ToInt32(reader["RoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                }
                _db.Close();
                return list;
            }
        }

        /// <summary>
        /// This method  is created for getting parking details by vehicle number
        /// </summary>
        /// <param name="Vehiclenum"></param>
        /// <returns></returns>
        public IEnumerable<Parking> GetParkingDetailsByNum(string Vehiclenum)
        {
            List<Parking> list = new List<Parking>();
            Vehiclenum = Vehiclenum.Replace('"', ' ').Trim();
            var commandText =Queries.selectByVehcileNumberQuery +"'"+ Vehiclenum +"'";
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
                    parking.Color = reader["Color"].ToString();
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.VehicleId = Convert.ToInt32(reader["VehicleId"]);
                    parking.ParkingId = Convert.ToInt32(reader["ParkingId"]);
                    parking.RoleId = Convert.ToInt32(reader["RoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                }
                _db.Close();
                return list;
            }
        }

        /// <summary>
        /// This method is created for getting parking details by vehicle type
        /// </summary>
        /// <param name="VehicleType"></param>
        /// <returns></returns>
        public IEnumerable<Parking> GetParkingDetailsByVehicleType(int VehicleType)
        {
            List<Parking> list = new List<Parking>();
            var commandText = Queries.selectByVehcileTypeQuery  + VehicleType + ""; 
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
                    parking.Color = reader["Color"].ToString();
                    parking.VehicleNumber = reader["VehicleNumber"].ToString();
                    parking.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    parking.VehicleId = Convert.ToInt32(reader["VehicleId"]);
                    parking.ParkingId = Convert.ToInt32(reader["ParkingId"]);
                    parking.RoleId = Convert.ToInt32(reader["RoleId"]);
                    parking.Disabled = reader["Disabled"].ToString();
                    parking.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                    list.Add(parking);
                }
                _db.Close();
                return list;
            }
        }
        
        /// <summary>
        /// This method is  created for getting list of vacant slot.
        /// </summary>
        /// <returns></returns>
        public object ListOfVacantSlot()
        {
            for(int slot=1;slot<=400;slot++)
            {
                if (slotList.Contains(slot)) { }
                slotList.Add(slot);
            }
            return slotList;
        }

        /// <summary>
        /// This method is created for showing slot is empty or not
        /// </summary>
        /// <returns></returns>
        public object SlotIsEmptyOrNot()
        {
            if (slotList.Capacity > 0)
                return "Slot is not empty";
            else
                return "Slot is empty";
        }
    }
}
