# Documentação do Projeto - Cadastro e Listagem de Pontos Turísticos

Este projeto é uma aplicação desenvolvida em React para o cadastro e listagem de pontos turísticos do Brasil. O sistema conta com funcionalidades para:
- Cadastrar novos pontos turísticos.
- Listar e exibir detalhes dos pontos cadastrados.
- Buscar e filtrar pontos turísticos.

## Começando

Estas instruções ajudarão você a configurar o projeto localmente para desenvolvimento e testes.

### Requisitos

Antes de iniciar, certifique-se de ter instalado:
- **Node.js** (versão 16 ou superior)
- **.NET 8 SDK**
- **SQL Server** (ou um banco compatível com SQL Server)
- **Ferramenta `dotnet-ef` instalada**.


### Instalações

Antes de rodar as migrações, é necessário, caso ainda não tenha feito, instalar a ferramenta dotnet-ef, que é usada para gerenciar migrações do Entity Framework. Para instalá-la, execute o seguinte comando no terminal:

1. dotnet-ef:

```bash
 dotnet tool install --global dotnet-ef
```

Para verificar se a instalação foi bem-sucedida, execute:

```bash
 dotnet ef --version
```

Se a versão for exibida corretamente, a ferramenta está pronta para uso.

2. Clone o repositório:
   ```sh
   git clone https://github.com/davidvanjao/cadastro-turistico.git
   ```

#### Configuração do Frontend

1. Navegue até a pasta do frontend:
   ```sh
   cd frontend/cadastro-ponto-turistico
   ```
2. Instale as dependências:
   ```sh
   npm install
   ```
3. Inicie o servidor de desenvolvimento:
   ```sh
   npm run dev
   ```

A aplicação React estará disponível em `http://localhost:5173`.(O NUMERO DA PORTA APARECE NO PROMPT APOS RODAR O COMANDO NPM RUN DEV)

> **Aviso:** Certifique-se de que a API backend está rodando na porta `7108`. Se não estiver, você precisará alterar a configuração no frontend para apontar para a porta correta. Para isso, abra o arquivo localizado em `./cadastro-ponto-turistico/src/services/api.js` e modifique o valor para a nova porta desejada.

Exemplo:

```javascript
   const api = axios.create({
      baseURL: 'https://localhost:sua_nova_porta/api'
   })
```

#### Configuração do Backend

1. Navegue até o diretório do backend:
   ```bash
   cd backend/WebApi8-CadastroTuristico/WebApi8-CadastroTuristico
   ```

2. Configure a string de conexão no arquivo `appsettings.json`. Substitua `sua_conexao_aqui` com a string de conexão adequada ao seu ambiente: Não esqueca de mudar o campo server com o nome do computador.

```javascript  
   "ConnectionStrings": {
      "DefaultConnection": "sua_conexao_aqui"
   }   

Exemplo de string de conexão para SQL Server local:
"server= NOME_DO_COMPUTADOR; database= SistemaPontoTuristico; trusted_connection= true; trustservercertificate=true"

```

3. Restaure os pacotes:
   ```sh
   dotnet restore
   ```
4. Verifique as versões dos pacotes:
   ```sh
   dotnet list package
   ```
   Certifique-se de que todos os pacotes estão na versão **8.0.3**:
   - Microsoft.EntityFrameworkCore **8.0.3**
   - Microsoft.EntityFrameworkCore.Design **8.0.3**
   - Microsoft.EntityFrameworkCore.SqlServer **8.0.3**
   - Microsoft.EntityFrameworkCore.Tools **8.0.3**
   - Swashbuckle.AspNetCore **6.6.2**  

5. Execute as migrações do banco de dados:
   ```sh
   dotnet ef database update
   ```

6. Execute a aplicação backend:
   ```sh
   dotnet run
   ```

### Testando o projeto

1. Abra o navegador e acesse `http://localhost:PORTA` para visualizar a aplicação. (VERIFICAR A PORTA DO REACT)
2. Certifique-se de que o backend está funcionando corretamente em `http://localhost:PORTA/api/PontoTuristico/ListarPontoTuristico`. (VERIFICAR A PORTA DA API)

### Estrutura do Projeto

1. Frontend (React)
- **`/src`**: Contém os arquivos principais.
  - **`/components`**:
    - `FormularioBuscar.js`: Tela de busca.
    - `FormularioCadastrar.js`: Tela de cadastro.
    - `InfoPontoTuristico.js`: Detalhes do ponto turístico.
    - `ListaResultados.js`: Resultados da pesquisa.
    - `NavBar.js`: Barra de navegação.
  - **`/pages`**:
    - `Cadastro.js`: Tela de cadastro.
    - `Detalhe.js`: Tela de detalhes.
    - `Home.js`: Tela inicial.
  - **`/services`**:
    - `api.js`: Configuração do Axios.

2. Backend (ASP.NET Core)
- **`/Controllers`**:
  - `EstadoController.cs`: Gerencia estados.
  - `PontoTuristicoController.cs`: Gerencia pontos turísticos.
- **`/Dto`**:
  - `EstadoCriacaoDto.cs`, `EstadoEdicaoDto.cs`
  - `PontoTuristicoCriacaoDto.cs`, `PontoTuristicoEdicaoDto.cs`
- **`/Models`**:
  - `EstadoModel.cs`, `PontoTuristicoModel.cs`
- **`/Services`**:
  - `EstadoService.cs`, `IEstadoInterface.cs`
  - `PontoTuristicoService.cs`, `IPontoTuristicoInterface.cs`
- **`/Data`**:
  - `AppDbContext.cs`: Conexão com o banco de dados.

## Endpoints da API

- `http://localhost:7108/api/Estado/ListarEstados` - Lista os estados cadastrados.(VERIFICAR A PORTA DA API)
- `http://localhost:7108/api/PontoTuristico/ListarPontoTuristico` - Lista os pontos turísticos.(VERIFICAR A PORTA DA API)
- `http://localhost:7108/api/PontoTuristico/BuscarPontoTuristicoId/{idPontoTuristico}` - Busca um ponto turístico por ID.(VERIFICAR A PORTA DA API)
- `http://localhost:7108/api/PontoTuristico/BuscarPontoTuristicoFiltroAvancado/{termo}` - Busca por nome, descrição ou localização.(VERIFICAR A PORTA DA API)
- `http://localhost:7108/api/PontoTuristico/CriarPontoTuristico` - Cadastra um novo ponto turístico.(VERIFICAR A PORTA DA API)
- `http://localhost:7108/api/PontoTuristico/EditarPontoTuristico/{idPontoTuristico}` - Edita um ponto turístico.(VERIFICAR A PORTA DA API)
- `http://localhost:7108/api/PontoTuristico/ExcluirPontoTuristico/{idPontoTuristico}` - Exclui um ponto turístico.(VERIFICAR A PORTA DA API)

## Segurança

- A API está configurada para permitir requisições **CORS** do frontend.