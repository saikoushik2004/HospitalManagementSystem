using HospitalManagement.Library.Interfaces.Repositories;
using HospitalManagement.Library.Interfaces.Services;
using HospitalManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Library.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository _searchRepository;

        public SearchService(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        public async Task<IEnumerable<SearchResult>> SearchAsync(string searchTerm)
        {
            return await _searchRepository.SearchAsync(searchTerm);
        }
    }
}
