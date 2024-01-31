using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DataContext
{
    public class NewApplicationDbContext:DbContext
    {
        public NewApplicationDbContext(DbContextOptions<NewApplicationDbContext> options) : base(options)
        {
        }

        // Está dizendo ao banco de dados para criar uma tabela chamada Funcionarios, utilizando a mesma estrutura do "NewFuncionarioModel", etc.
        public DbSet<NewFuncionarioModel> CadastroFuncionarios { get; set; }


    }
}

