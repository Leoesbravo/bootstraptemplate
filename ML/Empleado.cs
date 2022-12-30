using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public ML.Puesto Puesto { get; set; }
        public ML.Departamento Departamento { get; set; }
        public List<object> Empleados { get; set; }
    }
}
