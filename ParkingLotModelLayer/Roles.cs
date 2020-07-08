using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingLotModelLayer
{
    /// <summary>
    /// This class contains the code for roles of any person
    /// </summary>
    public class Roles
    {
        /// <summary>
        /// This is  role id
        /// </summary>
        [Required]
        public int RolesId { get; set; }
        
        /// <summary>
        /// This is role
        /// </summary>
        [Required]
        public string Role { get; set; }
        
        /// <summary>
        /// This is charges
        /// </summary>
        [Required]
        public double Charges { get; set; }
    }
}
