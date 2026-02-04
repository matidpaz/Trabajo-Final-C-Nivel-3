using ConexionDB;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
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
		public Producto buscarPorId(int Id, List<Producto> lista)
		{
			return  lista.Find(x => x.Id == Id);
		}

		public int crearArticulo(string codigo, string nombre, string descripcion, int categoria, int marca, string imagen, decimal precio) 
		{
			AccesoADB datos = new AccesoADB();

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

		public void modificarArticulo(int Id, string codigo, string nombre, string descripcion, int categoria, int marca, string imagen, decimal precio)
		{
			AccesoADB datos = new AccesoADB();

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

		public void eliminarArticulo(int Id)
		{
			AccesoADB datos = new AccesoADB();

			datos.setearConsultaConSP("EliminarProductoSP");
			datos.setearParametro("@Id", Id);
			datos.ejecutarAccion();
		}
    }
}
