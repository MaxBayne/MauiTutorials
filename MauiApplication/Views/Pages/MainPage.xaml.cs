namespace MauiApplication.Views.Pages;

public partial class MainPage : ContentPage
{
	int count;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			btnCounter.Text = $"Clicked {count} time";
		else
            btnCounter.Text = $"Clicked {count} times !";

		SemanticScreenReader.Announce(btnCounter.Text);
	}
}

