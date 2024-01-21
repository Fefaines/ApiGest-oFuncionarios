using Microsoft.EntityFrameworkCore;
using WebApplication1.DataContext;
using WebApplication1.Models;


namespace WebApplication1.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {

        private readonly ApplicationDbContext _context;


        //Injeçao de dependencia para ter acesso ao banco de dados
        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (novoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionario não localizado.";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionario()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            //Etapa de filtragem de erro para não passar erro para o front-end.
            try
            {
                //Aqui é onde é feita a requisição no banco de dados, para pegar todos os funcionarios.
                serviceResponse.Dados = _context.Funcionarios.ToList();
                if (serviceResponse.Dados.Count == 0) // Verificar se a lista está vazia e retornar uma mensagem
                {
                    serviceResponse.Mensagem = "Nenhum funcionario encontrado";

                }
            }

            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                //Pedindo ao banc de dados trazer informações do funcionario que tenha o id igual ao id passado na requisição.
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);
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
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }




        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }
                

                _context.Funcionarios.Update(editadoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}