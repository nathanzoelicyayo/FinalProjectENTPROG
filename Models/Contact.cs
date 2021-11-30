using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectENTPROG.Models
{
    public class Contact
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string ScheduledUser { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Format.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Required field.")]
        public string Location { get; set; }

        [Display(Name = "Municipality")]
        [Required(ErrorMessage = "Required field.")]
        public string Municipality { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Required field.")]
        public string Date { get; set; }

        [Display(Name = "Time")]
        [Required(ErrorMessage = "Required field.")]
        public string Time { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

    }
}
