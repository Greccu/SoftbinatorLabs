using System;
using DBCS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DBCS
{
    public partial class DBDBContext : DbContext
    {
        public DBDBContext()
        {
        }

        public DBDBContext(DbContextOptions<DBDBContext> options)
            : base(options)
        {
           
        }

        public DbSet<Student> Studenti { get; set; }
        public DbSet<Facultate> Facultati { get; set; }

        public DbSet<Curs> Cursuri { get; set; }

        public DbSet<StudentCurs> StudentCurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=GRECU;Initial Catalog=DBDB;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
