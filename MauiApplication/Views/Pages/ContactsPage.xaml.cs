using MauiApplication.Models;

namespace MauiApplication.Views.Pages;

public partial class ContactsPage : ContentPage
{
    private List<ContactModel> _contacts;

	public ContactsPage()
	{
		InitializeComponent();

        _contacts = new List<ContactModel> 
        {
            new ContactModel{ Id="100",Name="Ahmed",Email="Ahmed@mail.com",Address="Egypt"},
            new ContactModel{ Id="200",Name="Ali",Email="Ali@mail.com",Address="Tanta"},
            new ContactModel{ Id="300",Name="Khalid",Email="khalid@mail.com",Address="Asutt"},
            new ContactModel{ Id="400",Name="Mostafa",Email="mosfata@mail.com",Address="Giza"},
            new ContactModel{ Id="500",Name="Maged",Email="maged@mail.com",Address="Benha"},
            new ContactModel{ Id="600",Name="Mona",Email="mona@mail.com",Address="Alex"},
            new ContactModel{ Id="700",Name="Raqua",Email="korkor@mail.com",Address="Cairo"}
        };

        lvContacts.ItemsSource= _contacts;

	}

    private void btnAddContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void btnEditContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditContactPage));
    }


    private void lvContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var selectedContact = (ContactModel)lvContacts.SelectedItem;

        if (selectedContact != null)
        {
            //DisplayAlert("Alert", $"You Select Item ({selectedContact.Name})", "Ok");

            var data = new Dictionary<string, object>
            {
                { "contact", selectedContact }
            };

            Shell.Current.GoToAsync(nameof(EditContactPage),data);
        }
        
    }
}