using System.Collections.ObjectModel;
using MauiApplication.Models;
using MauiApplication.Services.Abstract;

namespace MauiApplication.Services
{
    public interface IPersonsService
    {
        Person GetById(Guid personId);
        ObservableCollection<Person> GetPersons();
        void AddPerson(Person person);
        void UpdatePerson(Person person);
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
            _persons = new(new List<Person>()
            {
                new Person{Id = Guid.NewGuid(),Email= "mail@gmail.com",FirstName = "Ahmed",LastName = "Ali",Mobile = "01234454"},
                new Person{Id = Guid.NewGuid(),Email= "mail@gmail.com",FirstName = "mona",LastName = "mido",Mobile = "01234454"},
                new Person{Id = Guid.NewGuid(),Email= "mail@gmail.com",FirstName = "maged",LastName = "abo ali",Mobile = "01234454"},
                new Person{Id = Guid.NewGuid(),Email= "mail@gmail.com",FirstName = "kalid",LastName = "mostafa",Mobile = "01234454"},
                new Person{Id = Guid.NewGuid(),Email= "mail@gmail.com",FirstName = "hoda",LastName = "kalid",Mobile = "01234454"},
            });
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

        public Person GetById(Guid personId)
        {
            return _persons.FirstOrDefault(c => c.Id == personId);
        }

        public void AddPerson(Person person)
        {
            person.Id = Guid.NewGuid();

            _persons.Add(person);
        }
        public void UpdatePerson(Person person)
        {
            //Get Person for Update
            var oldPerson = _persons.FirstOrDefault(c=>c.Id==person.Id);

            if (oldPerson != null)
            {
                oldPerson.Email = person.Email;
                oldPerson.FirstName = person.FirstName; 
                oldPerson.LastName = person.LastName;
                oldPerson.Mobile = person.Mobile;
            }
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
