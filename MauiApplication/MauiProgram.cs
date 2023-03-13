using MauiApplication.Extensions;
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
            })
            .ConfigureServices(ConfigureServices);

        return builder.Build();
	}

    public static void ConfigureServices(MauiAppBuilder builder)
    {
        ///////////////////////////// Start Config Services For Dependency Injection ///////////////////////////

        //For Pages
        builder.Services.AddSingleton<PersonsPage>();
        builder.Services.AddTransient<CreatePersonPage>();
        builder.Services.AddTransient<EditPersonPage>();

        //For ViewModels
        builder.Services.AddTransient<IPersonsViewModel, PersonsViewModel>();
        builder.Services.AddTransient<ICreatePersonViewModel, CreatePersonViewModel>();
        builder.Services.AddTransient<IEditPersonViewModel, EditPersonViewModel>();

        //For Services
        builder.Services.AddSingleton<IPersonsService, PersonsService>();
        builder.Services.AddSingleton(Connectivity.Current);

        ///////////////////////////// End Config Services For Dependency Injection ///////////////////////////

    }

}
