using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;
using System.IO;

namespace XFP
{
    class DataAccess: IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Platforma, Path.Combine(config.DirectorioDB, "Empleados.db3"));
            connection.CreateTable<Empleado>();
        }

        public void InsertEmpleado(Empleado empleado)
        {
            connection.Insert(empleado);
        }

        public void updateEmpleado(Empleado empleado)
        {
            connection.Update(empleado);
        }

        public void DeleteEmplado(Empleado empleado)
        {
            connection.Delete(empleado);
        }

        public Empleado GetEmpleado(int IDEmpleado)
        {
            return connection.Table<Empleado>().FirstOrDefault(c => c.IDEmpleado == IDEmpleado);
        }

        public List<Empleado> GetEmpleados()
        {
            return connection.Table<Empleado>().OrderBy(c => c.Apellidos).ToList();
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
