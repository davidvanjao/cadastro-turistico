import React, { useState } from 'react';

const FormularioBusca = ({ onBuscar }) => {
  const [termo, setTermo] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    onBuscar(termo); // Passa o termo de busca para a função `onBuscar`
  };

  return (
    <form onSubmit={handleSubmit} className="formulario-busca">
      <input
        type="text"
        placeholder="Digite um termo para busca, nome, descrição ou localização."
        value={termo}
        onChange={(e) => setTermo(e.target.value)}
      />
      <button type="submit">Buscar</button>
    </form>
  );
};

export default FormularioBusca;