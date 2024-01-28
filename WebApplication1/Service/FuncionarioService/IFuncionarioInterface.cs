// Nessa parte do projeto é onde temos todos os Métodos que serão utilizados no controller FuncionarioController.

using WebApplication1.Models;

namespace WebApplication1.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        // Task é uma operaçao assincrona, ou seja, ela espera retorno da resposta de uma requisiçao no banco de dados, antes de continuar a execuçao do codigo, para evitar erros de execuçao.
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
