using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFP
{
    public partial class EditPage : ContentPage
    {
        private Empleado empleado;

        public EditPage(Empleado empleado)
        {
            InitializeComponent();
            this.empleado = empleado;

            actualizarButton.Clicked += actualizarButton_Clicked;
            borrarButton.Clicked += borrarButton_Clicked;

            nombresEntry.Text = empleado.Nombres;
            apellidosEntry.Text = empleado.Apellidos;
            salarioEntry.Text = empleado.Salario.ToString();
            fechaContratoDatePicker.Date = empleado.FechaContrato;
            activoSwitch.IsToggled = empleado.Activo;
        }

        public async void borrarButton_Clicked(object sender, EventArgs e)
        {
            var rta = await DisplayAlert("Confirmación", "¿Desea borrar el empleado?", "Si", "No");
            if (!rta) return;

            using (var datos = new DataAccess())
            {
                datos.DeleteEmplado(empleado);
            }

            await DisplayAlert("Confirmación", "Empleado eliminado correctamente", "Aceptar");
            await Navigation.PushAsync(new HomePage());
        }

        public async  void actualizarButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombresEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar nombres", "Aceptar");
                nombresEntry.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(apellidosEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar apellidos", "Aceptar");
                apellidosEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(salarioEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar salario", "aceptar");
                salarioEntry.Focus();
                return;
            }

            Empleado empleado = new Empleado
            {
                IDEmpleado = this.empleado.IDEmpleado,
                Activo = activoSwitch.IsToggled,
                Apellidos = apellidosEntry.Text,
                FechaContrato = fechaContratoDatePicker.Date,
                Nombres = nombresEntry.Text,
                Salario = Convert.ToDecimal(salarioEntry.Text)
            };

            using (var datos = new DataAccess())
            {
                datos.updateEmpleado(empleado);
            }

            await DisplayAlert("Confirmación", "Empleado actualizado correctamente", "Aceptar");
            await Navigation.PushAsync(new HomePage());
        }
    }
}

