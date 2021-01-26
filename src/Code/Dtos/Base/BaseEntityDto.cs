using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ark.Iskools.Dtos
{
    public partial class BaseEntityDto : IBaseEntityDto
    {
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Is Selected")]
        public bool IsSelected { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Is Visible")]
        public bool IsVisible { get; set; } = true;

        [ScaffoldColumn(false)]
        [Display(Name = "Last Activity User")]
        [MaxLength(50), StringLength(50, ErrorMessage = "The Last Activity User must be a string with a maximum length of 50 characters.")]
        public string LastActivityUser { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [Display(Name = "Last Activity DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss}")]
        public DateTime? LastActivityDateTime { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Insert User")]
        [MaxLength(50), StringLength(50, ErrorMessage = "The Insert User must be a string with a maximum length of 50 characters.")]
        public string InsertUser { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [Display(Name = "Insert DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss}")]
        public DateTime? InsertDateTime { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Update User")]
        [MaxLength(50), StringLength(50, ErrorMessage = "The Update User must be a string with a maximum length of 50 characters.")]
        public string UpdateUser { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [Display(Name = "Update DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss}")]
        public DateTime? UpdateDateTime { get; set; }

        [ScaffoldColumn(false)]
        [Timestamp]
        public byte[] Version { get; set; }

        public virtual void SetActivityTracker(string username)
        {
            this.LastActivityUser = username;
            this.LastActivityDateTime = DateTime.UtcNow;
        }

        public virtual void ActivityTracker(string username)
        {
            this.LastActivityUser = username;
            this.LastActivityDateTime = DateTime.UtcNow;
        }

        public virtual void AddTracker(string username)
        {
            this.InsertUser = username;
            this.InsertDateTime = DateTime.UtcNow;

            ActivityTracker(username);
        }

        public virtual void EditTracker(string username)
        {
            this.UpdateUser = username;
            this.UpdateDateTime = DateTime.UtcNow;

            ActivityTracker(username);
        }
    }
}
