// Nessa parte do projeto é onde temos todos os Métodos que serão utilizados no controller FuncionarioController. Ele existe para que possamos separar as responsabilidades do controller, para que ele fique mais limpo e organizado.

using WebApplication1.Models;

namespace WebApplication1.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        // GetFuncionario() é nome que damos ao metodo que retorna uma lista de FuncionarioModel, que é um modelo de dados que representa a tabela Funcionario no banco de dados.
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionario();

        // CreateFuncionario() é nome que damos ao metodo que cria um novo FuncionarioModel no banco de dados.
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario);

        //Consulta um funcionario pelo id
        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);

        //Atualiza um funcionario
        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario);

        //Deleta um funcionario
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);

    }
}
