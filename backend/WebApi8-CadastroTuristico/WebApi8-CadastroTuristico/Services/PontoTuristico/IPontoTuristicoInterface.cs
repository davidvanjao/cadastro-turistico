using WebApi8_CadastroTuristico.Dto.Estado;
using WebApi8_CadastroTuristico.Dto.PontoTuristico;
using WebApi8_CadastroTuristico.Models;

namespace WebApi8_CadastroTuristico.Services.PontoTuristico {
    public interface IPontoTuristicoInterface {

        //Task metodo asincrono, tipo de retorno reponseModel, tipo List retorna lista de Ponto turistivo Model
        Task<ResponseModel<List<PontoTuristicoModel>>> ListarPontoTuristico();
        Task<ResponseModel<PontoTuristicoModel>> BuscarPontoTuristicoId(int idPontoTuristico);
        Task<ResponseModel<List<PontoTuristicoModel>>> BuscarPontoTuristicoPorIdEstado(int idEstado);
        Task<ResponseModel<List<PontoTuristicoModel>>> CriarPontoTuristico(PontoTuristicoCriacaoDto pontoTuristicoCriacaoDto); //recebe variaveis da classe estadodto
        Task<ResponseModel<List<PontoTuristicoModel>>> EditarPontoTuristico(PontoTuristicoEdicaoDto pontoTuristicoEdicaoDto);
        Task<ResponseModel<List<PontoTuristicoModel>>> ExcluirPontoTuristico(int idPontoTuristico);
    }
}
