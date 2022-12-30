using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.LescogidoTecelContext context = new DL.LescogidoTecelContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"MateriaAdd '{empleado.Nombre}', {empleado.Puesto.IdPuesto}, {empleado.Departamento.IdDepartamento}");

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.LescogidoTecelContext context = new DL.LescogidoTecelContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoUpdate {empleado.IdEmpleado},'{empleado.Nombre}', {empleado.Puesto.IdPuesto}, {empleado.Departamento.IdDepartamento}");

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.LescogidoTecelContext context = new DL.LescogidoTecelContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoDelete {IdEmpleado}");

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LescogidoTecelContext context = new DL.LescogidoTecelContext())
                {
                    var obj = context.Empleados.FromSqlRaw($"EmpleadoGetById {IdEmpleado}").AsEnumerable().FirstOrDefault();

                    if (obj != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.IdEmpleado = obj.IdEmpleado;
                        empleado.Nombre = obj.Nombre;

                        empleado.Departamento = new ML.Departamento();
                        empleado.Departamento.IdDepartamento = obj.IdDepartamento.Value;

                        empleado.Puesto = new ML.Puesto();
                        empleado.Puesto.IdPuesto = obj.IdPuesto.Value;

                        result.Object = empleado;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LescogidoTecelContext context = new DL.LescogidoTecelContext())
                {
                    var obj = context.Empleados.FromSqlRaw($"EmpleadoGetAll").ToList();

                    if (obj != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var query in obj)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.IdEmpleado = query.IdEmpleado;
                            empleado.Nombre = query.Nombre;

                            empleado.Departamento = new ML.Departamento();
                            empleado.Departamento.IdDepartamento = query.IdDepartamento.Value;

                            empleado.Puesto = new ML.Puesto();
                            empleado.Puesto.IdPuesto = query.IdPuesto.Value;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}