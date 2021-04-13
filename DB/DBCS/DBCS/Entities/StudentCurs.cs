using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCS.Entities
{
    public class StudentCurs
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CursId { get; set; }
        public Student Student { get; set; }
        public Curs Curs { get; set; }

    }
}
