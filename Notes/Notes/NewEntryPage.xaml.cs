using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


using static Notes.Models.MatIndex;
using Notes.Services;
using Plugin.FilePicker;
using Notes.Data;
using Notes.Models;
using System.IO;

namespace Notes
{

    public partial class NewEntryPage : ContentPage
    {
        public NewEntryPage()
        {
            InitializeComponent();
            btnScan.Clicked += BtnScan_Clicked;
        }
        byte[] Bilden { get; set; }
        string StringBilden { get; set; }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var vara = (Vara)BindingContext;
            ///vara.Date = DateTime.UtcNow;
            long ID = Convert.ToInt64(barcode.Text);
            vara.VaruID = ID;
            vara.Image = Bilden;
            vara.StringBilden = StringBilden;
            await App.Database.NewVaraAsync(vara);
            await Navigation.PopAsync();
        }
        private async void BtnScan_Clicked(object sender, EventArgs e)
        {
            var scanner = DependencyService.Get<IQrCodeScanningService>();
            var result = await scanner.ScanAsync();
            if (result != null)
                barcode.Text = result;
        }

        private async void OpenImageClicked(object sender, EventArgs e)
        {
            var file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {
                Bilden = file.DataArray;
                StringBilden = file.FilePath;
                //var vara = (Vara)BindingContext;
                ///byte[] bild1 = file.DataArray;
                //vara.Image = file.DataArray;
                //Image image = new Image();
                //Stream stream = new MemoryStream(bild1);
                bild.Source = ImageSource.FromStream(() => new MemoryStream(Bilden));
            }
        }
    }
}
    