using MauiApplication.Views.Pages;

namespace MauiApplication;

public partial class AppShell
{
	public AppShell()
	{
		InitializeComponent();

        //Register the App Routes For Shells

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(ProductsPage), typeof(ProductsPage));
        Routing.RegisterRoute(nameof(DepartmentsPage), typeof(DepartmentsPage));
        Routing.RegisterRoute(nameof(PersonsPage),typeof(PersonsPage));
        Routing.RegisterRoute(nameof(CreatePersonPage), typeof(CreatePersonPage));
        Routing.RegisterRoute(nameof(EditPersonPage), typeof(EditPersonPage));

    }
}
