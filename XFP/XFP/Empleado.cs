using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace XFP
{
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int IDEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaContrato { get; set; }
        public decimal Salario { get; set; }
        public bool Activo { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", IDEmpleado, Nombres, Apellidos, FechaContrato, Salario, Activo);
        }
    }
}
