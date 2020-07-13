using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParkingLotModelLayer
{
    /// <summary>
    /// This class contains the details of parking.
    /// </summary>
    public class Parking
    {
        /// <summary>
        /// This is id for parking person
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// This  is parking slot.
        /// </summary>
        [Required]
        public int ParkingSLot { get; set; }

        /// <summary>
        /// This is vehicle color
        /// </summary>
        [Required]
        public string Color { get; set; }

        /// <summary>
        /// This is vehicle number
        /// </summary>
        [Required]
        public string VehicleNumber { get; set; }

        /// <summary>
        /// This is entry time of vehicles
        /// </summary>
        [Required]
        public DateTime EntryTime { get; set; }

        /// <summary>
        /// Vehicle id
        /// </summary>
        [Required]
        public int VehicleId { get; set; }

        /// <summary>
        /// Parking id
        /// </summary>
        [Required]
        public int ParkingId { get; set; }

        /// <summary>
        /// This is person roleid
        /// </summary>
        [Required]
        public int RoleId { get; set; }

        /// <summary>
        /// This  is  vehicles disabled
        /// </summary>
        public string Disabled { get; set; }
        
        /// <summary>
        /// This is entry time
        /// </summary>
        public DateTime ExitTime { get; set; }
    }
}
