using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Libro
    {
        public int ID { get; set; }
        public int ISBN { get; set; }
        public String titulo { get; set; }
        public String materia { get; set; }
        public int numeroEdicion { get; set; }
        public int anioPublicacion { get; set; }
        public String nombreAutores { get; set; }
        public String paisPublicacion { get; set; }
        public String sinopsis { get; set; }
        public String carrera { get; set; }
    }
}
