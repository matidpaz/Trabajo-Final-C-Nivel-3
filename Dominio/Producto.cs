using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        //código de artículo.
        //nombre.
        //descripción.
        //marca(seleccionable de una lista desplegable).
        //categoría(seleccionable de una lista desplegable.
        //imagen.
        //precio.
        public int CodigoArticulo { get; set; }            //publico porque lo otorga la DB
        private string nombreArticulo;                     //privado para que no entre un string vacio
        private string descripcionArticulo;                //privado para que no entre un string vacio
        public string MarcaArticulo { get; set; }          //publico porque lo voy a manejar dando las opciones yo
        public string CategoriaArticulo { get; set; }      //publico porque lo voy a manejar dando las opciones yo
        public string ImagenArticulo { get; set; }         //publico porque puedo manejar que un producto no tenga imagen disponible
        private float precioArticulo;                      //privado para manejar que el precio sea mayor a cero

        public string NombreArticulo 
        {
            get { return nombreArticulo; }
            set
            {
                if (value != "")
                {
                    nombreArticulo = value;
                }
                else
                {
                    throw new Exception("El campo de Nombre no debe estar vacio");
                }
            }
        }
        public string DescripcionArticulo
        {
            get { return descripcionArticulo; }
            set
            {
                if (value != "")
                {
                    descripcionArticulo = value;
                }
                else
                {
                    throw new Exception("El campo de Descripcion no debe estar vacio");
                }
            }
        }
        public float PrecioArticulo
        {
            get { return precioArticulo; }
            set
            {
                if (value > 0)
                {
                    precioArticulo = value;
                }
                else
                {
                    throw new Exception("Recuerda que el campo precio no debe estar vacio y debe contener valores numericos mayores a cero");
                }
            }
        }
    }
}
