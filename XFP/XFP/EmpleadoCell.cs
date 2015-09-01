using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFP
{
    class EmpleadoCell: ViewCell
    {
        public EmpleadoCell()
        {
            var IDEmpleadoLabel = new Label
            {
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Start
            };
            IDEmpleadoLabel.SetBinding(Label.TextProperty, new Binding("IDEmpleado"));

            var NombresLabel = new Label
            {
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(NamedSize.Medium)
            };
            NombresLabel.SetBinding(Label.TextProperty, new Binding("Nombres"));

            var ApellidosLabel = new Label
            {
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill
            };
            ApellidosLabel.SetBinding(Label.TextProperty, new Binding("Apellidos"));

            var SalarioLabel = new Label
            {
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(NamedSize.Small),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            SalarioLabel.SetBinding(Label.TextProperty, new Binding("Salario"));

            var FechaContratoLabel = new Label
            {
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(NamedSize.Small),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            FechaContratoLabel.SetBinding(Label.TextProperty, new Binding("FechaContrato"));

            var ActivoSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                IsEnabled = false
            };
            ActivoSwitch.SetBinding(Switch.IsToggledProperty, new Binding("Activo"));

            var panel1 = new StackLayout
            {
                Children = { IDEmpleadoLabel, NombresLabel, ApellidosLabel},
                Orientation = StackOrientation.Horizontal
            };

            var panel2 = new StackLayout
            {
                Children = { SalarioLabel, FechaContratoLabel, ActivoSwitch},
                Orientation = StackOrientation.Horizontal
            };

            View = new StackLayout
            {
                Children = { panel1, panel2 },
                Orientation = StackOrientation.Vertical,
                Spacing = Height + Height
            };
        }
    }
}
