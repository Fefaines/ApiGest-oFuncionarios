namespace WebApplication1.Models
{
    public class DepartamentoId
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<FuncionarioModel> Funcionarios { get; set; }

        public DepartamentoId(List<FuncionarioModel> funcionarios)
        {
            Funcionarios = funcionarios;
        }
    }
}
