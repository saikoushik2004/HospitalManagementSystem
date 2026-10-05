using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HospitalManagement.Library.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [Required]
        [RegularExpression(@"^(?i:pat)\d+$", ErrorMessage = "Patient Number must start with 'PAT' followed by numbers.")]
        public string PatientNumber { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Full Name should contain only letters and spaces.")]
        public string FullName { get; set; } = string.Empty;

        [Required]

        public string Gender { get; set; } = string.Empty;

        [Required]
        [Range(0,100, ErrorMessage ="Age must be between 0 to 100")]
        public int Age { get; set; }
        [Required]

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must contain exactly 10 digits.")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string? Address { get; set; }

        public DateTime CreatedDate { get; set; }

    }

}
