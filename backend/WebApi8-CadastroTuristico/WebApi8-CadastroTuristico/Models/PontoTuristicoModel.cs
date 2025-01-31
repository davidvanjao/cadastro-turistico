namespace WebApi8_CadastroTuristico.Models {
    public class PontoTuristicoModel {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public string Cidade { get; set; }
        public int EstadoId { get; set; }
        public string DataInclusao { get; set; }

        //indica que cada ponto turistico pode ter apenas 1 estado
        public EstadoModel Estado { get; set; }

    }
}
