using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMSApi.Model
{
    public partial class Gender
    {
        public Gender()
        {
            UserInformation = new HashSet<UserInformation>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string GenderName { get; set; }

        [InverseProperty("UserGenderNavigation")]
        public ICollection<UserInformation> UserInformation { get; set; }
    }
}
