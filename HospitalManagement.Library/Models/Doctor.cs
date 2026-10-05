using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HospitalManagement.Library.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        [Required]
        [RegularExpression(@"^(?i:doc)\d+$", ErrorMessage = "Doctor Number must start with 'DOC' followed by numbers.")]
        public string DoctorNumber { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Full Name should contain only letters and spaces.")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[A-Za-z.\s]+$", ErrorMessage = "Specialization can contain only letters, spaces, and periods (.).")]
        public string Specialization { get; set; } = string.Empty;

        [Required]

        [RegularExpression(@"^\d{10}$", ErrorMessage = "PhoneNumber should be only 10 digits " )]   
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Range(100, double.MaxValue, ErrorMessage = "Consultation Fee must be at least 100.")]
        public decimal ConsultationFee { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}


