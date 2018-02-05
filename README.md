# Loja de Informática

## Visão Geral

A ideia desse projeto é servir como uma sugestão de arquitetura de sistemas .NET orientada a objetos, baseada em DDD e utilizando extension methods como meio de se conseguir mais flexibilidade e praticidade.

O próprio projeto em si também é um protótipo com a intenção de validar as técnicas utilizadas em um caso profilo ao real. Para esse fim resolvi me basear em uma loja de informática na qual costumo comprar hardware por ser mais barato lá, mas cujo sistema - que parece não ter sido atualizado há anos - deixa muito a desejar.

Considerarei o projeto concluído quando este tiver funcionalidades equiparáveis ao da loja na qual me basiei (o que não inclui compras diretamente do site) porém melhor usabilidade do usuário.

## Tecnologias utilizadas

Para esse projeto está sendo utilizado o ASP .NET Core Web API (e C# como linguagem e .NET Core como plataforma), Entity Framework como ORM, PostgreSQL como tecnologia de banco de dados, Angular como Framework de Frontend e VS Code como editor de código (na prática o sistema deve rodar com qualquer outro editor ou com o Visual Studio, mas eu incluí algumas dicas de como personalizar o VS Code).

Foram adotadas apenas tecnologias Open Source para que o projeto possa ser executado em qualquer sistema operacional.

## Primeiros Passos

### Restaurar pacotes

Para restaurar as dependências do sistema via NuGet, basta abrir um terminal na pasta do projeto (LojaInformatica.API) e usar o comando:

```bash
dotnet restore
```

### Executar os testes

Para rodar os testes unitários do sistema, basta rodar o seguinte comando no terminal:

```bash
dotnet test
```

### Executar o projeto

Para executar o projeto basta utilizar o comando:

```bash
dotnet watch run
```

*Obs: o comando acima faz com que não apenas o projeto .NET seja executado mas também fica observando mudanças nos arquivos C# - se algum arquivo for alterado ele já recompila o projeto para incluir as mudanças. Para apenas executar sem observar mudanças basta omitir o watch"*
