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
        public bool PerfilAdmin { get; set; }
        public List<Producto> Favoritos { get; set; }

        public string EmailUsuario
        {
            get { return emailUsuario; }

            set
            {
                // Guardo la expresion regular dentro de una variable para luego comparar el valor de seteo con la expresion
                string patronEmail = "^([\\w -\\.] +)@((\\[[0 - 9]{1,3}\\.[0 - 9]{1,3}\\.[0 - 9]{ 1,3}\\.)| (([\\w -] +\\.)+))([a - zA - Z]{ 2,4}| [0 - 9]{ 1,3})(\\]?)$";
                if (value != "" && Regex.IsMatch(value, patronEmail)) 
                {
                    emailUsuario = value;
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
                    passUsuario = value;
                }
                else
                {
                    throw new Exception("En campo de Contraseña no debe estar vacio");
                }
            }
        }


    }
}
