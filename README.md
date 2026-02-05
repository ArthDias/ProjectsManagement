# Sistema de Gestão de Projetos

## Sobre o Projeto

Este projeto é uma aplicação web desenvolvida em ASP.NET Web Forms que simula funcionalidades básicas de um sistema de gestão de projetos, permitindo o cadastro e consulta de projetos através de uma interface web.

## Como Executar o Projeto

### Pré-requisitos
- Visual Studio 2017 ou superior
- .NET Framework 4.7.2
- IIS Express (incluído no Visual Studio)

### Passos para Execução

1. **Clonar o Repositório**
   ```bash
   git clone <url-do-repositorio>
   cd fundep-challenge
   ```

2. **Abrir a Solução**
   - Abra o arquivo `FundepChallenge.sln` no Visual Studio

3. **Restaurar Pacotes**
   - O Visual Studio deve restaurar automaticamente as referências
   - Se necessário, clique com botão direito na solução > "Restore NuGet Packages"

4. **Compilar a Solução**
   - Build > Build Solution (Ctrl+Shift+B)
   - Certifique-se de que não há erros de compilação

5. **Definir Projeto de Inicialização**
   - Clique com botão direito no projeto `FundepChallenge.Web`
   - Selecione "Set as StartUp Project"

6. **Executar a Aplicação**
   - Pressione F5 ou clique em "Start"
   - O IIS Express será iniciado e a aplicação abrirá no navegador
   - A página inicial será `CadastroProjeto.aspx`

7. **Testar as Funcionalidades**
   - **Cadastro:** Preencha os campos e clique em "Cadastrar Projeto"
   - **Consulta:** Navegue até "Consultar Projetos" e teste os diferentes tipos de busca
   - **Dados Mockados:** Busque por "2024001", "2024002" ou "2024003" para ver os dados pré-cadastrados

## Meu Entendimento das Tecnologias

### ASP.NET Web Forms

O ASP.NET Web Forms é um modelo de desenvolvimento web da Microsoft que facilita a criação de páginas web dinâmicas. Ele funciona de maneira similar ao desenvolvimento de aplicações desktop, utilizando controles visuais que são renderizados como HTML.

- Cada página tem dois arquivos: o `.aspx` (marcação HTML com controles) e o `.aspx.cs` (code-behind com lógica)
- O servidor processa a página e gera HTML que é enviado ao navegador
- Os controles ASP.NET (como Button, TextBox, GridView) são convertidos em HTML padrão
- O ViewState mantém o estado dos controles entre requisições HTTP

### Code-Behind

O code-behind é um padrão de design do ASP.NET Web Forms que separa a lógica de apresentação (código C#) da marcação visual (HTML/controles).

- O arquivo `.aspx` contém apenas a estrutura visual e declaração de controles
- O arquivo `.aspx.cs` contém toda a lógica: validações, chamadas a serviços, manipulação de eventos
- Os eventos dos controles (como OnClick de um botão) são tratados no code-behind
- O arquivo `.designer.cs` é gerado automaticamente e contém as declarações dos controles para o compilador

### WCF (Windows Communication Foundation)

O WCF é um framework da Microsoft para construção de serviços orientados a serviço (SOA). Ele permite a comunicação entre aplicações através de diferentes protocolos e formatos.

- Define contratos através de interfaces marcadas com `[ServiceContract]`
- Os métodos do serviço são marcados com `[OperationContract]`
- A implementação do serviço é feita em classes concretas que implementam essas interfaces
- Pode ser hospedado de várias formas (IIS, Windows Service, auto-hospedado)

### Comunicação via DLL

A comunicação via DLL significa que o serviço WCF não está hospedado remotamente, mas sim sendo usado como uma biblioteca local.

- O projeto Web referencia diretamente o projeto WCF
- Quando compilado, a DLL do WCF é copiada para a pasta bin do projeto Web
- No code-behind, instancio diretamente a classe do serviço: `var service = new ProjetoService()`
- Chamo os métodos do serviço como se fossem métodos locais

**Nota importante:** Em um ambiente de produção real, o WCF seria hospedado separadamente (em IIS ou como Windows Service) e a comunicação seria feita através de protocolos de rede configurados no Web.config. Porém, para este desafio, a abordagem via DLL é perfeitamente adequada e simplifica a execução.

## Decisões Técnicas Adotadas

**Arquitetura em Camadas**
- Manter responsabilidades bem definidas
- Facilitar manutenção e evolução
- Reutilizar código sem duplicação
- Seguir boas práticas de desenvolvimento

**Persistência em Memória com Singleton**
- O requisito permite escolher entre memória ou XML
- Memória é mais simples e rápida para o escopo do projeto
- Singleton garante uma única instância do repositório durante a execução
- Thread-safe através de locks para garantir consistência dos dados
- Incluí dados mockados para facilitar testes de consulta

**Validação no Code-Behind**
- Segurança: validações client-side podem ser burladas
- Mensagens de erro claras e amigáveis
- Validação de tipos de dados (como conversão de decimal para saldo)
- Retorno visual imediato para o usuário

**Interface Visual Responsiva**
- Melhor experiência do usuário
- Profissionalismo e cuidado com detalhes
- Funciona em diferentes dispositivos (desktop, tablet, mobile)
- Demonstra capacidade técnica além do básico requisitado

**Loader Visual com Simulação de Latência**
- Requisito explícito do desafio
- Em aplicações reais, chamadas a serviços têm latência de rede
- Melhora a experiência do usuário ao dar feedback visual
- Demonstra compreensão de operações assíncronas

**Múltiplas Opções de Busca**
- Flexibilidade para o usuário
- Demonstra capacidade de implementar diferentes filtros
- Usa busca parcial (Contains/IndexOf) para melhor usabilidade

**Mensagens de Feedback Contextuais e Tratamento de Erros**
- Comunicação clara com o usuário
- Diferenciação visual por tipo de mensagem
- Melhora a usabilidade geral do sistema
- Evitar crashes da aplicação
- Garantir robustez do sistema

**Formatação de Moeda**
- Apresentação profissional de valores
- Facilita leitura pelo usuário
- Segue convenções brasileiras de formatação

## Sugestões de Melhorias

- Paginação na Consulta
- Exportação de Dados
- Persistência em Banco de Dados
- Edição e Exclusão de Projetos
- Autenticação e Autorização
- Hospedagem Real do WCF
- Testes Automatizados