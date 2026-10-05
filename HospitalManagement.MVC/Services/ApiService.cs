using System.Net.Http;
using System.Net.Http.Headers;
using HospitalManagement.Library.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using HospitalManagement.MVC.Models;
using System.Reflection.Metadata.Ecma335;


namespace HospitalManagement.MVC.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public string Password { get; private set; }

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7280/api/");
        }

        public async Task<bool> AddPatientAsync(Patient patient)
        {
            HttpResponseMessage response =
                await _httpClient.PostAsJsonAsync("Patient", patient);

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Patient");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Patient>>() ?? Enumerable.Empty<Patient>();
            }

            return Enumerable.Empty<Patient>();
        }


        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"Patient/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Patient>();
            }

            return null;
        }

        public async Task<bool> UpdatePatientAsync (Patient patient)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("Patient", patient);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePatientAsync (int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"Patient/{id}");

            return response.IsSuccessStatusCode;
        }


        public async Task<bool> AddDoctorAsync(Doctor doctor)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("Doctor", doctor);

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Doctor");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Doctor>>() ?? Enumerable.Empty<Doctor>();
            }

            return Enumerable.Empty<Doctor>();
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"Doctor/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Doctor>();
            }
            return null;
        }


        public async Task<bool> UpdateDoctorAsync(Doctor doctor)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("Doctor", doctor);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"Doctor/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddAppointmentAsync(Appointment appointment)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("Appointment", appointment);

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Appointment");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Appointment>>() ?? Enumerable.Empty<Appointment>();
            }

            return Enumerable.Empty<Appointment>();

        }

        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"Appointment/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Appointment>();
            }

            return null;
        }

        public async Task<bool> UpdateAppointmentAsync(Appointment appointment)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("Appointment", appointment);

            return response.IsSuccessStatusCode;
        }


        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"Appointment/{id}");

            return response.IsSuccessStatusCode;
        }


        public async Task<LoginResponse?> LoginAsync(string username, string password)
        {
            var loginRequest = new
            {
                Username = username,
                Password = password
            };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("User/login", loginRequest);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginResponse>();
            }

            return null;
        }

        public async Task<IEnumerable<Patient>> SearchPatientAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Enumerable.Empty<Patient>();
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"Patient/search?searchTerm={Uri.EscapeDataString(searchTerm)}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Patient>>() ?? Enumerable.Empty<Patient>();
            }

            return Enumerable.Empty<Patient>();
        }

        public async Task<IEnumerable<Doctor>> SearchDoctorAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Enumerable.Empty<Doctor>();
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"Doctor/search?searchTerm={Uri.EscapeDataString(searchTerm)}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Doctor>>() ?? Enumerable.Empty<Doctor>();
            }

            return Enumerable.Empty<Doctor>();

        }

        public async Task<IEnumerable<SearchResult>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Enumerable.Empty<SearchResult>();

            }

            HttpResponseMessage response = await _httpClient.GetAsync($"Search?searchTerm={Uri.EscapeDataString(searchTerm)}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SearchResult>>() ?? Enumerable.Empty<SearchResult>();
            }

            return Enumerable.Empty<SearchResult>();
        }


    }
}
                                            