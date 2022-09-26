using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        //public DbSet<>  { get; set; }
        //public DbSet<>  { get; set; }
    }
}