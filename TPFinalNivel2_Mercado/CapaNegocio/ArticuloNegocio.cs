using CapaDominio;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ArticuloNegocio
    {
        private Conexion datos = new Conexion();
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();

            try
            {
                datos.setearConsulta("SELECT A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, M.Descripcion Marca, C.Descripcion Categoria, A.IdCategoria, A.IdMarca FROM ARTICULOS A, MARCAS M, CATEGORIAS C WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id");
                datos.Leer();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = Convert.ToInt32(datos.Lector["Precio"]);
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

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

        public void Agregar(Articulo nuevo)
        {
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                datos.ConfigurarParametros("@Codigo", nuevo.Codigo);
                datos.ConfigurarParametros("@Nombre", nuevo.Nombre);
                datos.ConfigurarParametros("@Descripcion", nuevo.Descripcion);
                datos.ConfigurarParametros("@IdMarca", nuevo.Marca.Id);
                datos.ConfigurarParametros("@IdCategoria", nuevo.Categoria.Id);
                datos.ConfigurarParametros("@ImagenUrl", nuevo.ImagenUrl);
                datos.ConfigurarParametros("@Precio", nuevo.Precio);
                datos.ejecutarAccion();
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

        public void modificar(Articulo articulo)
        {
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idmarca, IdCategoria = @idcategoria, ImagenUrl = @imagenUrl, Precio = @precio WHERE Id = @id");
                datos.ConfigurarParametros("id", articulo.Id);
                datos.ConfigurarParametros("codigo", articulo.Codigo);
                datos.ConfigurarParametros("nombre", articulo.Nombre);
                datos.ConfigurarParametros("descripcion", articulo.Descripcion);
                datos.ConfigurarParametros("idMarca", articulo.Marca.Id);
                datos.ConfigurarParametros("idCategoria", articulo.Categoria.Id);
                datos.ConfigurarParametros("imagenUrl", articulo.ImagenUrl);
                datos.ConfigurarParametros("precio", articulo.Precio);
                datos.ejecutarAccion();
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
        public void eliminarArticulo(int id)
        {
            datos.setearConsulta("	DELETE FROM ARTICULOS WHERE Id = " + id);
            datos.ejecutarAccion();
        }

        public List<Articulo> Filtrar(string campo, string caracter, string parametro)
        {
            List<Articulo> lista = new List<Articulo>();
            Conexion datos = new Conexion();

            try
            {
                string consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, M.Descripcion Marca, C.Descripcion Categoria, A.IdCategoria, A.IdMarca FROM ARTICULOS A, MARCAS M, CATEGORIAS C WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id";

                switch (campo)
                {
                    case "Código":
                        switch (caracter)
                        {
                            case "Empieza con":
                                consulta += " and Codigo like '" + parametro + "%'";
                                break;
                            case "Termina con":
                                consulta += " and Codigo like '%" + parametro + "'";
                                break;
                            case "Contiene":
                                consulta += " and Codigo like '%" + parametro + "%'";
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (caracter)
                        {
                            case "Empieza con":
                                consulta += " and Nombre like '" + parametro + "%'";
                                break;
                            case "Termina con":
                                consulta += " and Nombre like '%" + parametro + "'";
                                break;
                            case "Contiene":
                                consulta += " and Nombre like '%" + parametro + "%'";
                                break;
                        }
                        break;

                    case "Descripción":
                        switch (caracter)
                        {
                            case "Empieza con":
                                consulta += " and A.Descripcion like '" + parametro + "%'";
                                break;
                            case "Termina con con":
                                consulta += " and A.Descripcion like '%" + parametro + "'";
                                break;
                            case "Contiene":
                                consulta += " and A.Descripcion like '%" + parametro + "%'";
                                break;
                        }
                        break;
                }

                datos.setearConsulta(consulta);
                datos.Leer();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = Convert.ToInt32(datos.Lector["Precio"]);
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

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
