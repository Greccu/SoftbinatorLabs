using DBCS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCS.Seeders
{
    public class InitialSeeder
    {
        DBDBContext _context { get; set; }
        public InitialSeeder(DBDBContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            #region Facultati
            var facultate1 = new Facultate { Nume = "facultatea1" };
            _context.Facultati.Add(facultate1);
            _context.SaveChanges();

            #endregion
            #region Studenti

            var facultateId = _context.Facultati.FirstOrDefault().Id;

            var student1 = new Student {
                Nume = "Student1",
                Prenume = "Prenume1",
                Varsta = 11,
                FacultateId = facultateId
            };
            
            var student2 = new Student
            {
                Nume = "Student2",
                Prenume = "Prenume2",
                Varsta = 12,
                FacultateId = facultateId
            };

            var student3 = new Student
            {
                Nume = "Student3",
                Prenume = "Prenume3",
                Varsta = 17,
                FacultateId = facultateId
            };

            var studenti = new List<Student> { student1, student2, student3 };

            _context.Studenti.AddRange(studenti);
            _context.SaveChanges();
            #endregion
            #region Cursuri

            _context.Cursuri.Add(
                new Curs
                {
                    Nume = "Curs1"
                }
                );

            _context.Cursuri.Add(
                new Curs
                {
                    Nume = "Curs2"
                }
                );

            _context.Cursuri.Add(
                new Curs
                {
                    Nume = "Curs3"
                }
                );

            _context.SaveChanges();
            #endregion
            #region StudentiCursuri
            var st = _context.Studenti.ToList();
            var cs = _context.Cursuri.ToList();
            
            _context.StudentCurs.Add(new StudentCurs
            {
                CursId = cs[0].Id,
                StudentId = st[0].Id
            });
            
            _context.StudentCurs.Add(new StudentCurs
            {
                CursId = cs[1].Id,
                StudentId = st[0].Id
            });

            _context.StudentCurs.Add(new StudentCurs
            {
                CursId = cs[2].Id,
                StudentId = st[0].Id
            });

            _context.StudentCurs.Add(new StudentCurs
            {
                CursId = cs[0].Id,
                StudentId = st[1].Id
            });

            _context.StudentCurs.Add(new StudentCurs
            {
                CursId = cs[2].Id,
                StudentId = st[1].Id
            });

            _context.StudentCurs.Add(new StudentCurs
            {
                CursId = cs[1].Id,
                StudentId = st[2].Id
            });
            
            _context.SaveChanges();
            #endregion
        }
    }
}
