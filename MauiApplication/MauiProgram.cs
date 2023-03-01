using MauiApplication.Services;
using MauiApplication.Views.Pages;
using MauiApplication.ViewsModels;


namespace MauiApplication;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        ///////////////////////////// Start Config Services For Dependency Injection ///////////////////////////

        //For Pages
        builder.Services.AddSingleton<PersonsPage>();
        builder.Services.AddTransient<CreatePersonPage>();


        //For ViewModels
        builder.Services.AddTransient<IPersonsViewModel, PersonsViewModel>();
        builder.Services.AddTransient<ICreatePersonViewModel,CreatePersonViewModel>();


        //For Services
        builder.Services.AddSingleton<IPersonsService, PersonsService>();

        ///////////////////////////// End Config Services For Dependency Injection ///////////////////////////

        return builder.Build();
	}
}
