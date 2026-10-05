using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagement.Library.Models;


namespace HospitalManagement.Library.Interfaces.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchResult>> SearchAsync(string searchTerm);
    }
}