using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudisoftClient.Models
{
    public class Student
    {
        public Student()
        {
            Note = new HashSet<Note>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Note> Note { get; set; }
    }
}