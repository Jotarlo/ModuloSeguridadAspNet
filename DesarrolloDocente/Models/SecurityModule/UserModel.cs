using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDocente.Models.SecurityModule
{
    public class UserModel:ModelBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        [DisplayName("Nombre")]
        [Required()]
        [MaxLength(50, ErrorMessage ="El campo {0} puede tener una longitud máxima de {1} caracteres")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string lastname;

        [DisplayName("Apellidos")]
        [Required()]
        [MaxLength(100, ErrorMessage = "El campo {0} puede tener una longitud máxima de {1} caracteres")]
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private string cellphone;

        [DisplayName("Celular")]
        [Required()]
        [MaxLength(30, ErrorMessage = "El campo {0} puede tener una longitud máxima de {1} caracteres")]
        public string Cellphone
        {
            get { return cellphone; }
            set { cellphone = value; }
        }

        private string email;

        [DisplayName("Correo Electrónico")]
        [Required()]
        [MaxLength(100, ErrorMessage = "El campo {0} puede tener una longitud máxima de {1} caracteres")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        private IEnumerable<RoleModel> roles;    

        public IEnumerable<RoleModel> Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        private string token;

        public string Token
        {
            get { return token; }
            set { token = value; }
        }


    }
}
