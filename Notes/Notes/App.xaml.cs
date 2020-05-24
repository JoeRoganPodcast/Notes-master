using System;
using System.IO;
using Xamarin.Forms;
using Notes.Data;

namespace Notes
{
    public partial class App : Application
    {
        static MatIndexDatabase database;

        public static MatIndexDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MatIndexDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new TabbedPage1());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
