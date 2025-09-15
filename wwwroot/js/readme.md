<img src="wwwroot/img/banner1.jpg">

# Lista de Tarefas

## ASP.NET Core MVC + Razor

### Bootcamp Avanade

Projeto de gerenciamento de tarefas

- ASP.NET Core MVC

- Razor Views

- Entity Framework Core

- SQLite como banco de dados

O sistema permite criar, editar, excluir e listar tarefas com campos como título, descrição, status, data de criação e data de finalização.

## Funcionalidades

✅ Criar nova tarefa com data automática

✅ Editar tarefa existente com seleção via dropdown

✅ Excluir tarefa com confirmação e visualização dos dados

✅ Listar todas as tarefas em tabela organizada

✅ Validação de campos obrigatórios

✅ Interface responsiva com layout Razor

✅ Mensagens de sucesso após ações

## Tecnologias Utilizadas

Tecnologia..............Finalidade

ASP.NET Core MVC........Estrutura do projeto

Razor Views.............Interface do usuário

Entity Framework Core...ORM para acesso ao banco de dados

SQLite..................Banco de dados leve e local

jQuery..................Manipulação de DOM e validações

🗂️ Estrutura de Pastas
Código
listaTarefas/
├── Controllers/
│ └── TarefaController.cs
├── Models/
│ └── Tarefa.cs
├── Views/
│ └── Tarefa/
│ ├── Create.cshtml
│ ├── Edit.cshtml
│ ├── Delete.cshtml
│ ├── Lista.cshtml
├── wwwroot/
│ ├── css/
│ │ └── style.css
│ └── js/
│ ├── site.js
│ └── menu.js

## Como Executar o Projeto

1- Clone o repositório. No bash:

git clone https://github.com/seuusuario/listaTarefas.git

2- Restaure os pacotes. No bash:

dotnet restore

3- Crie o banco de dados. No bash:

dotnet ef migrations add InitialCreate

dotnet ef database update

4- Execute o projeto. No bash:

dotnet run ou dotnet watch run

5- Acesse no navegador:

http://localhost:5294

## Observações Importantes

- A data de criação da tarefa é gerada automaticamente e não pode ser editada.

- A edição e exclusão usam dropdown para seleção da tarefa.

- O campo Id é essencial para evitar duplicações ao editar.

- Mensagens de sucesso são exibidas com TempData.

## Melhorias Futuras

- Autenticação com perfis de usuário

- Painel com estatísticas de tarefas

- Filtros por status ou data

- Versão mobile com layout adaptado

<img src="https://solmorcillo.com.br/imgs_public/logo_SM.jpg" width="100px" height="120px">
