using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Usuario
    {

        public int Id { get; set; }

        [MaxLength(256)]
        public string NombreCompleto { get; set; }

        [Required]
        [MaxLength(128)]
        public string Username { get; set; }

        [Required]
        [MaxLength(128)]
        public string Password { get; set; }

        [MaxLength(256)]
        public string CorreoElectronico { get; set; }

        [MaxLength(32)]
        public string Rol { get; set; }

        public ICollection<Calificaciones> Calificaciones { get; set; }

    }
}
