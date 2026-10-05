using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HospitalManagement.Library.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        [Required]
        [RegularExpression(@"^(?i:ap)\d+$", ErrorMessage = "Doctor Number must start with 'AP' followed by numbers.")]
        public string AppointmentNumber { get; set; } = string.Empty;
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [RegularExpression(@"^(Scheduled|Completed|Cancelled)$",
            ErrorMessage = "Status must be Scheduled, Completed or Cancelled.")]
        public string Status { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}
