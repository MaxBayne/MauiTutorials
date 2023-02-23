using MauiApplication.ViewsModels;

namespace MauiApplication.Views.Pages;

public partial class CreatePersonPage
{
    public CreatePersonPage(ICreatePersonViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}