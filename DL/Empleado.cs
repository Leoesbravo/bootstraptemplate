using System;
using System.Collections.Generic;

namespace DL;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }
    public string? PuestoDescripcion { get; set; }
    public string? DepartamentoDescripcion { get; set; }

    public int? IdPuesto { get; set; }

    public int? IdDepartamento { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    public virtual Puesto? IdPuestoNavigation { get; set; }
}
