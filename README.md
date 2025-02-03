# Documentação do Projeto - Cadastro e Listagem de Pontos Turísticos

Este projeto é uma aplicação desenvolvida com React, com o objetivo de permitir o cadastro e a listagem de pontos turísticos do Brasil. O sistema é composto por duas funcionalidades principais: cadastro de novos pontos turísticos e a exibição desses pontos turísticos com opções de busca e filtro.

## Começando

Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

### Pré-requisitos

- Node.js: versão 16 ou superior.
- .NET 8 SDK.
- SQL Server ou qualquer banco de dados compatível com SQL Server.

### Instalação

Clone o projeto: 
    - git clone https://github.com/davidvanjao/cadastro-turistico.git

/Frontend
    /cadastro-ponto-turistico
        - Instale as dependências: npm install
        - Inicie o servidor de desenvolvimento: npm run dev

/Backend
    /WebApi8-CadastroTuristico **os comandos devem ser rodados dentro da pasta onde contenha o arquivo .csproj**
        /WebApi8-CadastroTuristico
            /WebApi8-CadastroTuristico
                - Restaure os pacotes: dotnet restore
                - verifique versoes dos pacotes: dotnet list package
                    **Verificar se os pacotes e versaoes estao na 8.0.3**
                    - Microsoft.EntityFrameworkCore                8.0.3        8.0.3    
                    - Microsoft.EntityFrameworkCore.Design         8.0.3        8.0.3    
                    - Microsoft.EntityFrameworkCore.SqlServer      8.0.3        8.0.3    
                    - Microsoft.EntityFrameworkCore.Tools          8.0.3        8.0.3  
                - verifica se dotnet -f esta instalado: dotnet tool list -g
                - recriar banco de dados: dotnet ef database update

    

===========================IMPORTANTE========================================

**Insira no banco SQL SERVER os inserts abaixo.**

- Banco de Dados
    - Adicione os estados do Brasil na tabela Estados:
    USE [SistemaPontoTuristico]
    GO
    INSERT INTO [dbo].[Estados] ([Nome], [Sigla])
    VALUES
        ('São Paulo', 'SP'),
        ('Acre', 'AC'),
        ('Alagoas', 'AL'),
        ('Amapá', 'AP'),
        ('Amazonas', 'AM'),
        ('Bahia', 'BA'),
        ('Ceará', 'CE'),
        ('Distrito Federal', 'DF'),
        ('Espírito Santo', 'ES'),
        ('Goiás', 'GO'),
        ('Maranhão', 'MA'),
        ('Mato Grosso', 'MT'),
        ('Mato Grosso do Sul', 'MS'),
        ('Minas Gerais', 'MG'),
        ('Pará', 'PA'),
        ('Paraíba', 'PB'),
        ('Paraná', 'PR'),
        ('Pernambuco', 'PE'),
        ('Piauí', 'PI'),
        ('Rio de Janeiro', 'RJ'),
        ('Rio Grande do Norte', 'RN'),
        ('Rio Grande do Sul', 'RS'),
        ('Rondônia', 'RO'),
        ('Roraima', 'RR'),
        ('Santa Catarina', 'SC'),
        ('Sergipe', 'SE'),
        ('Tocantins', 'TO');
    GO

- Adicione os pontos turisticos na tabela PontosTuristicos:
    INSERT INTO [dbo].[PontosTuristicos]
            ([Nome]
            ,[Descricao]
            ,[Localizacao]
            ,[Cidade]
            ,[EstadoId]
            ,[DataInclusao])
        VALUES
            ('Parque do Povo', 'Um parque urbano com áreas verdes e quadras esportivas.', 'Av. Dom Pedro I, 1000', 'Tupã', 1, '2025-02-01'),
            ('Museu Histórico de Tupã', 'Museu que conta a história da cidade e região.', 'Rua dos Museus, 123', 'Tupã', 1, '2025-02-01'),
            ('Lago Artificial', 'Lago com pedalinhos e área para piquenique.', 'Av. dos Lagos, 456', 'Tupã', 1, '2025-02-01'),
            ('Catedral de São Pedro', 'Igreja histórica com arquitetura impressionante.', 'Praça da Matriz, 789', 'Tupã', 1, '2025-02-01'),
            ('Teatro Municipal', 'Teatro com apresentações culturais e peças locais.', 'Rua das Artes, 321', 'Tupã', 1, '2025-02-01'),
            ('Praça da Independência', 'Praça central com coreto e área de lazer.', 'Av. Independência, 654', 'Tupã', 1, '2025-02-01'),
            ('Zoológico Municipal', 'Zoológico com diversas espécies de animais.', 'Rua dos Animais, 987', 'Tupã', 1, '2025-02-01'),
            ('Parque Ecológico', 'Parque com trilhas ecológicas e cachoeiras.', 'Estrada do Parque, 555', 'Tupã', 1, '2025-02-01'),
            ('Mercado Municipal', 'Mercado com produtos locais e artesanato.', 'Rua do Comércio, 222', 'Tupã', 1, '2025-02-01'),
            ('Estádio Municipal', 'Estádio para eventos esportivos e shows.', 'Av. dos Esportes, 333', 'Tupã', 1, '2025-02-01'),
            ('Biblioteca Pública', 'Biblioteca com acervo variado e espaço para leitura.', 'Rua dos Livros, 444', 'Tupã', 1, '2025-02-01'),
            ('Praça das Flores', 'Praça com jardins floridos e bancos para descanso.', 'Av. das Flores, 777', 'Tupã', 1, '2025-02-01'),
            ('Mirante da Cidade', 'Mirante com vista panorâmica da cidade.', 'Rua do Mirante, 888', 'Tupã', 1, '2025-02-01'),
            ('Centro Cultural', 'Espaço para exposições e eventos culturais.', 'Rua da Cultura, 999', 'Tupã', 1, '2025-02-01'),
            ('Parque Aquático', 'Parque com piscinas e tobogãs.', 'Av. das Águas, 1010', 'Tupã', 1, '2025-02-01'),
            ('Feira Livre', 'Feira com produtos frescos e artesanato.', 'Rua da Feira, 1111', 'Tupã', 1, '2025-02-01'),
            ('Igreja Nossa Senhora Aparecida', 'Igreja dedicada à padroeira do Brasil.', 'Rua da Fé, 1212', 'Tupã', 1, '2025-02-01'),
            ('Parque de Exposições', 'Local para feiras e eventos agropecuários.', 'Av. das Exposições, 1313', 'Tupã', 1, '2025-02-01'),
            ('Praça do Relógio', 'Praça com um grande relógio como ponto central.', 'Rua do Tempo, 1414', 'Tupã', 1, '2025-02-01'),
            ('Cine Teatro', 'Local para exibição de filmes e peças teatrais.', 'Rua do Cinema, 1515', 'Tupã', 1, '2025-02-01');
        GO


