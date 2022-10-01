using Microsoft.EntityFrameworkCore;


namespace API.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) { }
        public DbSet<Aluno> Alunos { get; set;} 
        public DbSet<Professor> Professores { get; set;}
        public DbSet<Turma> Turmas { get; set;}
        public DbSet<Disciplina> Disciplinas { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("Alunos"); 
            modelBuilder.Entity<Professor>().ToTable("Professores");
            modelBuilder.Entity<Turma>().ToTable("Turmas");
            modelBuilder.Entity<Disciplina>().ToTable("Disciplinas");
        }


    }
}