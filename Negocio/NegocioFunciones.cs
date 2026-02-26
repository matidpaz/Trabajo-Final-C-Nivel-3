using ConexionDB;
using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Negocio
{
    public class NegocioFunciones
    {
        public List<Producto> listarProductos() 
        {
			try
			{
				List<Producto> listaDeProductos = new List<Producto>();
				AccesoADB datos = new AccesoADB();

				datos.setearConsultaConSP("SP_ListarTodos");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Producto art = new Producto();

					art.Id = (int)datos.Lector["Id"];
					art.CodigoArticulo = (string)datos.Lector["Codigo"];
					art.NombreArticulo = (string)datos.Lector["Nombre"];
					art.DescripcionArticulo = (string)datos.Lector["Descripcion"];

					art.MarcaArticulo = new Marca();
					art.MarcaArticulo.Id = (int)datos.Lector["IdMarca"];
					art.MarcaArticulo.Descripcion = (string)datos.Lector["Marca"];

					art.CategoriaArticulo = new Categoria();
					art.CategoriaArticulo.Id = (int)datos.Lector["IdCategoria"];
					art.CategoriaArticulo.Descripcion = (string)datos.Lector["Categoria"];

					art.ImagenArticulo = (string)datos.Lector["ImagenUrl"];
					decimal precio = decimal.Parse(datos.Lector["Precio"].ToString());
					string precioEnString = (Math.Truncate(precio*100) / 100).ToString("F2"); ;
					art.PrecioArticulo = decimal.Parse(precioEnString);
					
					listaDeProductos.Add(art);					
				}
				return listaDeProductos;
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

		public List<Marca> listarMarcas() {

			List<Marca> lista = new List<Marca>();
			AccesoADB datos = new AccesoADB();
			try
			{
				datos.setearConsultaConSP("ListarMarcas_SP");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Marca mar = new Marca();
					mar.Id = (int)datos.Lector["Id"];
					mar.Descripcion = datos.Lector["Descripcion"].ToString();
					lista.Add(mar);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally {
				if (true)
				{
					datos.cerrarConexion();
				}
			}
		}

        public List<Categoria> listarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoADB datos = new AccesoADB();
            try
            {
                datos.setearConsultaConSP("ListarCategorias_SP");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria cat = new Categoria();
                    cat.Id = (int)datos.Lector["Id"];
                    cat.Descripcion = datos.Lector["Descripcion"].ToString();
                    lista.Add(cat);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (true)
                {
                    datos.cerrarConexion();
                }
            }
        }
		public Producto buscarPorId(int Id)
		{
			try
			{
				List<Producto> lista = listarProductos();
				return  lista.Find(x => x.Id == Id);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int crearArticulo(string codigo, string nombre, string descripcion, int categoria, int marca, string imagen, decimal precio) 
		{
			AccesoADB datos = new AccesoADB();
			try
			{
				datos.setearConsultaConSP("RegistrarNuevo_SP");
				datos.setearParametro("@Codigo", codigo);
				datos.setearParametro("@Nombre", nombre);
				datos.setearParametro("@Descripcion", descripcion);
				datos.setearParametro("@IdCategoria", categoria);
				datos.setearParametro("@IdMarca", marca);
				datos.setearParametro("@ImgUrl", imagen);
				datos.setearParametro("@Precio", precio);
				int Id = datos.ejecutarAccionScalar();
				return Id;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void modificarArticulo(int Id, string codigo, string nombre, string descripcion, int categoria, int marca, string imagen, decimal precio)
		{
			AccesoADB datos = new AccesoADB();
			try
			{
				datos.setearConsultaConSP("ActualizarProductoSP");
				datos.setearParametro("@Id", Id);
				datos.setearParametro("@Codigo", codigo);
				datos.setearParametro("@Nombre", nombre);
				datos.setearParametro("@Descripcion", descripcion);
				datos.setearParametro("@IdCategoria", categoria);
				datos.setearParametro("@IdMarca", marca);
				datos.setearParametro("@ImgUrl", imagen);
				datos.setearParametro("@Precio", precio);
				datos.ejecutarAccion();			
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void eliminarArticulo(int Id)
		{
			AccesoADB datos = new AccesoADB();
			try
			{
				datos.setearConsultaConSP("EliminarProductoSP");
				datos.setearParametro("@Id", Id);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int crearUser(User user)
		{
			AccesoADB datos = new AccesoADB();
			try
			{
				datos.setearConsultaConSP("CrearUser_SP");
				datos.setearParametro("@Email", user.EmailUsuario);
				datos.setearParametro("@Pass", user.PassUsuario);
				datos.setearParametro("@Nombre", (object)user.NombreUsuario ?? DBNull.Value);
				datos.setearParametro("@Apellido", (object)user.ApellidoUsuario ?? DBNull.Value);
				datos.setearParametro("@Imagen", (object)user.ImagenPerfil ?? DBNull.Value);
				int idNuevo = (int)datos.ejecutarAccionScalar();
				return idNuevo;
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

		public User verificarUser(User user)
		{
			AccesoADB datos = new AccesoADB();
			User userLog = null;
			try
			{
				datos.setearConsultaConSP("VerificarUsuario_SP");
				datos.setearParametro("@Email", user.EmailUsuario);
				datos.setearParametro("@Pass", user.PassUsuario);
				datos.ejecutarLectura();
				if (datos.Lector.Read())
				{
					userLog = new User();
                    userLog.IdUsuario = (int)datos.Lector["Id"];
					userLog.EmailUsuario = datos.Lector["email"].ToString();
					userLog.PassUsuario = datos.Lector["pass"].ToString();
					userLog.NombreUsuario = datos.Lector["nombre"] is DBNull ? null : datos.Lector["nombre"].ToString();
					userLog.ApellidoUsuario = datos.Lector["apellido"] is DBNull ? null : datos.Lector["apellido"].ToString();
					userLog.ImagenPerfil = datos.Lector["urlImagenPerfil"] is DBNull ? null : datos.Lector["urlImagenPerfil"].ToString();
					userLog.PerfilAdmin = (bool)datos.Lector["admin"];
				}
				return userLog;
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
		public User modificarUsuario(User user) 
		{
			AccesoADB datos = new AccesoADB();
			try
			{
				datos.setearConsultaConSP("ModificarUser");
				datos.setearParametro("@Id", user.IdUsuario);
				datos.setearParametro("@Nombre", (object)user.NombreUsuario ?? DBNull.Value);
				datos.setearParametro("@Apellido", (object)user.ApellidoUsuario ?? DBNull.Value);
				datos.setearParametro("@Imagen", (object)user.ImagenPerfil ?? DBNull.Value);
				datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    user.IdUsuario = (int)datos.Lector["Id"];
                    user.EmailUsuario = datos.Lector["email"].ToString();
                    user.PassUsuario = datos.Lector["pass"].ToString();
                    user.NombreUsuario = datos.Lector["nombre"] is DBNull ? null : datos.Lector["nombre"].ToString();
                    user.ApellidoUsuario = datos.Lector["apellido"] is DBNull ? null : datos.Lector["apellido"].ToString();
                    user.ImagenPerfil = datos.Lector["urlImagenPerfil"] is DBNull ? null : datos.Lector["urlImagenPerfil"].ToString();
                    user.PerfilAdmin = (bool)datos.Lector["admin"];
                }
				return user;
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

		public bool verificarEmail(string email) 
		{
			try
			{
				AccesoADB datos = new AccesoADB();
				datos.setearConsultaConSP("verificarNuevoMail_SP");
				datos.setearParametro("@Email", email);
				object resultado = datos.ejecutarAccionScalarParaEmail();
				if (resultado != null && resultado != DBNull.Value)
				{
					return false;
				}
				return true;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public List<Producto> filtrarPorCategoria(List<Producto>lista, int idCat)
		{
			try
			{
				if (idCat != 0)
				{
					List<Producto> listaFiltrada1 = lista.FindAll(x => x.CategoriaArticulo.Id == idCat);
					return listaFiltrada1;
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }
        public List<Producto> filtrarPorMarca(List<Producto> lista, int idMar)
        {
			try
			{
				if (idMar != 0)
				{
					List<Producto> listaFiltrada2 = lista.FindAll(x => x.MarcaArticulo.Id == idMar);
					return listaFiltrada2;
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

        public List<Producto> filtarPorMarcaYCategoria(List<Producto> lista, int idCat, int idMar) // Esta funcion no la estoy usando pero la dejo por si me conviene usarla en algun momento
		{
			try
			{
				List<Producto> filtradoCategoria =  filtrarPorCategoria(lista, idCat);
				List<Producto> filtradoMarca = filtrarPorMarca(filtradoCategoria, idMar);
				return filtradoMarca;
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }
		public List<Producto> busquedaAvanzada(List<Producto> lista, string fragmento)
		{
			lista = lista.FindAll(
				x => x.NombreArticulo.ToLower().Contains(fragmento) ||
				x.MarcaArticulo.Descripcion.ToLower().Contains(fragmento) ||
				x.CategoriaArticulo.Descripcion.ToLower().Contains(fragmento) ||
				x.DescripcionArticulo.ToLower().Contains(fragmento));
			return lista;
		}

    }
}
