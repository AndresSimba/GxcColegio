using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Colegio
    {
        public int Id { get; set; }

        [Required, MaxLength(256)]
        public string Nombre { get; set; }

        [Required, MaxLength(64)]
        public string tipoColegio { get; set; }

        public ICollection<Materia> Materias { get; set; }

        public ICollection<Calificaciones> Calificaciones { get; set; }


    }
}
