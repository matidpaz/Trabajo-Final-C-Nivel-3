using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using ConexionDB;

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
					art.PrecioArticulo = (decimal)datos.Lector["Precio"];

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

				datos.setearConsultaConSP("ListarMarcasSP");
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

                datos.setearConsultaConSP("ListarCategoriasSP");
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
    }
}
