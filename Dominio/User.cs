using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class User
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        private string emailUsuario { get; set; }
        private string passUsuario { get; set; }
        public string ImagenPerfil { get; set; }
        public bool PerfilAdmin { get; set; }
        public List<Producto> Favoritos { get; set; }

        public string EmailUsuario
        {
            get { return emailUsuario; }

            set
            {
                // Guardo la expresion regular dentro de una variable para luego comparar el valor de seteo con la expresion
                string patronEmail = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
                if (value != "" && Regex.IsMatch(value, patronEmail)) 
                {
                    emailUsuario = value.ToString();
                }
                else
                {
                    throw new Exception("El formato ingresado no es valido");
                }
            }
        }
        public string PassUsuario
        {
            get { return passUsuario; }
            set 
            {
                if (value != "")
                {
                    passUsuario = value.ToString();
                }
                else
                {
                    throw new Exception("En campo de Contraseña no debe estar vacio");
                }
            }
        }
        public User() 
        {
            Favoritos = new List<Producto>();   //Esto es un constructor que hace que al instanciar un objeto, le genera una instancia a la lista para poder usar .Add()
        }


    }
}
