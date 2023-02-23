using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CategoriaN
    {
        public List<CategoriasCAD> Listar()
        {
            List<CategoriasCAD> lista = new List<CategoriasCAD>();
            Conexion datos = new Conexion();
            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                datos.Leer();

                while (datos.Lector.Read())
                {
                    CategoriasCAD aux = new CategoriasCAD();
                    aux.Id = Convert.ToInt32(datos.Lector["Id"]);
                    aux.Descripcion = (String)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
