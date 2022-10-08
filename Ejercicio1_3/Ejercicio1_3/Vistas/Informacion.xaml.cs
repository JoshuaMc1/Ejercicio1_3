using Ejercicio1_3.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1_3.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Informacion : ContentPage
    {
        public Informacion()
        {
            InitializeComponent();        
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            txtLista.ItemsSource = await App.Database.getPersonas();
        }
    }
}