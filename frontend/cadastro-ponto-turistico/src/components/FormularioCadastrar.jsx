import { useEffect, useState, useRef } from 'react';
import { useNavigate } from "react-router-dom";
import Api from '../services/api'

const FormularioCadastrar = () => {  
  const navigate = useNavigate();

  //Estados para armazenar os dados
  const [estados, setEstados] = useState([]);
  const [cidades, setCidades] = useState([]);
  const [estadoSelecionado, setEstadoSelecionado] = useState("");
  const [cidadeSelecionada, setCidadeSelecionada] = useState("");

  const [estadoInfo, setEstadoInfo] = useState(null);

  const [nome, setNome] = useState("");
  const [enderecoReferencia, setEnderecoReferencia] = useState("");
  const [descricao, setDescricao] = useState("");

  //Busca os estados ao carregar a página
  useEffect(() => {
    async function getEstados() {
      try {
        const response = await Api.get('/Estado/ListarEstados');
        //Verifica se a resposta contém um array na propriedade "dados"
        if (Array.isArray(response.data.dados)) {
          setEstados(response.data.dados); // Passa apenas o array "dados"
        } else {
          console.error("A API não retornou um array na propriedade 'dados':", response.data);
          setEstados([]); //Define resultados como um array vazio
        }
      } catch (error) {
        console.error("Erro ao buscar estados:", error);
        setEstados([]); //Define resultados como um array vazio em caso de erro
      }
    }

    getEstados();
  }, [])

  //Busca cidades ao selecionar um estado
  useEffect(() => {
    async function getCidades(siglaEstado) {
      if (!siglaEstado) return;
      try {
        const response = await fetch(`https://servicodados.ibge.gov.br/api/v1/localidades/estados/${siglaEstado}/municipios`);
        const data = await response.json();
        setCidades(data);
      } catch (error) {
        console.error("Erro ao buscar cidades do IBGE:", error);
        setCidades([]);
      }
    }
    getCidades(estadoSelecionado);
  }, [estadoSelecionado]);

  // Função para cadastrar o ponto turístico
  async function criarPontoTuristico() {
    if (!estadoInfo || !cidadeSelecionada) {
      alert("Por favor, selecione um estado e uma cidade.");
      return;
    }
  
    const dados = {
      nome: nome,
      descricao: descricao,
      localizacao: enderecoReferencia,
      cidade: cidadeSelecionada,
      dataInclusao: new Date().toISOString().split("T")[0], // Data atual no formato ISO
      estado: estadoInfo, // Objeto estado completo
    };
  
    //Logando os dados antes de enviar
    console.log("Dados a serem enviados:", JSON.stringify(dados, null, 2));
  
    try {
      const response = await Api.post("PontoTuristico/CriarPontoTuristico", dados);
      alert("Ponto turístico cadastrado com sucesso!");
      navigate("/");
    } catch (error) {
      console.error("Erro ao cadastrar ponto turístico:", error);
      alert("Erro ao cadastrar ponto turístico.");
    }
  }
  


  return (
    <div>
        <h2>Cadastrar Ponto Turístico</h2>

        <form className="form-cadastro" onSubmit={(e) => { e.preventDefault(); criarPontoTuristico(); }}>

          <label>Nome:</label>
          <div>
            <input
              type="text"
              name="nome"
              value={nome}
              onChange={(e) => setNome(e.target.value)}
              maxLength="100"
              placeholder="Digite o nome do ponto turístico."
              required
            />
          </div>

          <hr />

          <label>Localização:</label>
          <div className="nameSelect">
            <label>UF/Cidade: </label>

            {/* Dropdown de Estados */}
            <select
              value={estadoSelecionado}
              onChange={(e) => {
                const sigla = e.target.value;
                setEstadoSelecionado(sigla);
                setEstadoInfo(estados.find((estado) => estado.sigla === sigla));
                setCidades([]);
                setCidadeSelecionada("");
              }}
            >
              <option value="">Selecione um estado</option>
              {estados.map((estado) => (
                <option key={estado.id} value={estado.sigla}>
                  {estado.sigla}
                </option>
              ))}
            </select>


            {/* Dropdown de Cidades */}
            <select
              value={cidadeSelecionada}
              onChange={(e) => setCidadeSelecionada(e.target.value)}
              disabled={!estadoSelecionado}
            >
              <option value="">Selecione uma cidade</option>
              {cidades.map((cidade) => (
                <option key={cidade.id} value={cidade.nome}>
                  {cidade.nome}
                </option>
              ))}
            </select>

          </div>

          <label>Endereço ou referência:</label>
          <div>
            <input
              type="text"
              name="enderecoReferencia"
              value={enderecoReferencia}
              onChange={(e) => setEnderecoReferencia(e.target.value)}
              maxLength="100"
              placeholder="Digite o endereço ou referência."
              required
            />
          </div>

          <hr/>

          <label>Descrição:</label>
          <div>
            <textarea
              name="descricao"
              value={descricao}
              onChange={(e) => setDescricao(e.target.value)}
              id="mensagem"
              rows="6"
              maxLength="100"
              placeholder="Digite a descrição com até 100 caracteres."
              required
            />
          </div>

          <div className="botaoAcao">
            <button type='button' onClick={() => navigate("/")}>Voltar</button>
            <button type="submit" >Cadastrar</button>
          </div>

        </form>


    </div>
  );
};
  
export default FormularioCadastrar
