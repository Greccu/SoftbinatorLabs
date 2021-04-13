using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCS.Entities
{
    public class Facultate
    {
        [Key]
        public int Id { get; set; }

        public string Nume { get; set; }

        public ICollection<Student> Studenti { get; set; }
    }
}
