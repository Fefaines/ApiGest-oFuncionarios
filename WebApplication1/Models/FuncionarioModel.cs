using System.ComponentModel.DataAnnotations;
using WebApplication1.Enums;

namespace WebApplication1.Models
{
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DepartamentoEnum Departamento { get; set; }

    }
}
