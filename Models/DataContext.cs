using Microsoft.EntityFrameworkCore;


namespace API.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) { }
<<<<<<< HEAD
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        //public DbSet<>  { get; set; }
=======
        public DbSet<Aluno> Alunos { get; set;} 
        public DbSet<Professor> Professores { get; set;}
        public DbSet<Turma> Turmas { get; set;}
        public DbSet<Disciplina> Disciplinas { get; set;}
        public DbSet<AlunoDisciplina> AlunoDisciplinas { get; set;} //Tabela de relacionamento

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
             
            modelBuilder.Entity<Aluno>().ToTable("Alunos"); 
            modelBuilder.Entity<Professor>().ToTable("Professores");
            modelBuilder.Entity<Turma>().ToTable("Turmas");
            modelBuilder.Entity<Disciplina>().ToTable("Disciplinas");
            modelBuilder.Entity<AlunoDisciplina>().ToTable("AlunoDisciplinas");
        }


>>>>>>> Nova_Branch
    }
}