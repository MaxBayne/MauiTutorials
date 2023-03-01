using System.Collections.ObjectModel;
using MauiApplication.Models;
using MauiApplication.Services.Abstract;

namespace MauiApplication.Services
{
    public interface IPersonsService
    {
        ObservableCollection<Person> GetPersons();
        void AddPerson(Person person);
        void RemovePerson(Guid id);
        void RemovePerson(Person person);
    }

    public class PersonsService:BaseService, IPersonsService
    {
        //private List<Person> _persons;
        //private readonly HttpClient _httpClient;
        private ObservableCollection<Person> _persons;

        public PersonsService()
        {
            _persons = new();
            //_httpClient=new HttpClient();
        }

        public ObservableCollection<Person> GetPersons()
        {
            //if (_persons.Count > 0)
            //    return _persons;

            ////Make HttpGet Request over Api
            //var response = await _httpClient.GetAsync("http://www.google.com/persons");

            //if (response.IsSuccessStatusCode)
            //{
            //    _persons = await response.Content.ReadFromJsonAsync<List<Person>>();
            //}

            return _persons;
        }

        public void AddPerson(Person person)
        {
            person.Id = Guid.NewGuid();

            _persons.Add(person);
        }

        public void RemovePerson(Guid id)
        {
            var findPerson = _persons.FirstOrDefault(c => c.Id == id);

            if (findPerson != null)
            {
                _persons.Remove(findPerson);
            }
        }
        public void RemovePerson(Person person)
        {
            var findPerson = _persons.FirstOrDefault(c => c.Id == person.Id);

            if (findPerson != null)
            {
                _persons.Remove(findPerson);
            }
        }
    }
}
