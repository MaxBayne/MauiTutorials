using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApplication.Models;
using MauiApplication.Services;
using MauiApplication.ViewsModels.Abstract;

namespace MauiApplication.ViewsModels
{
    public interface ICreatePersonViewModel
    {
        //Properties

        Person Person { get; set; }
        ObservableCollection<Person> PersonsList { get; set; }

        //Commands
        IRelayCommand GetPersonsCommand { get; }
        IRelayCommand SavePersonCommand { get; }
        IRelayCommand<Guid> RemovePersonCommand { get; }
    }


    public partial class CreatePersonViewModel:BaseViewModel, ICreatePersonViewModel
    {
        private readonly IPersonsService _personsService;

        public CreatePersonViewModel(IPersonsService personsService)
        {
            _personsService = personsService;
            Person = new();
            PersonsList = new ();
        }

        #region Fields For Properties

        /*Community ToolKit Will Generate Properties for that Fields*/

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasPerson))]
        private Person _person;

        [ObservableProperty]
        private ObservableCollection<Person> _personsList;

        #endregion

        #region Manual Properties

        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        public bool HasPerson => Person != null;

        #endregion

        #region Fields For Commands

        /*Community ToolKit Will Generate Commands for that Fields*/

        [RelayCommand]
        private async void GetPersons()
        {
            var personsList = await _personsService.GetPersons();

            if (personsList != null)
            {
                PersonsList = new(personsList);
            }
        }

        [RelayCommand]
        private void SavePerson()
        {
            //Validate Data
            if (string.IsNullOrEmpty(Person.FirstName))
                return;

            //Generate Person Id
            Person.Id=Guid.NewGuid();

            //Store Data inside Collection
            PersonsList.Add(Person);

            //Empty Fields
            Person = new Person();
        }

        [RelayCommand]
        private async void RemovePerson(Guid personId)
        {
            try
            {
                var personToDelete = PersonsList.FirstOrDefault(c => c.Id == personId);

                if (personToDelete != null)
                {
                    PersonsList.Remove(personToDelete);

                    await Application.Current?.MainPage?.DisplayAlert("Delete", "Person Deleted", "ok")!;
                }
            }
            catch (Exception e)
            {
                await Application.Current?.MainPage?.DisplayAlert("Error", e.Message, "ok")!;
            }
            
        }

       

        #endregion


        
    }
}
