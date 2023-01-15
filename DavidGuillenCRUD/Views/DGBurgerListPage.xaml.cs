using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidGuillenCRUD.Data;
using DavidGuillenCRUD.Models;

namespace DavidGuillenCRUD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DGBurgerListPage : ContentPage
    {
        public DGBurgerListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            DGBurgerDatabase database = await DGBurgerDatabase.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DGBurgerItemPage
            {
                BindingContext = new DGBurger()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new DGBurgerItemPage
                {
                    BindingContext = e.SelectedItem as DGBurger
                });
            }
        }
    }
}