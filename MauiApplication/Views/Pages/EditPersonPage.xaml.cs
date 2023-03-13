using MauiApplication.ViewsModels;

namespace MauiApplication.Views.Pages;

public partial class EditPersonPage
{
    public EditPersonPage(IEditPersonViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}