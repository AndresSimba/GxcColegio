using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Materia
    {
        public int Id { get; set; }

        public int IdColegio { get; set; }
        public Colegio Colegio { get; set; } = null;

        [Required, MaxLength(256)]
        public string Nombre { get; set; }

        [MaxLength(128)]
        public string Area { get; set; }

        public int numeroEstudiantes { get; set; }

        [MaxLength(512)]
        public string docenteAsignado { get; set; }

        [MaxLength(64)]
        public string curso { get; set; }

        [MaxLength(16)]

        public string parparalelo { get; set; }

        public ICollection<Calificaciones> Calificaciones { get; set; }

    }
}