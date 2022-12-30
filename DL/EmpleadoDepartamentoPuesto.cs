using System;
using System.Collections.Generic;

namespace DL;

public partial class EmpleadoDepartamentoPuesto
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public int IdPuesto { get; set; }

    public string? PuestoDescripcion { get; set; }

    public int IdDepartamento { get; set; }

    public string? Descripcion { get; set; }
}
