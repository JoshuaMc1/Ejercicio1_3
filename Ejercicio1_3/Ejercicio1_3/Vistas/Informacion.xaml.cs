using Ejercicio1_3.Modelos;
using System;
using System.Linq;
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

        private async void txtLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string opcion = await DisplayActionSheet("Seleccione si desea eliminar o editar el registro", "Cancelar", null, "Eliminar", "Editar");

            switch (opcion)
            {
                case "Editar":
                    Persona persona = (Persona)e.CurrentSelection.FirstOrDefault();
                    var editarInfo = new Editar();
                    editarInfo.BindingContext = persona;
                    await Navigation.PushAsync(editarInfo);
                    break;

                case "Eliminar":
                    persona = (Persona)e.CurrentSelection.FirstOrDefault();
                    int res = await App.Database.borrarPersona(persona);
                    if (res != 0) mensaje("Aviso", "El empleado se a eliminado exitosamente");
                    else mensaje("Error", "A ocurrido un error al eliminar al empleado");
                    txtLista.ItemsSource = await App.Database.getPersonas();
                    break;

                default:
                    break;
            }
        }
        public async void mensaje(String tittulo, String mensaje)
        {
            await DisplayAlert(tittulo, mensaje, "Ok");
        }

        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}