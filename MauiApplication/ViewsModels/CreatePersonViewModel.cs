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

        //Commands
        IAsyncRelayCommand SavePersonCommand { get; }
        IRelayCommand<Guid> RemovePersonCommand { get; }

        IRelayCommand ClearInputsCommand { get; }
    }


    public partial class CreatePersonViewModel:BaseViewModel, ICreatePersonViewModel
    {
        private readonly IPersonsService _personsService;

        public CreatePersonViewModel(IPersonsService personsService)
        {
            _personsService = personsService;
            Person = new();
        }

        #region Fields For Properties

        /*Community ToolKit Will Generate Properties for that Fields*/

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasPerson))]
        private Person _person;

        #endregion

        #region Manual Properties

        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        public bool HasPerson => Person != null;

        #endregion

        #region Fields For Commands

        /*Community ToolKit Will Generate Commands for that Fields*/

        [RelayCommand]
        private async Task SavePerson()
        {
            //Validate Data
            if (string.IsNullOrEmpty(Person.FirstName))
                return;
            
            //Save Data
            _personsService.AddPerson(Person);

            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async void RemovePerson(Guid personId)
        {
            try
            {
                _personsService.RemovePerson(personId);

                await Application.Current?.MainPage?.DisplayAlert("Delete", "Person Deleted", "ok")!;
            }
            catch (Exception e)
            {
                await Application.Current?.MainPage?.DisplayAlert("Error", e.Message, "ok")!;
            }
        }

        [RelayCommand]
        private async void ClearInputs()
        {
            try
            {
                Person=new ();
            }
            catch (Exception e)
            {
                await Application.Current?.MainPage?.DisplayAlert("Error", e.Message, "ok")!;
            }
        }

        #endregion



    }
}
