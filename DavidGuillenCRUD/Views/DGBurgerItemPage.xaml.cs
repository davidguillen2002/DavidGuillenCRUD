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

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (DGBurger)BindingContext;
            DGBurgerDatabase database = await DGBurgerDatabase.Instance;
            await database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (DGBurger)BindingContext;
            DGBurgerDatabase database = await DGBurgerDatabase.Instance;
            await database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}