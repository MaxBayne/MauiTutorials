using System.Net.Http.Json;
using MauiApplication.Models;
using MauiApplication.Services.Abstract;

namespace MauiApplication.Services
{
    public interface IPersonsService
    {
        Task<List<Person>> GetPersons();
    }

    public class PersonsService:BaseService, IPersonsService
    {
        private List<Person> _persons;
        private readonly HttpClient _httpClient;

        public PersonsService()
        {
            _persons = new();
            _httpClient=new HttpClient();
        }

        public async Task<List<Person>> GetPersons()
        {
            if (_persons.Count > 0)
                return _persons;

            //Make HttpGet Request over Api
            var response = await _httpClient.GetAsync("http://www.google.com/persons");

            if (response.IsSuccessStatusCode)
            {
                _persons = await response.Content.ReadFromJsonAsync<List<Person>>();
            }

            return _persons;
        }
    }
}
