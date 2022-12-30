using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Puesto
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LescogidoTecelContext context = new DL.LescogidoTecelContext())
                {
                    var obj = context.Puestos.FromSqlRaw($"GetAllPuestos").ToList();

                    if (obj != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var query in obj)
                        {
                            ML.Puesto puesto = new ML.Puesto();
                            puesto.IdPuesto = query.IdPuesto;
                            puesto.Descripcion = query.Descripcion;

                            result.Objects.Add(puesto);
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