### Randando API

Inicie a Api com Visual Studio 2022

###  Estrutura do Projeto

- Frontend
    /src: Contém os arquivos de código-fonte do React.
        /components: Componentes reutilizáveis.
            - FormularioBuscar: Tela de buscar
            - FormularioCadastrar: Tela de cadastrar
            - InfoPontoTuristico: Tela de informacoes do ponto turistico
            - ListaResultados: Resultados da pesquisa
            - NavBar
        /pages: Páginas principais.
            /Cadastro: Página de cadastro do ponto turistico
            /Detalhe: Página de detalhes do ponto turistico
            /Home: Página inicial do projeto
        /services: Funções para interagir com a API.
            api.js: Arquivo de configuração do Axios para realizar as requisições.


- Backend
    /Controllers: Controladores responsáveis pela lógica de cada endpoint.
        - EstadoControleller.cs:
        - PontoTuristicoController:

    /Dto: Transporta os dados
        /Estado
            - EstadoCriacaoDto
            - EstadoEdicaoDto
        /PontoTuristico 
            - PontoTuristicoCriacaoDto
            - PontoTuristicoEdicaoDto

    /Models: Definição de modelos de dados.
        - EstadoModel
        - PontoTuristicoModel

    /Services: A Service contém a lógica de negócio da aplicação
        /Estao
            - EstadoService
            - IEstadoInterface
        /PontoTuristico
            - PontoTuristicoService
            - IPontoTuristicoInterface

    /Data: Arquivos de configuração e conexão com o banco de dados
        - AppDbContecxt

### Endpoints da API

    GET/ ListarEstados(): Listar estados cadastrados
    GET/ ListarPontoTuristico(): Listar pontos turisticos
    GET/ BuscarPontoTuristicoId(int idPontoTuristico): Buscar ponto turistico por Id
    GET/ BuscarPontoTuristicoFiltroAvancado(string termoBusca): Buscar ponto turistico pelos campos nome, descrição ou localização
    POST/ CriarPontoTuristico(): Criar ponto turistico
    PUT/ EditarPontoTuristico(int idPontoTuristico): Editar ponto turistico
    DELETE/ ExcluirPontoTuristico(int idPontoTuristico): Excluir ponto turistico


### Fluxo de Trabalho e Funcionalidades

    - Cadastro de Pontos Turísticos: O usuário pode cadastrar um ponto turístico, informando nome, descrição, localização, cidade e estado.
    - Listagem de Pontos Turísticos: A página inicial exibe todos os pontos turísticos cadastrados. A listagem é paginada e pode ser filtrada por nome, descrição e         localização.
    - Detalhamento: O usuário pode clicar no botão mais detalhes para verificar detalhes completos sobre ele.


### Considerações Técnicas

    Tabela PontosTuristicos:
        - id: Identificador único do ponto turístico.
        - nome: Nome do ponto turístico.
        - descricao: Descrição do ponto turístico.
        - localizacao: Localização (endereço ou coordenadas).
        - cidade: Cidade onde o ponto turístico está localizado.
        - estado: Sigla do estado onde o ponto turístico está localizado.
        - dataInclusao: data em que o ponto turistico foi cadastrado.

    Tabela Estados:
        - id: Identificador único do estado.
        - nome: Nome do estado.
        - sigla: Sigla do estado.

## Segurança

    CORS: A API está configurada para permitir requisições CORS do frontend.


