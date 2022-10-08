using Ejercicio1_3.Data;
using Ejercicio1_3.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio1_3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (!validarCampoVacio(txtNombres) && !validarCampoVacio(txtApellidos) && !validarCampoVacio(txtEdad) &&
                !validarCampoVacio(txtCorreo) && !validarCampoVacio(txtDireccion))
            {
                try
                {
                    var persona = new Persona
                    {
                        nombres = txtNombres.Text.Trim(),
                        apellidos = txtApellidos.Text.Trim(),
                        edad = int.Parse(txtEdad.Text.Trim()),
                        correo = txtCorreo.Text.Trim(),
                        direccion = txtDireccion.Text.Trim(),
                    };

                    int result = await App.Database.guardarPersona(persona);
                    if (result > 0)
                    {
                        mensaje("Ingreso exitoso", "Los datos se guardaron exitosamente");
                        limpiarCampos();
                    }
                    else mensaje("Error al guardar", "Al parecer los datos no se han guardado");
                } catch(Exception ex)
                {
                     mensaje("Exception", "Error: " + ex.Message);
                }
            } else mensaje("Campo vacio", "Debe ingresar loas campos solicitados");
        }

        private async void btnVer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.Informacion());
        }

        public bool validarCampoVacio(Entry campo)
        {
            return String.IsNullOrEmpty(campo.Text);
        }

        public async void mensaje(String tittulo, String mensaje)
        {
            await DisplayAlert(tittulo, mensaje, "Ok");
        }

        public void limpiarCampos()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
