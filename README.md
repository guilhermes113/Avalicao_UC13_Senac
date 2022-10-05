# Atividade U13 04/10/2022

#### Etapa 0 - Para quem não tem o projeto base

- Fork Realizado do GitHub de aeciobrito/Avalicao_UC13_Senac para GitHub Pessoal guilhermes113/Avalicao_UC13_Senac.

#### Etapa 1 - Preparação da Aplicação (Realizada)

- Página Home deve ser o Index (lista) de Alunos -> "Controller Alterada, Construção do Html" 
- A comunicação com o repositório deverá ser feita atráves de Injeção de Dependência -> "Repository e IRepository Contruidas e injetadas"

#### Etapa 2 - Escrita de testes (Realizada)

- Escreva testes para a model Aluno ->  "TESTE REALIZADOS" 
  - O método AtualizarDados() deve alterar as propriedades Nome e Turma com sucesso, independente dos dados passados. -> "Realizado"
  - O método VerificaAprovacao() deve retornar VERDADEIRO se, e somente se a média for maior ou igual a 5. -> "Realizado"
  - O método AtualizaMedia() deve atualizar a propriedade Media com o novo valor recebido. -> "Realizado"
  - Anote quais as inconsistências encontradas na model Aluno, mas não a corrija ainda. -> "Erros Anotados"
  
- Escreva testes para a controller AlunosController

  - O método Index() deve retornar um OkResult, contendo ou não registros no banco.
  - O método Index() deve retornar chamar o repositório apenas uma vez.
  - O método Details() deve retornar uma BadRequest() para um id nulo, um NotFound() para um um id válido, mas aluno não encontrado no banco e uma ViewResult para um       aluno encontrado.
  - O método Details() deve chamar o repositório apenas uma vez.
  - O método Create() deve sempre retornar uma View.
  - O método [HttpPost] Create() deve validar as propriedades da model Aluno, conforme suas regras. Caso válidas, deve chamar uma única vez o repositório e retornar a     o RedirectToAction. Caso inválidas, retornar uma View.
  - Anote quais as inconsistências encontradas na controller AlunosController, mas não a corrija ainda.

#### Etapa 3 - Relatório de erros Realizando

- Crie em seu arquivo README.md um relatório com os problemas encontrados em seus testes.
Relatório de Erro ->
--
"Model Aluno não possui um construtor",
"Varifica Aprovação nao possui método que verifica igual a 5, Apenas Acima",

--
#### Etapa 4 - Correção de erros

- Implemente as correções necessárias para atender os testes.


#### Etapa 5 - Github Actions

- Implemente um workflow que faça um build e verificação de cada nova implementação, realizando os testes automatizados.

## Links de Referência
> [Fork](https://docs.github.com/en/get-started/quickstart/fork-a-repo)
>  
> [Configuração Home](https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/asp-net-mvc-routing-overview-cs)
>
>[Injeção de Dependencia](https://balta.io/blog/aspnet-core-dependency-injection)
>
>[Padrão Repository](https://learn.microsoft.com/pt-br/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)
>
>[Escrita de Testes Unitários com xUnit](https://code-maze.com/aspnetcore-unit-testing-xunit/)
>
>[Criando um README](https://www.makeareadme.com/)
>
>[Github Actions Workflow](https://learn.microsoft.com/en-us/dotnet/devops/dotnet-test-github-action)
