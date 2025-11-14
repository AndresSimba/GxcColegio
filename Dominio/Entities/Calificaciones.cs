using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Calificaciones
    {
        public int Id { get; set; }

        public int IdColegio { get; set; }
        public Colegio Colegio { get; set; }

        public int IdMateria { get; set; }
        public Materia Materia { get; set; }

        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal CalificacionValor { get; set; }
    }
}
