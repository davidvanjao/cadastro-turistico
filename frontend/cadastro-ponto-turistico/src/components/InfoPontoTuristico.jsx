import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import Api from '../services/api';

const Info = () => {
  const navigate = useNavigate();
  const { id } = useParams();

  const [resultado, setResultado] = useState(null); //Altere para null para melhor verificação de carregamento

  async function getPontosTuristicos() {
    try {
      const response = await Api.get(`/PontoTuristico/BuscarPontoTuristicoId/${id}`);
      if (response.data.dados) {
        setResultado(response.data.dados); //Agora armazenamos diretamente o objeto, sem precisar de array
      } else {
        console.error("A API não retornou dados:", response.data);
        setResultado(null);
      }
    } catch (error) {
      console.error("Erro ao buscar ponto turístico:", error);
      setResultado(null);
    }
  }

  useEffect(() => {
    getPontosTuristicos();
  }, [id]);

  //excluir ponto turistico
  async function excluirPontoTuristico(id) {

    //Exibe um alerta de confirmação antes de excluir
    const confirmar = window.confirm("Tem certeza que deseja excluir este ponto turístico?");
    
    if (!confirmar) {
      return; //Cancela a exclusão se o usuário não confirmar
    }

    try {
      const response = await Api.delete(`/PontoTuristico/ExcluirPontoTuristico?idPontoTuristico=${id}`);
  
      if (response.status === 200) {
        alert("Ponto turístico excluído com sucesso!");
        navigate("/"); // Redireciona para a página inicial
      } else {
        alert("Erro ao excluir o ponto turístico.");
      }
    } catch (error) {
      console.error("Erro ao excluir ponto turístico:", error);
      alert("Ocorreu um erro ao tentar excluir.");
    }
  }

  return (
    <div>
      {/* Verifica se os dados foram carregados */}
      {resultado ? (
        <>
          <h2>{resultado.nome}</h2>

          <table>
            <thead>
              <tr>
                <th>Id</th>
                <th>Localização</th>
                <th>Cidade</th>
                <th>Estado</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>{resultado.id}</td>
                <td>{resultado.localizacao}</td>
                <td>{resultado.cidade}</td>
                <td>{resultado.estado?.sigla || "Não informado"}</td> 
              </tr>
            </tbody>
          </table>

          <textarea 
            name="descricao"
            id="mensagem"
            rows="4"
            placeholder="Digite a descrição"
            defaultValue={resultado?.descricao || ""}
            disabled
          />

        </>
      ) : (
        <p>Carregando ou sem resultados...</p>
      )}

      <div className="botaoAcao">
        <button type='button' onClick={() => navigate("/")}>Voltar</button>
        <button className="botaoExcluir" onClick={() => excluirPontoTuristico(id)}>Excluir</button>
      </div>
    </div>
  );
};

export default Info;
