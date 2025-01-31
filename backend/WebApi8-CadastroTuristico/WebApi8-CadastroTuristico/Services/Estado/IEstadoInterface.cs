using WebApi8_CadastroTuristico.Dto.Estado;
using WebApi8_CadastroTuristico.Models;

namespace WebApi8_CadastroTuristico.Services.Estado {
    public interface IEstadoInterface {

        //Task metodo asincrono, tipo de retorno reponseModel, tipo List retorna lista de Autor Model
        Task<ResponseModel<List<EstadoModel>>> ListarEstados();
        Task<ResponseModel<EstadoModel>> BuscarEstadoPorId(int idEstado);
        Task<ResponseModel<EstadoModel>> BuscarEstadoPorIdPontoTuristico(int idPontoTuristico);
        Task<ResponseModel<List<EstadoModel>>> CriarEstado(EstadoCriacaoDto estadoCriacaoDto); //recebe variaveis da classe estadodto

        Task<ResponseModel<List<EstadoModel>>> EditarEstado(EstadoEdicaoDto estadoEdicaoDto);

        Task<ResponseModel<List<EstadoModel>>> ExcluirEstado(int idEstado);


    }
}
