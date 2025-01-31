using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApi8_CadastroTuristico.Data;
using WebApi8_CadastroTuristico.Dto.Estado;
using WebApi8_CadastroTuristico.Models;

namespace WebApi8_CadastroTuristico.Services.Estado {

    //ligacao do service com interface. Implementa os metodos que estao em interface
    public class EstadoService : IEstadoInterface {

        //variavel privada
        private readonly AppDbContext _context;

        //Construtor. recebe conexao com o banco
        public EstadoService(AppDbContext context) {

            _context = context;


        }

        public async Task<ResponseModel<EstadoModel>> BuscarEstadoPorId(int idEstado) {

            ResponseModel<EstadoModel> resposta = new ResponseModel<EstadoModel>();

            try {
                //pega o primeiro registro que respeita a regra especifica.
                var estado = await _context.Estados.FirstOrDefaultAsync(estadoBanco => estadoBanco.Id == idEstado);
                if (estado == null) {

                    resposta.Mensagem = "Nenhum registro localizado.";
                    return resposta;
                
                }

                resposta.Dados = estado;
                resposta.Mensagem = "Estado Localizado!";
                return resposta;

            }
            catch (Exception ex) {
                
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                resposta.Mensagem = "Erro ao buscar por Estado.";
                return resposta;
            }
            
        }

        public async Task<ResponseModel<EstadoModel>> BuscarEstadoPorIdPontoTuristico(int idPontoTuristico) {

            ResponseModel<EstadoModel> resposta = new ResponseModel<EstadoModel>();

            try {

                //entrar na tabela ponto turistico, pergar o id, e acessar o idEstado que esta na linha do ponto turistico
                //include entra dentro do ponto turisco, acessa a variavel chamada estado e pega todas as informacoes de estado
                var pontoTuristico = await _context.PontosTuristicos.
                    Include(e => e.Estado) //e variavel qualquer
                    .FirstOrDefaultAsync(estadoBanco => estadoBanco.Id == idPontoTuristico); //dentro da tabela estad

                if (pontoTuristico == null) {

                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;    
                
                }

                resposta.Dados = pontoTuristico.Estado;
                resposta.Mensagem = "Estado localizado!";
                return resposta;






            }
            catch (Exception ex) {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<EstadoModel>>> CriarEstado(EstadoCriacaoDto estadoCriacaoDto) {

            ResponseModel<List<EstadoModel>> resposta = new ResponseModel<List<EstadoModel>>();

            try {

                var estado = new EstadoModel() {

                    Nome = estadoCriacaoDto.Nome,
                    Sigla = estadoCriacaoDto.Sigla
                };

                _context.Add(estado); //abrimo o banco, damos um adicionar
                await _context.SaveChangesAsync(); //esperamos as informacoes serem salvas

                //entra no banco, entra dentro de estados, e tras os resultados
                resposta.Dados = await _context.Estados.ToListAsync();
                resposta.Mensagem = "Estado criado com sucesso!";
                return resposta;




            }
            catch (Exception ex) {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;



            }








        }

        public async Task<ResponseModel<List<EstadoModel>>> EditarEstado(EstadoEdicaoDto estadoEdicaoDto) {
            //variavel de resposta
            ResponseModel<List<EstadoModel>> resposta = new ResponseModel<List<EstadoModel>>();

            try {

                var estado = await _context.Estados.FirstOrDefaultAsync(estadoBanco => estadoBanco.Id == estadoEdicaoDto.Id);

                if (estado == null) {
                    resposta.Mensagem = "Nenhum estado localizado!";
                    return resposta;
                }

                estado.Nome = estadoEdicaoDto.Nome;
                estado.Sigla = estadoEdicaoDto.Sigla;

                _context.Update(estado);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Estados.ToListAsync();
                resposta.Mensagem = "Estado editado com sucesso!";
                return resposta;

            }
            catch (Exception ex) {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }





        }

        public async Task<ResponseModel<List<EstadoModel>>> ExcluirEstado(int idEstado) {

            ResponseModel<List<EstadoModel>> resposta = new ResponseModel<List<EstadoModel>>();

            try {

                var estado = await _context.Estados
                    .FirstOrDefaultAsync(estadoBanco => estadoBanco.Id == idEstado);

                if (estado == null) {
                    resposta.Mensagem = "Nenhum estado localizado!";
                    return resposta;
                
                }

                _context.Remove(estado);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Estados.ToListAsync();
                return resposta;

            }
            catch (Exception ex) {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }


        }

        //metodo asyncrono. Serve para esperar a resposta
        public async Task<ResponseModel<List<EstadoModel>>> ListarEstados() {

            //objeto de resposta
            ResponseModel<List<EstadoModel>> resposta = new ResponseModel<List<EstadoModel>>();

            //se acontecer algum erro, cai dentro do catch
            try {

                //entrei no banco, entrei na tabela estados, transformei em lista todos os estados.
                //metodo await espera a resposta antes de prosseguir.
                var estados = await _context.Estados.ToListAsync();

                resposta.Dados = estados;
                resposta.Mensagem = "Todos os estados foram carregados!";

                return resposta;



            }
            catch (Exception ex) { 

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            
            }
        }
    }
}
