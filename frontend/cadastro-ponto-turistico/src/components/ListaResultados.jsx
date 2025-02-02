import React, { useState } from 'react';
import { useNavigate } from "react-router-dom";

const ListaResultados = ({ resultados }) => {
  const navigate = useNavigate();
  const [paginaAtual, setPaginaAtual] = useState(1); // Estado para controlar a página atual
  const itensPorPagina = 3; //Número de itens por página

  //Calcular os índices dos itens da página atual
  const indiceUltimoItem = paginaAtual * itensPorPagina;
  const indicePrimeiroItem = indiceUltimoItem - itensPorPagina;
  const itensPaginaAtual = resultados.slice(indicePrimeiroItem, indiceUltimoItem);

  console.log(itensPaginaAtual); 

  //Função para mudar de página
  const mudarPagina = (numeroPagina) => {
    setPaginaAtual(numeroPagina);
  };

  if (resultados.length === 0) {
    return <p className="sem-resultados">Não foi encontrado nenhum resultado para sua busca!</p>;
  }

  return (
    <div>
      <ul className="lista-resultados">
        {itensPaginaAtual.map((resultado) => (
          <li key={resultado.id} className="item-resultado">
            <div className="info-resultado">
              <div><strong>{resultado.nome}</strong> ({resultado.dataInclusao.split('-').reverse().join('/')})</div>
              <div><p>{resultado.localizacao+" - "+resultado.estado.nome+"/"+resultado.estado.sigla}</p></div>
            </div>
            <button className="botao-detalhes" onClick={() => navigate(`detalhes/${resultado.id}`)}>
              Mais Detalhes
            </button>
          </li>
        ))}
      </ul>

      {/* Componente de Paginação */}
      <div className="paginacao">
        <button
          onClick={() => mudarPagina(paginaAtual - 1)}
          disabled={paginaAtual === 1} //Desabilita o botão "Anterior" na primeira página
        >
          Anterior
        </button>
        <span>Página {paginaAtual}</span>
        <button
          onClick={() => mudarPagina(paginaAtual + 1)}
          disabled={indiceUltimoItem >= resultados.length} //Desabilita o botão "Próxima" na última página
        >
          Próxima
        </button>
      </div>
    </div>
  );
};

export default ListaResultados;