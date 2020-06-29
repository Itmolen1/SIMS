using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMSApi.Model
{
    public partial class UserInformation
    {
        public UserInformation()
        {
            InverseCreatedByNavigation = new HashSet<UserInformation>();
            InverseUpdatedByNavigation = new HashSet<UserInformation>();
        }

        public int Id { get; set; }
        [StringLength(100)]
        public string UserFullName { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string UserPassword { get; set; }
        public string UserImageUrl { get; set; }
        public int UserGender { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey("CreatedBy")]
        [InverseProperty("InverseCreatedByNavigation")]
        public UserInformation CreatedByNavigation { get; set; }
        [ForeignKey("UpdatedBy")]
        [InverseProperty("InverseUpdatedByNavigation")]
        public UserInformation UpdatedByNavigation { get; set; }
        [ForeignKey("UserGender")]
        [InverseProperty("UserInformation")]
        public Gender UserGenderNavigation { get; set; }
        [InverseProperty("CreatedByNavigation")]
        public ICollection<UserInformation> InverseCreatedByNavigation { get; set; }
        [InverseProperty("UpdatedByNavigation")]
        public ICollection<UserInformation> InverseUpdatedByNavigation { get; set; }
    }
}
