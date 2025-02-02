using Microsoft.EntityFrameworkCore;
using WebApi8_CadastroTuristico.Data;
using WebApi8_CadastroTuristico.Dto.Estado;
using WebApi8_CadastroTuristico.Dto.PontoTuristico;
using WebApi8_CadastroTuristico.Models;

namespace WebApi8_CadastroTuristico.Services.PontoTuristico {
    public class PontoTuristicoService : IPontoTuristicoInterface {
        //variavel privada
        private readonly AppDbContext _context;

        //Construtor. recebe conexao com o banco
        public PontoTuristicoService(AppDbContext context) {

            _context = context;


        }

        public async Task<ResponseModel<PontoTuristicoModel>> BuscarPontoTuristicoId(int idPontoTuristico) {
            ResponseModel<PontoTuristicoModel> resposta = new ResponseModel<PontoTuristicoModel>();

            try {
                //pega o primeiro registro que respeita a regra especifica.
                var pontoTuristico = await _context.PontosTuristicos.Include(e => e.Estado)//insere a tabela estados
                    .FirstOrDefaultAsync(pontoTuristicoBanco => pontoTuristicoBanco.Id == idPontoTuristico);
                if (pontoTuristico == null) {

                    resposta.Mensagem = "Nenhum registro localizado.";
                    return resposta;

                }

                resposta.Dados = pontoTuristico;
                resposta.Mensagem = "Ponto Turistico Localizado!";
                return resposta;

            }
            catch (Exception ex) {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                resposta.Mensagem = "Erro ao buscar por Ponto Turistico.";
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PontoTuristicoModel>>> BuscarPontoTuristicoFiltroAvancado(string termoBusca) {
            ResponseModel<List<PontoTuristicoModel>> resposta = new ResponseModel<List<PontoTuristicoModel>>();

            try {
                // Faz a busca ignorando maiúsculas e minúsculas
                var pontosTuristicos = await _context.PontosTuristicos
                    .Include(e => e.Estado) // Insere a tabela estados
                    .Where(p => EF.Functions.Like(p.Nome, $"%{termoBusca}%") ||
                                EF.Functions.Like(p.Descricao, $"%{termoBusca}%") ||
                                EF.Functions.Like(p.Localizacao, $"%{termoBusca}%"))
                    .ToListAsync();

                if (pontosTuristicos == null || !pontosTuristicos.Any()) {
                    resposta.Mensagem = "Nenhum registro localizado.";
                    resposta.Dados = new List<PontoTuristicoModel>();
                    return resposta;
                }

                resposta.Dados = pontosTuristicos;
                resposta.Mensagem = "Pontos turísticos localizados!";
                return resposta;
            }
            catch (Exception ex) {
                resposta.Mensagem = "Erro ao buscar por pontos turísticos.";
                resposta.Status = false;
                return resposta;
            }
        }
        
        public async Task<ResponseModel<List<PontoTuristicoModel>>> BuscarPontoTuristicoPorIdEstado(int idEstado) {
            ResponseModel<List<PontoTuristicoModel>> resposta = new ResponseModel<List<PontoTuristicoModel>>();

            try {

                var pontoTurisco = await _context.PontosTuristicos
                    .Include(e => e.Estado)
                    .Where(pontoTuristicoBanco => pontoTuristicoBanco.EstadoId == idEstado)
                    .ToListAsync();



                if (pontoTurisco == null) {

                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;

                }

                resposta.Dados = pontoTurisco;
                resposta.Mensagem = "Ponto turistico localizado!";
                return resposta;






            }
            catch (Exception ex) {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PontoTuristicoModel>>> CriarPontoTuristico(PontoTuristicoCriacaoDto pontoTuristicoCriacaoDto) {

            ResponseModel<List<PontoTuristicoModel>> resposta = new ResponseModel<List<PontoTuristicoModel>>();

            try {
                //aguardo tudo acontecer, entro no banco estados, pego o primeiro resultado onde id de estado for igual ao enviado pelo dto
                var estado = await _context.Estados
                    .FirstOrDefaultAsync(estadoBanco => estadoBanco.Id == pontoTuristicoCriacaoDto.Estado.Id);

                if (estado == null) {

                    resposta.Mensagem = "Nenhum registro de estado localizado!";
                    return resposta;
               
                }

                var pontoTuristico = new PontoTuristicoModel() {

                    Nome = pontoTuristicoCriacaoDto.Nome,
                    Descricao = pontoTuristicoCriacaoDto.Descricao,
                    Localizacao = pontoTuristicoCriacaoDto.Localizacao,
                    Cidade = pontoTuristicoCriacaoDto.Cidade,
                    Estado = estado,
                    DataInclusao = pontoTuristicoCriacaoDto.DataInclusao
                };

                _context.Add(pontoTuristico);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.PontosTuristicos
                    .Include(e => e.Estado)
                    .ToListAsync();

                resposta.Mensagem = "Ponto turistico criado com sucesso!";
                return resposta;


            }
            catch (Exception ex) {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                resposta.Dados = await _context.PontosTuristicos.Include(a => a.Estado).ToListAsync();
                return resposta;



            }
        }

        public async Task<ResponseModel<List<PontoTuristicoModel>>> EditarPontoTuristico(PontoTuristicoEdicaoDto pontoTuristicoEdicaoDto) {

            //variavel de resposta
            ResponseModel<List<PontoTuristicoModel>> resposta = new ResponseModel<List<PontoTuristicoModel>>();

            try {

                var pontoTuristico = await _context.PontosTuristicos
                    .Include(e => e.Estado)
                    .FirstOrDefaultAsync(pontoTuristicoBanco => pontoTuristicoBanco.Id == pontoTuristicoEdicaoDto.Id);

                var estado = await _context.Estados.FirstOrDefaultAsync(estadoBanco => estadoBanco.Id == pontoTuristico.Estado.Id);

                if (pontoTuristico == null) {
                    resposta.Mensagem = "Nenhum registro de Ponto turistico localizado!";
                    return resposta;
                }

                if (estado == null) {
                    resposta.Mensagem = "Nenhum registro de estado localizado!";
                    return resposta;
                }

                pontoTuristico.Nome = pontoTuristicoEdicaoDto.Nome;
                pontoTuristico.Descricao = pontoTuristicoEdicaoDto.Descricao;
                pontoTuristico.Localizacao = pontoTuristicoEdicaoDto.Localizacao;
                pontoTuristico.Cidade = pontoTuristicoEdicaoDto.Cidade;
                pontoTuristico.Estado = estado;
                pontoTuristico.DataInclusao = pontoTuristicoEdicaoDto.DataInclusao;

                _context.Update(pontoTuristico);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.PontosTuristicos.ToListAsync();
                resposta.Mensagem = "Ponto turistico editado com sucesso!";
                return resposta;

            }
            catch (Exception ex) {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<PontoTuristicoModel>>> ExcluirPontoTuristico(int idPontoTuristico) {

            ResponseModel<List<PontoTuristicoModel>> resposta = new ResponseModel<List<PontoTuristicoModel>>();

            try {

                var pontoTuristico = await _context.PontosTuristicos
                    .FirstOrDefaultAsync(pontoTuristico => pontoTuristico.Id == idPontoTuristico);

                if (pontoTuristico == null) {
                    resposta.Mensagem = "Nenhum ponto turistico localizado!";
                    return resposta;

                }

                _context.Remove(pontoTuristico);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.PontosTuristicos.ToListAsync();
                resposta.Mensagem = "Ponto turistico removido com sucesso!";
                return resposta;

            }
            catch (Exception ex) {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<PontoTuristicoModel>>> ListarPontoTuristico() {
            //objeto de resposta
            ResponseModel<List<PontoTuristicoModel>> resposta = new ResponseModel<List<PontoTuristicoModel>>();

            //se acontecer algum erro, cai dentro do catch
            try {

                var pontoTuristico = await _context.PontosTuristicos
                    .Include(a => a.Estado)
                    .OrderByDescending(pto => pto.DataInclusao)
                    .ToListAsync();               

                resposta.Dados = pontoTuristico;
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
