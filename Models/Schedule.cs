using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace FinalProjectENTPROG.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }

        public int Admin { get; set; }

        [Required(ErrorMessage = "Required.")]
        public Location Location { get; set; }

        [Display(Name = "Date & Time")]
        public DateTime? Date { get; set; }

        [Display(Name ="Slots")]
        [Range (1, 3, ErrorMessage = "Maximum number of slots has been reached")]
        public int? Slots { get; set; }

        public virtual ApplicationUser ScheduledUser { get; set; }

        public string Id { get; set; }
    }

    public enum Location {
        TestLocation1 = 1,
        TestLocation2 = 2
    }
}
