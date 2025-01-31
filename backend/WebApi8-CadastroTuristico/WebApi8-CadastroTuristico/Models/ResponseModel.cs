namespace WebApi8_CadastroTuristico.Models {
    
    //classe de respostas
    public class ResponseModel<T> { //T tipo generico, recebe qualquer tipo de dado.
        public T? Dados { get; set; } //? diz que o valor pode ser nulo.
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
