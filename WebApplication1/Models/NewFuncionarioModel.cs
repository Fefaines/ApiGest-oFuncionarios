using System.ComponentModel.DataAnnotations;
using WebApplication1.Enums;

namespace WebApplication1.Models
{
    public class NewFuncionarioModel

    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DepartamentoEnum Departamento { get; set; }
        public string RG { get; set; }
        public byte[] Foto { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();


    }
}

