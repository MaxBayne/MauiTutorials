using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApplication.Models;
using MauiApplication.Services;
using MauiApplication.Views.Pages;
using MauiApplication.ViewsModels.Abstract;


namespace MauiApplication.ViewsModels
{
    public interface IPersonsViewModel
    {
        //Properties

        ObservableCollection<Person> PersonsList { get; set; }

        //Commands
        
        IRelayCommand<Guid> RemovePersonCommand { get; }

        IAsyncRelayCommand NavigateToCreatePersonPageCommand { get; }
    }



    public partial class PersonsViewModel : BaseViewModel, IPersonsViewModel
    {
        public PersonsViewModel(IPersonsService personsService)
        {
            PersonsList = personsService.GetPersons();
        }

        #region Fields For Properties

        /*Community ToolKit Will Generate Properties for that Fields*/

        [ObservableProperty]
        private ObservableCollection<Person> _personsList;

        #endregion


        #region Fields For Commands

        /*Community ToolKit Will Generate Commands for that Fields*/

        

        [RelayCommand]
        private async Task NavigateToCreatePersonPage()
        {
           await Shell.Current.GoToAsync(nameof(CreatePersonPage));
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
