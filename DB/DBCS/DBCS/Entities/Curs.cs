using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCS.Entities
{
    public class Curs
    {
        [Key]
        public int Id { get; set; }

        public string Nume { get; set; }
        public Collection<StudentCurs> Studenti { get; set; }
    }
}
