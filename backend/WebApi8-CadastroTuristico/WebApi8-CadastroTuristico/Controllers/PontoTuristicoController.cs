using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_CadastroTuristico.Dto.Estado;
using WebApi8_CadastroTuristico.Dto.PontoTuristico;
using WebApi8_CadastroTuristico.Models;
using WebApi8_CadastroTuristico.Services.Estado;
using WebApi8_CadastroTuristico.Services.PontoTuristico;

namespace WebApi8_CadastroTuristico.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PontoTuristicoController : ControllerBase {

        //acessa todos os metodos de interface
        private readonly IPontoTuristicoInterface _pontoTuristicoInterface;
        public PontoTuristicoController(IPontoTuristicoInterface pontoTuristicoInterface) {
            _pontoTuristicoInterface = pontoTuristicoInterface;
        }

        //Action result se refere ao codigo do erro.
        [HttpGet("ListarPontoTuristico")]
        public async Task<ActionResult<ResponseModel<List<PontoTuristicoModel>>>> ListarPontoTuristico() {

            var pontoTuristico = await _pontoTuristicoInterface.ListarPontoTuristico();
            return Ok(pontoTuristico);
        }

        [HttpGet("BuscarPontoTuristicoId/{idPontoTuristico}")]
        public async Task<ActionResult<ResponseModel<PontoTuristicoModel>>> BuscarPontoTuristicoId(int idPontoTuristico) {
            var pontoTuristico = await _pontoTuristicoInterface.BuscarPontoTuristicoId(idPontoTuristico);
            return Ok(pontoTuristico);

        }

        [HttpGet("BuscarPontoTuristicoFiltroAvancado")]
        public async Task<ActionResult<ResponseModel<List<PontoTuristicoModel>>>> BuscarPontoTuristicoFiltroAvancado([FromQuery] string termo) {
            var pontosTuristicos = await _pontoTuristicoInterface.BuscarPontoTuristicoFiltroAvancado(termo);
            return Ok(pontosTuristicos);
        }


        [HttpGet("BuscarPontoTuristicoPorIdEstado/{idEstado}")]
        public async Task<ActionResult<ResponseModel<PontoTuristicoModel>>> BuscarPontoTuristicoPorIdEstado(int idEstado) {
            var pontoTuristico = await _pontoTuristicoInterface.BuscarPontoTuristicoPorIdEstado(idEstado);
            return Ok(pontoTuristico);

        }

        [HttpPost("CriarPontoTuristico")]
        public async Task<ActionResult<ResponseModel<List<PontoTuristicoModel>>>> CriarPontoTuristico(PontoTuristicoCriacaoDto pontoTuristicoCriacaoDto) {
            var pontoTuristico = await _pontoTuristicoInterface.CriarPontoTuristico(pontoTuristicoCriacaoDto);
            return Ok(pontoTuristico);

        }

        [HttpPut("EditarPontoTuristico")]
        public async Task<ActionResult<ResponseModel<List<PontoTuristicoModel>>>> EditarPontoTuristico(PontoTuristicoEdicaoDto pontoTuristicoEdicaoDto) {
            var pontoTuristico = await _pontoTuristicoInterface.EditarPontoTuristico(pontoTuristicoEdicaoDto);
            return Ok(pontoTuristico);

        }

        [HttpDelete("ExcluirPontoTuristico")]
        public async Task<ActionResult<ResponseModel<List<PontoTuristicoModel>>>> ExcluirPontoTuristico(int idPontoTuristico) {
            var pontoTuristico = await _pontoTuristicoInterface.ExcluirPontoTuristico(idPontoTuristico);
            return Ok(pontoTuristico);

        }





    }
}
