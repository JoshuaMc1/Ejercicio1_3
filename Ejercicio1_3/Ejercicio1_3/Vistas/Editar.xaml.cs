using Ejercicio1_3.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1_3.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editar : ContentPage
    {
        public Editar()
        {
            InitializeComponent();
        }

        private async void btnEditar_Clicked(object sender, EventArgs e)
        {
            if (!validarCampoVacio(txtNombres) && !validarCampoVacio(txtApellidos) && !validarCampoVacio(txtEdad) &&
                !validarCampoVacio(txtCorreo) && !validarCampoVacio(txtDireccion))
            {
                try
                {
                    var persona = new Persona
                    {
                        Id = Convert.ToInt32(txtID.Text.Trim()),
                        nombres = txtNombres.Text.Trim(),
                        apellidos = txtApellidos.Text.Trim(),
                        edad = int.Parse(txtEdad.Text.Trim()),
                        correo = txtCorreo.Text.Trim(),
                        direccion = txtDireccion.Text.Trim(),
                    };

                    int result = await App.Database.guardarPersona(persona);
                    if (result > 0)
                    {
                        mensaje("Aviso", "Los datos se editaron exitosamente");
                        await Navigation.PushAsync(new Informacion());
                    }
                    else
                    {
                        bool opcion = await DisplayAlert("Error al editar", "Al parecer los datos no se han guardado, desea intentar de nuevo?", "Si", "No");
                        if (opcion == false) await Navigation.PushAsync(new Informacion());
                    }
                }
                catch (Exception ex)
                {
                    mensaje("Exception", "Error: " + ex.Message);
                }
            }
            else mensaje("Campo vacio", "Debe ingresar loas campos solicitados");
        }

        public bool validarCampoVacio(Entry campo)
        {
            return String.IsNullOrEmpty(campo.Text);
        }

        public async void mensaje(String tittulo, String mensaje)
        {
            await DisplayAlert(tittulo, mensaje, "Ok");
        }
    }
}