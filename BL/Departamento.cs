using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LescogidoTecelContext context = new DL.LescogidoTecelContext())
                {
                    var obj = context.Departamentos.FromSqlRaw($"GetAllDepartamentos").ToList();

                    if (obj != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var query in obj)
                        {
                            ML.Departamento departamento = new ML.Departamento();
                            departamento.IdDepartamento = query.IdDepartamento;
                            departamento.Descripcion = query.Descripcion;

                            result.Objects.Add(departamento);
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
