using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ParkingLotRepositoryLayer.DatabaseConnection
{
    /// <summary>
    /// This class contains the code of connection with oracle database
    /// </summary>
    public class Connection
    {
        private readonly IConfiguration configuration;
        public Connection(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        /// <summary>
        /// This method is created for connecting with database
        /// </summary>
        public void Connections()
        {
            using (var _db = new OracleConnection(configuration["UserConnectionStrings:UserDbConnection"]))
            { 
                _db.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = _db;
                cmd.CommandText =
                "begin " +
                " execute immediate 'create table PARKINGLOTAPIS.UserType(UserId int NOT NULL PRIMARY KEY ,Email varchar2(20) not null,Password varchar2(20) not null ,Role varchar2(20) not null)';" +
                " execute immediate 'create table PARKINGLOTAPIS.VehicleType(VehicleId int NOT NULL PRIMARY KEY,VehicleTypes varchar2(20) not null ,Charges FLOAT(8))';" +
                " execute immediate 'create table PARKINGLOTAPIS.ParkingType(ParkingId int NOT NULL PRIMARY KEY ,ParkingTypes varchar2(20) not null ,Charges FLOAT(8))';" +
                " execute immediate 'create table PARKINGLOTAPIS.Roles(RolesId int NOT NULL PRIMARY KEY ,Role varchar2(20) not null ,Charges FLOAT(8))';" +
                " execute immediate 'create table PARKINGLOTAPIS.Parking(Id int NOT NULL PRIMARY KEY ,ParkingSLot varchar2(20) NOT NULL,VehicleNumber varchar2(20) NOT NULL," +
                " EntryTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP, VehicleId int ,ParkingId int ,RoleId ,FOREIGN KEY(VehicleId) REFERENCES VehicleType(VehicleId), FOREIGN KEY(ParkingId) REFERENCES ParkingType(ParkingId) ,FOREIGN KEY(RoleId ) REFERENCES Roles(RolesId))';" +
                " execute immediate 'insert into PARKINGLOTAPIS.VehicleType(VehicleId,VehicleTypes,Charges) values(001 ,'CAR' ,80.0)';" +
                " execute immediate 'insert into PARKINGLOTAPIS.VehicleType(VehicleId,VehicleTypes,Charges) values(002 ,'Bike' ,300.0)';" +
                " execute immediate 'insert into PARKINGLOTAPIS.ParkingType(ParkingId,ParkingTypes,Charges) values(001 ,'Vallet' ,80.0)';" +
                " execute immediate 'insert into PARKINGLOTAPIS.ParkingType(ParkingId,ParkingTypes,Charges) values(002 ,'Own',30.0)';" +
                " execute immediate 'insert into PARKINGLOTAPIS.Roles(RolesId,Role,Charges) values(001 ,'DRIVER' ,200.0)';" +
                " execute immediate 'insert into PARKINGLOTAPIS.Roles(RolesId,Role,Charges) values(002 ,'POLICE' ,50.0)';" +
                " execute immediate 'insert into PARKINGLOTAPIS.Roles(RolesId,Role,Charges) values(003 ,'SECURITY' ,50.0)';" +
                " execute immediate 'insert into PARKINGLOTAPIS.Roles(RolesId,Role,Charges) values(004 ,'LOTOWNER' ,80.0)';" +
                "end;";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                _db.Close();
            }
        }
    }
}
