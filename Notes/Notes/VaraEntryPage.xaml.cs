using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


using static Notes.Models.MatIndex;
using Plugin.FilePicker;
using Notes.Services;
using Notes.Data;
using Notes.Models;
using System.IO;

namespace Notes
{
    
    public partial class VaraEntryPage : ContentPage
    {
        //byte[] Imagen { get; set; }
        public VaraEntryPage()
        {
            InitializeComponent();
            //var vara = (Vara)BindingContext;
            //Imagen = vara.Image;
            ///bild.Source = ImageSource.FromStream(() => new MemoryStream(Imagen));
            ///ShowImage();
        }
        string StringBilden { get; set; }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var vara = (Vara)BindingContext;
            //vara.Date = DateTime.UtcNow;
            await DisplayAlert("Alert", "You have been alerted", "OK");
            await App.Database.SaveVaraAsync(vara);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var vara = (Vara)BindingContext;
            await App.Database.DeleteVaraAsync(vara);
            await Navigation.PopAsync();
        }
        public void ShowImage()
        {
            var vara = (Vara)BindingContext;
            byte[] bild1 = vara.Image;
            //Image image = new Image();
            //Stream stream = new MemoryStream(bild1);
            bild.Source = ImageSource.FromStream(() => new MemoryStream(bild1));
        }
        private async void OpenImageClicked(object sender, EventArgs e)
        {
            var file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {
                //Bilden = file.DataArray;
                StringBilden = file.FilePath;
                //bild.Source = ImageSource.FromStream(() => new MemoryStream(Bilden));
                bild.Source = StringBilden;
            }
        }
    }
}