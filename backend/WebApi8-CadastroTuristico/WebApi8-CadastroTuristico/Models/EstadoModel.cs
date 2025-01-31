using System.Text.Json.Serialization;

namespace WebApi8_CadastroTuristico.Models {
    public class EstadoModel {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        //indica que um estado pode ter varios pontos turisticos. Pode ter uma lista de pontosTuristicos.
        [JsonIgnore] //na criacao de um estado, ele ignora todos os pontos turistico cadastrados nesse estado
        public ICollection<PontoTuristicoModel> PontosTuristicos { get; set; }

    }
}
