using DBCS.DTO;
using DBCS.Entities;
using DBCS.Seeders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;

namespace DBCS
{
    class Program
    {
        static void Main(string[] args)
        {
            DBDBContext context = new DBDBContext();
            if (false)
            {
                context.Cursuri.RemoveRange(context.Cursuri);
                context.Studenti.RemoveRange(context.Studenti);
                context.Facultati.RemoveRange(context.Facultati);
                InitialSeeder seeder = new InitialSeeder(context);
                seeder.Seed();
                Console.WriteLine("Initial Seed completed!");
            }
            while(true)
            {
                //Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Select an option");
                Console.WriteLine("1. Add a new faculty");
                Console.WriteLine("2. Edit name for the last added faculty");
                Console.WriteLine("3. Show all faculties");
                Console.WriteLine("4. Delete last added faculty");
                Console.WriteLine("5. Show number of students for every course");
                Console.WriteLine("6. Show the student enrolled in the fewest courses");
                Console.WriteLine("7. Show if there is a course without enrolled students");
                Console.WriteLine("8. Show students");
                Console.WriteLine("9. Exit");
                var opt = Console.ReadLine();
                if(opt == "9")
                {
                    break;
                }
                switch (opt)
                {
                    case "1":
                        Console.WriteLine("Type faculty name: ");
                        var n = Console.ReadLine();
                        context.Facultati.Add(new Facultate
                        {
                            Nume = n
                        });
                        context.SaveChanges();
                        Console.WriteLine("Database Updated");
                        break;
                    case "2":
                        Console.WriteLine("Type faculty new name: ");
                        var nn = Console.ReadLine();
                        context.Facultati.OrderBy(f => f.Id).Last().Nume = nn;
                        context.SaveChanges();
                        Console.WriteLine("Database Updated");
                        break;
                    case "3":
                        Console.WriteLine("Faculties");
                        foreach (Facultate f in context.Facultati.ToList())
                        {
                            Console.WriteLine(f.Nume);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Deleting last added faculty");
                        context.Facultati.Remove(context.Facultati.OrderBy(f => f.Id).LastOrDefault());
                        Console.WriteLine("Database Updated");
                        break;
                    case "5":
                        Console.WriteLine("Number of students for every course");
                        foreach(Curs c in context.Cursuri.Include("Studenti").ToList())
                        {
                            Console.WriteLine(c.Nume + " - " + c.Studenti.Count());
                        }
                        break;
                    case "6":
                        //DTO
                        var st = context.Studenti
                            .Select(st => new SLC
                            {
                                Nume = st.Nume,
                                Prenume = st.Prenume,
                                NrCursuri = st.Cursuri.Count()
                            })
                            .OrderBy(st => st.NrCursuri)
                            .First();
                        Console.WriteLine("The student with the fewest courses");
                        Console.WriteLine(st.Nume + " " + st.Prenume + " - " + st.NrCursuri + " Courses");
                        break;

                    case "7":
                        var count = context.Cursuri.Where(cs => cs.Studenti.Count() == 0).Count();
                        if(count == 0)
                        {
                            Console.WriteLine("There are no courses without students");
                        }
                        else
                        {
                            Console.WriteLine("There are" + count + "courses without students");
                        }
                        break;
                    case "8":

                        Stats std = new Stats
                        {
                        Studenti = context.Studenti.Include("Facultate").Include("Cursuri").ToList().GroupBy(st => st.Facultate)
                          .ToDictionary(s => s.Key, s => s.Select(s => new StudentM
                          {
                              Nume = s.Nume,
                              Prenume = s.Prenume,
                              MateriaPreferata = context.Cursuri.Where(c => c.Id == s.Cursuri.FirstOrDefault().CursId).FirstOrDefault().Nume,
                              Materii = context.Cursuri.Where(c => s.Cursuri.Select(cc => cc.CursId).Contains(c.Id)).Select(c => c.Nume).ToList()
                          }).ToList())
                        };
                        


                        
                        foreach (var e in std.Studenti)
                        {
                            Console.WriteLine(e.Key.Nume);
                            foreach(var s in e.Value)
                            {
                                Console.Write(s.Nume + " " + s.Prenume + " "+ s.MateriaPreferata + " - Materii la care este inscris: ");
                                
                                foreach(var m in s.Materii)
                                {
                                    Console.Write(m + ", ");
                                }

                                Console.WriteLine();
                            }
                        }
                    
                       
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                        
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
