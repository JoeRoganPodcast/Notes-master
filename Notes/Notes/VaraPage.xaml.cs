using Notes.Data;
using Notes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Notes.Data.MatIndexDatabase;
using static Notes.Models.MatIndex;

namespace Notes
{
    public partial class VaraPage : ContentPage
    {
        public VaraPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            MainListView.ItemsSource = await App.Database.GetVaraAsync();
        }

        async void OnVaraAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewEntryPage
            {
                BindingContext = new Vara()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new VaraEntryPage
                {
                    BindingContext = e.SelectedItem as Vara
                });
            }
        }
            void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            MainListView.ItemsSource = App.Database.GetVaran(searchBar.Text);
        }
    }
}