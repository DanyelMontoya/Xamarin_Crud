using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFP
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            nuevoButton.Clicked += nuevoButton_Clicked;

            datosListView.ItemSelected += datosListView_ItemSelected;

            datosListView.ItemTemplate = new DataTemplate(typeof(EmpleadoCell));

            using (var datos = new DataAccess())
            {
                datosListView.ItemsSource = datos.GetEmpleados();
            }
        }

        void datosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new EditPage((Empleado)e.SelectedItem));
        }

        public async void nuevoButton_Clicked(object sender, EventArgs e)
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
                Activo = activoSwitch.IsToggled,
                Apellidos = apellidosEntry.Text,
                FechaContrato = fechaContratoDatePicker.Date,
                Nombres = nombresEntry.Text,
                Salario = Convert.ToDecimal(salarioEntry.Text)
            };

            using (var datos = new DataAccess())
            {
                datos.InsertEmpleado(empleado);
                datosListView.ItemsSource = datos.GetEmpleados();
            }

            apellidosEntry.Text = String.Empty;
            fechaContratoDatePicker.Date = DateTime.Now;
            nombresEntry.Text = String.Empty;
            salarioEntry.Text = String.Empty;
            await DisplayAlert("Mensaje", "Empleado creado correctamente", "Aceptar");
        }
    }
}
