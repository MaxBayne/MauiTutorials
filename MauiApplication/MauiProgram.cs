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

        //For Pages as Singleton
        builder.Services.AddSingleton<CreatePersonPage>();


        //For ViewModels as Transient
        builder.Services.AddTransient<ICreatePersonViewModel,CreatePersonViewModel>();

        //For Services as Transient
        builder.Services.AddTransient<IPersonsService, PersonsService>();

        ///////////////////////////// End Config Services For Dependency Injection ///////////////////////////

        return builder.Build();
	}
}
