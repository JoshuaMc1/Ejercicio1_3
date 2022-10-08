using Ejercicio1_3.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1_3
{
    public partial class App : Application
    {
        static PersonaControlador database;

        public static PersonaControlador Database
        {
            get
            {
                if (database == null)
                {
                    database = new PersonaControlador(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbPersona.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
