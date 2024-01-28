// Nessa parte do projeto é onde temos todos os Métodos que serão utilizados na controller FuncionarioController.

using Microsoft.EntityFrameworkCore;
using WebApplication1.DataContext;
using WebApplication1.Models;


namespace WebApplication1.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {

        private readonly ApplicationDbContext _context;

        //O construtor está inicializando a instância de FuncionarioService com um DbContext
        //Injeçao de dependencia para ter acesso ao banco de dados
        //DbContext é uma classe fundamental na biblioteca Entity Framework, que é um framework de mapeamento objeto-relacional (ORM) para o .NET. 
        //O Entity Framework facilita o trabalho com bancos de dados relacionais ao permitir que você manipule dados usando objetos em vez de escrever instruções SQL diretamente.
        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Método que cria um novo funcionario. Ele está recebendo um objeto do tipo FuncionarioModel, que é o modelo de dados que representa a tabela Funcionario no banco de dados.
        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();


            //Etapa de filtragem de erro para não passar erro para o front-end.
            try
            {
                // Verifica se o objeto novoFuncionario é nulo, se for, retorna uma mensagem de erro.
                if (novoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                // Adiciona o novoFuncionario ao contexto do banco de dados
                _context.Add(novoFuncionario);

                // Salva as alterações assincronamente no banco de dados
                await _context.SaveChangesAsync();

                // Atualiza os dados no ServiceResponse com a lista de todos os funcionários após a adição
                serviceResponse.Dados = _context.Funcionarios.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }


        //Método que deleta o Funcionario
        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            //Cria uma nova instância de ServiceResponse para armazenar a resposta da operação.
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                // Busca o funcionário no contexto do banco de dados pelo ID
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);

                //// Verifica se o funcionário foi encontrado e traz uma mensagem caso não seja encontrado, tornando o sucesso falso.
                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionario não localizado.";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                // Remove o funcionário do contexto do banco de dados
                _context.Funcionarios.Remove(funcionario);

                // Salva as alterações no banco de dados de forma assíncrona
                await _context.SaveChangesAsync();

                // Atualiza os dados no ServiceResponse com a lista de todos os funcionários após a remoção
                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        //Método que Lista todos os funcinários:
        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionario()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                //// Obtém a lista de funcionários do contexto do banco de dados
                serviceResponse.Dados = _context.Funcionarios.ToList();

                // Verificar se a lista está vazia e retornar uma mensagem
                if (serviceResponse.Dados.Count == 0) 
                {
                    serviceResponse.Mensagem = "Nenhum funcionario encontrado";

                }
            }

            catch (Exception ex)
            {
                // Se ocorrer uma exceção durante a execução do bloco try, captura a exceção
                // e define as propriedades Mensagem e Sucesso no ServiceResponse para refletir o erro.
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        //Método que traz o funcionário a partir de um parâmetro Id.
        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                // Tenta obter informações do funcionário com o ID fornecido do contexto do banco de dados.
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);

                // Verifica se o funcionário foi encontrado. Caso negativo ele exibirá uma mensagem de erro.
                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionario não encontrado";
                    serviceResponse.Sucesso = false;


                }
                serviceResponse.Dados = funcionario;
            }
            catch (Exception ex)
            {
                // Em caso de exceção, atualiza o ServiceResponse com a mensagem de erro.
                serviceResponse.Mensagem = ex.Message;

                // Define a propriedade Sucesso como false para indicar que a operação falhou.
                serviceResponse.Sucesso = false;
            }

            // Retorna o ServiceResponse, que contém informações sobre o resultado da operação
            return serviceResponse;
        }

        //Método que 
        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                // Tenta obter as informações do funcionário original (sem rastreamento) pelo ID fornecido.
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);

                // Verifica se o funcionário foi encontrado. Caso negativo ele exibirá uma mensagem de erro.
                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                // Atualiza o contexto do banco de dados com as informações do funcionário editado.
                _context.Funcionarios.Update(editadoFuncionario);

                // Salva as alterações no banco de dados de forma assíncrona
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }

            catch (Exception ex)
            {
                // Em caso de exceção, atualiza o ServiceResponse com a mensagem de erro. Após isso indica que não houve sucesso.
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            // Retorna o ServiceResponse, que contém informações sobre o resultado da operação.
            return serviceResponse;
        }
    }
}