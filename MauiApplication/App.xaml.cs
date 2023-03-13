namespace MauiApplication;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//Define the Root Page of Application
		MainPage = new AppShell();
	}
}
