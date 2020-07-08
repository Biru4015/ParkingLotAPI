using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParkingLotModelLayer
{
    /// <summary>
    /// This class contains the code for user type
    /// </summary>
    public class UserType
    {
        /// <summary>
        /// This is  user id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        /// This is user email
        /// </summary>
        [Required(ErrorMessage = "Wrong Field Name Please Write Email")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// This  is user password
        /// </summary>
        [Required(ErrorMessage = "Wrong Field Name Please Write Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// This is role  of person
        /// </summary>
        [Required(ErrorMessage = "Wrong Field Name Please Write UserType")]
        [RegularExpression(@"^LOTOWNER|^SECURITY|^POLICE|^DRIVER")]
        public string Role { get; set; }
    }
}
