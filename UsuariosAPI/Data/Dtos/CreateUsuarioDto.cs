using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosAPI.Data.Dtos
{
    public class CreateUsuarioDto
    {
        [Required]
        public String Username { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required]
        [Compare("Password")]
        public String Repassword { get; set; }
    }
}
