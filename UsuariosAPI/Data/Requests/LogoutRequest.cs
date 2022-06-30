using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosAPI.Data.Requests
{
    public class LogoutRequest
    {
        [Required]
        public String Username { get; set; }
    }
}
