using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApplication.Models;
using MauiApplication.Services;
using MauiApplication.ViewsModels.Abstract;

namespace MauiApplication.ViewsModels
{
    public interface IEditPersonViewModel
    {
        //Properties

        Person Person { get; set; }

        //Commands
        IAsyncRelayCommand UpdatePersonCommand { get; }
    }

    [QueryProperty("Person", "PersonToEdit")]
    public partial class EditPersonViewModel:BaseViewModel, IEditPersonViewModel
    {
        private readonly IPersonsService _personsService;

        public EditPersonViewModel(IPersonsService personsService)
        {
            _personsService = personsService;
            //Person = new();
        }

        #region Fields For Properties

        /*Community ToolKit Will Generate Properties for that Fields*/

        [ObservableProperty]
        private Person _person;

       
        #endregion


        #region Fields For Commands

        /*Community ToolKit Will Generate Commands for that Fields*/

        [RelayCommand]
        private async Task UpdatePerson()
        {
            //Validate Data
            if (string.IsNullOrEmpty(Person.FirstName))
                return;
            
            //Save Data
            _personsService.UpdatePerson(Person);

            await Shell.Current.GoToAsync("..");
        }

        #endregion



    }
}
