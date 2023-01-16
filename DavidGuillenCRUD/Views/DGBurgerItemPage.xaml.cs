using DavidGuillenCRUD.Data;
using DavidGuillenCRUD.Models;
using DavidGuillenCRUD.Views;

namespace DavidGuillenCRUD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DGBurgerItemPage : ContentPage
    {
        public DGBurgerItemPage()
        {
            InitializeComponent();
        }

        async void DGOnSaveClicked(object sender, EventArgs e)
        {
            var burgerItem = (DGBurger)BindingContext;
            DGBurgerDatabase database = await DGBurgerDatabase.Instance;
            await database.DGSaveItemAsync(burgerItem);
            await Navigation.PopAsync();
        }

        async void DGOnDeleteClicked(object sender, EventArgs e)
        {
            var burgerItem = (DGBurger)BindingContext;
            DGBurgerDatabase database = await DGBurgerDatabase.Instance;
            await database.DGDeleteItemAsync(burgerItem);
            await Navigation.PopAsync();
        }

        async void DGOnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}