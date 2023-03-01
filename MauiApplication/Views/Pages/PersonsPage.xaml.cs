using MauiApplication.ViewsModels;

namespace MauiApplication.Views.Pages;

public partial class PersonsPage : ContentPage
{
	public PersonsPage(IPersonsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}