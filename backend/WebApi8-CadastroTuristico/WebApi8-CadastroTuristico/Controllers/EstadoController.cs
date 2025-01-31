using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_CadastroTuristico.Dto.Estado;
using WebApi8_CadastroTuristico.Models;
using WebApi8_CadastroTuristico.Services.Estado;

namespace WebApi8_CadastroTuristico.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase {

        //acessa todos os metodos de interface
        private readonly IEstadoInterface _estadoInterface;
        public EstadoController(IEstadoInterface estadoInterface) {
            _estadoInterface = estadoInterface;
        }

        //Action result se refere ao codigo do erro.
        [HttpGet("ListarEstados")]
        public async Task<ActionResult<ResponseModel<List<EstadoModel>>>> ListarEstados() {

            var estados = await _estadoInterface.ListarEstados();
            return Ok(estados);
        }

        [HttpGet("BuscarEstadoPorId/{idEstado}")]
        public async Task<ActionResult<ResponseModel<EstadoModel>>> BuscarEstadoPorId(int idEstado) {
            var estado = await _estadoInterface.BuscarEstadoPorId(idEstado);
            return Ok(estado);

        }


        [HttpGet("BuscarEstadoPorIdPontoTuristico/{idPontoTuristico}")]
        public async Task<ActionResult<ResponseModel<EstadoModel>>> BuscarEstadoPorIdPontoTuristico(int idPontoTuristico) {
            var estado = await _estadoInterface.BuscarEstadoPorIdPontoTuristico(idPontoTuristico);
            return Ok(estado);

        }

        [HttpPost("CriarEstado")]
        public async Task<ActionResult<ResponseModel<List<EstadoModel>>>> CriarEstado(EstadoCriacaoDto estadoCriacaoDto) {
            var estados = await _estadoInterface.CriarEstado(estadoCriacaoDto);
            return Ok(estados);

        }

        [HttpPut("EditarEstado")]
        public async Task<ActionResult<ResponseModel<List<EstadoModel>>>> EditarEstado(EstadoEdicaoDto estadoEdicaoDto) {
            var estados = await _estadoInterface.EditarEstado(estadoEdicaoDto);
            return Ok(estados);

        }

        [HttpDelete("ExcluirEstado")]
        public async Task<ActionResult<ResponseModel<List<EstadoModel>>>> ExcluirEstado(int idEstado) {
            var estados = await _estadoInterface.ExcluirEstado(idEstado);
            return Ok(estados);

        }











    }
}
