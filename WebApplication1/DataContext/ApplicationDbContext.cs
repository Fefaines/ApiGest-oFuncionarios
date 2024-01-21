using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DataContext
{
    public class ApplicationDbContext : DbContext // "DbContext está vindo da Framework EntityFrameworkCore"
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Está dizendo ao banco de dados para criar uma tabela chamada Funcionarios, utilizando a mesma estrutura do "FuncionarioMode", etc.
        public DbSet<FuncionarioModel> Funcionarios { get; set; } 
    }

}
