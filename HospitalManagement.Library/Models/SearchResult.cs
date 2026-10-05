using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Library.Models
{
    public class SearchResult
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;
    }
}
