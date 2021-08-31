using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudisoftClient.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int idProfesor { get; set; }
        public int idEstudiante { get; set; }
        public string Valor { get; set; }

        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}