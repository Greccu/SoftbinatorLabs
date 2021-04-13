using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCS.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public int Varsta { get; set; }

        public int FacultateId { get; set; }

        virtual public Facultate Facultate { get; set; }
        virtual public Collection<StudentCurs> Cursuri { get; set; }

    }
}
