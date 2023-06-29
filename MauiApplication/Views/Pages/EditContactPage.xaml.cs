namespace MauiApplication.Views.Pages;

public partial class EditContactPage : ContentPage
{
	public EditContactPage()
	{
		InitializeComponent();
	}

    //Enter Page using Navigation
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        
        //DisplayAlert("Navigation", "OnNavigatedTo", "ok");
        base.OnNavigatedTo(args);
    }

    //Leave Page using Navgation (Leaving)
    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        //DisplayAlert("Navigation", "OnNavigatingFrom", "ok");
        base.OnNavigatingFrom(args);
    }

    //Leave Page using Navgation (Leaved)
    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        //DisplayAlert("Navigation", "OnNavigatedFrom", "ok");
        base.OnNavigatedFrom(args);
    }

    


}