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
        public int? ScheduleID { get; set; }

        public int? Admin { get; set; }

        [Required(ErrorMessage = "Required.")]
        public Location Location { get; set; }

        [Required(ErrorMessage = "Required.")]
        public Municipality Municipality { get; set; }

        [Display(Name = "Date & Time")]
        public DateTime? Date { get; set; }

        [Display(Name ="Slots")]
        [Range (1, 3, ErrorMessage = "Maximum number of slots has been reached")]
        public int? Slots { get; set; }

        public virtual ApplicationUser ScheduledUser{ get; set; }

        public string Id { get; set; }
    }

    public enum Location {
        ManilaCity = 1,
        QuezonCity = 2
    }

    public enum Municipality
    {
        Tondo = 1,
        Sampaloc = 2,
        Ermita = 3,
        Malate = 4,
        Paco = 5,
        Diliman = 6,
        Novaliches = 7
    }
}
