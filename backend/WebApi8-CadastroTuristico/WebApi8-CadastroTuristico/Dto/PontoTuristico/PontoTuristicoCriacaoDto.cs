using WebApi8_CadastroTuristico.Dto.PontoTuristico.Vinculo;
using WebApi8_CadastroTuristico.Models;

namespace WebApi8_CadastroTuristico.Dto.PontoTuristico {
    public class PontoTuristicoCriacaoDto {

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public string Cidade { get; set; }
        public string DataInclusao { get; set; }

        //indica que cada ponto turistico pode ter apenas 1 estado
        public EstadoVinculoDto Estado { get; set; }
    }
}
