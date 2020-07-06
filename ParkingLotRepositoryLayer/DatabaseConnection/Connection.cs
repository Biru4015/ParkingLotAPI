using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ParkingLotRepositoryLayer.DatabaseConnection
{
    public class Connection
    {
        public void Connections()
        {
            Console.WriteLine("Starting.\r\n");
            using (var _db = new OracleConnection("User Id=system;Password=system;Data Source=localhost:1521/xe"))
            {
                Console.WriteLine("Open connection...");
                _db.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = _db;
                cmd.CommandText =
                "begin " +
                " execute immediate 'create table PARKINGLOTAPI.UserType(UserId int NOT NULL PRIMARY KEY ,Email varchar2(20) not null,Password varchar2(20) not null ,Role varchar2(20) not null)';" +
                " execute immediate 'create table PARKINGLOTAPI.VehicleType(VehicleId int NOT NULL PRIMARY KEY,VehicleTypes varchar2(20) not null ,Charges FLOAT(8))';" +
                " execute immediate 'create table PARKINGLOTAPI.ParkingType(ParkingId int NOT NULL PRIMARY KEY ,ParkingTypes varchar2(20) not null ,Charges FLOAT(8))';" +
                " execute immediate 'create table PARKINGLOTAPI.Roles(RolesId int NOT NULL PRIMARY KEY ,Role varchar2(20) not null ,Charges FLOAT(8))';" +
                " execute immediate 'create table PARKINGLOT.Parking(Id int NOT NULL PRIMARY KEY ,ParkingSLot varchar2(20) NOT NULL,VehicleNumber varchar2(20) NOT NULL, EntryTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP, PVehicleId int ,PParkingId int ,PRoleId ,FOREIGN KEY(PVehicleId) REFERENCES VehicleType(VehicleId), FOREIGN KEY(PParkingId) REFERENCES ParkingType(ParkingId) ,FOREIGN KEY(PRoleId ) REFERENCES Roles(RolesId))';" +
                " execute immediate 'insert into PARKINGLOTAPI.VehicleType(VehicleId,VehicleTypes,Charges) values(001 ,'CAR' ,100.0)';" +
                " execute immediate 'insert into PARKINGLOTAPI.VehicleType(VehicleId,VehicleTypes,Charges) values(002 ,Bike ,50.0)';" +
                " execute immediate 'insert into PARKINGLOTAPI.ParkingType(ParkingId,ParkingTypes,Charges) values(001 ,Vallet ,100.0)';" +
                " execute immediate 'insert into PARKINGLOTAPI.ParkingType(ParkingId,ParkingTypes,Charges) values(002 ,Own ,50.0)';" +
                " execute immediate 'insert into PARKINGLOTAPI.Roles(RolesId,Role,Charges) values(001 ,DRIVER ,100.0)';" +
                " execute immediate 'insert into PARKINGLOTAPI.Roles(RolesId,Role,Charges) values(002 ,POLICE ,30.0)';" +
                " execute immediate 'insert into PARKINGLOTAPI.Roles(RolesId,Role,Charges) values(003 ,SECURITY ,30.0)';" +
                " execute immediate 'insert into PARKINGLOTAPI.Roles(RolesId,Role,Charges) values(004 ,LOTOWNER ,50.0)';" +
                "end;";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                _db.Close();
            }
        }
    }
}
