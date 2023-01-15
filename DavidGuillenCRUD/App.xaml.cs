using DavidGuillenCRUD.Views;

namespace DavidGuillenCRUD;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new NavigationPage(new DGBurgerListPage())
        {
            BarTextColor = Color.FromRgb(255, 255, 255)
        };
    }
}
