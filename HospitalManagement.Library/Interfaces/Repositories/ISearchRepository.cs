using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagement.Library.Models;

namespace HospitalManagement.Library.Interfaces.Repositories
{
    public interface ISearchRepository
    {
        Task<IEnumerable<SearchResult>> SearchAsync(string searchTerm);
    }
}
