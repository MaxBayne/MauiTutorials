using MauiApplication.Views.Pages;

namespace MauiApplication;

public partial class AppShell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(ProductsPage), typeof(ProductsPage));
        Routing.RegisterRoute(nameof(DepartmentsPage), typeof(DepartmentsPage));
        Routing.RegisterRoute(nameof(PersonsPage),typeof(PersonsPage));
        Routing.RegisterRoute(nameof(CreatePersonPage), typeof(CreatePersonPage));

    }
}
