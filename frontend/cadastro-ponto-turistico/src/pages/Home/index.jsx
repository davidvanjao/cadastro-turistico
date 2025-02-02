import { useEffect, useState, useRef } from 'react';
//import Navbar from "../../components/NavBar";
import FormularioBusca from "../../components/FormularioBuscar";
import ListaResultados from "../../components/ListaResultados";
import Logo from './../../assets/logoTipo.jpg'
import Api from './../../services/api'
import './style.css'

import { useNavigate } from 'react-router-dom'; // Importação correta

const Home = () => {
  //inicializacao da navegacao
  const navigate = useNavigate(); // Inicializa o useNavigate

  const [resultados, setResultados] = useState([]);

  async function getPontosTuristicos() {
    try {
      const response = await Api.get('/PontoTuristico/ListarPontoTuristico');
      //Verifica se a resposta contém um array na propriedade "dados"
      if (Array.isArray(response.data.dados)) {
        setResultados(response.data.dados); // Passa apenas o array "dados"
      } else {
        console.error("A API não retornou um array na propriedade 'dados':", response.data);
        setResultados([]); // Define resultados como um array vazio
      }
    } catch (error) {
      console.error("Erro ao buscar pontos turísticos:", error);
      setResultados([]); // Define resultados como um array vazio em caso de erro
    }
  }

  const handleBuscar = async (termo) => {
    try {
      const response = await Api.get(`/PontoTuristico/BuscarPontoTuristicoFiltroAvancado`, {
        params: { termo }
      });
  
      // Verifica se a resposta contém dados
      if (response.data.dados) {
        setResultados(response.data.dados);
      } else {
        setResultados([]); // Se não houver resultados, define um array vazio
      }
    } catch (error) {
      console.error("Erro ao buscar pontos turísticos:", error);
      setResultados([]); // Em caso de erro, evita que a tela quebre
    }
  };

  //execulta assim que a pagina é carregada
  useEffect(() => {
    getPontosTuristicos();
  }, [])
  
  

  return(

    <div className="tela-home">
      <div className="formulario-cadastrar">
        <div><img src={Logo}/></div>
        <div><button type='button' onClick={() => navigate("/cadastrar")}>Cadastrar um ponto turístico</button></div>
      </div>

      <FormularioBusca onBuscar={handleBuscar} />
      <ListaResultados resultados={resultados}/>

    </div>

  )
}

export default Home;