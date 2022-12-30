﻿using System;
using System.Collections.Generic;

namespace DL;

public partial class Puesto
{
    public int IdPuesto { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}
