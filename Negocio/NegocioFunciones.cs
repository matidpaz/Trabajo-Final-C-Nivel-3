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
    }
}
