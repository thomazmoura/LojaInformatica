# VS Code Settings

Aqui constam algumas opções que você pode utilizar para personalizar a sua experiência com o VS Code caso tenha interesse.

## VS Code Icons

A extensão do [**VS Code-Icons**](https://marketplace.visualstudio.com/items?itemName=robertohuertasm.vscode-icons) é útil pra quem quer melhorar a experiência de usuário no desenvolvimento ao acrescentar ícones mais intuitivos e que facilitam a navegabilidade no código.

Ele já possui por padrão ícones de arquivos e pastas bastante úteis, mas caso você queira personalizar mais os ícones de pastas ou arquivos, você pode verificar a [lista de ícones de arquivo](https://github.com/vscode-icons/vscode-icons/wiki/ListOfFiles) ou a [lista de ícones de pastas](https://github.com/vscode-icons/vscode-icons/wiki/ListOfFolders) para ver as opções disponíveis.

Seguem alguns exemplos de personalizações de ícones de pastas que podem deixar a sua experiência de usuário mais agradável caso você utilize o plugin :

```json
"vsicons.associations.folders": [
    {
        "icon": "model",
        "extensions": [
            "Entidades",
            "Entities",
            "Objetos"
        ],
        "format": "svg"
    },
    {
        "icon": "db",
        "extensions": [
            "Dados",
            "Contexto",
            "Repositorios",
            "UnitOfWork"
        ],
        "format": "svg"
    },
    {
        "icon": "config",
        "extensions": [
            "Configuracao",
            "Migrations"
        ],
        "format": "svg"
    },
    {
        "icon": "component",
        "extensions": [
            "IoC"
        ],
        "format": "svg"
    },
    {
        "icon": "test",
        "extensions": [
            "Testes"
        ],
        "format": "svg"
    },
    {
        "icon": "tools",
        "extensions": [
            "Filters"
        ],
        "format": "svg"
    },
    {
        "icon": "api",
        "extensions": [
            "Controllers"
        ],
        "format": "svg"
    },
    {
        "icon": "src",
        "extensions": [
            "LojaInformatica.Api"
        ],
        "format": "svg"
    },
    {
        "icon": "log",
        "extensions": [
            "ReleaseNotes"
        ],
        "format": "svg"
    }
]
```

## Snippets

Outro recurso interessante do VS Code é a criação de snippets. Para criar seu próprio snippet basta ir em *> Preferences: Open User Snippets*. Segue abaixo um exemplo de snippet que você pode criar para testes unitários:

*Obs.: O próprio arquivo de criação de snippets já dá detalhes de como criar seus próprios snippets. Para inserir o snippet abaixo (depois de inserido no csharp.json) é só digitar __ut + tab__ em um arquivo C#.*

```json
"Unit Test": {
    "prefix": "ut",
    "body": [
        "[Fact]",
        "public void ${1:Método}_${2:ResultadoEsperado}_${3:SituaçãoSimulada}()",
        "{",
        "$0",
        "}"
    ],
    "description": "Cria um teste unitário utilizando o XUnit."
}
```