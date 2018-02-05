# Entidades

## Visão Geral

É nesse namespace que deve estar toda a lógica do sistema que não se refira a manipulação de aspectos de infra, interação com sistemas externos ou lógica de fluxo.

As entidades aqui são baseadas nas entidades e agregados segundo a definição do Eric Evans em seu livro *Domain Driven Design: Tackling Complexity in the Heart of Software*.

Nesse projeto não é diferenciado de nenhuma forma "física" os agregados de entidades simples - basta considerar que agregados podem ser compostos por sub-entidades. No caso de Produto e Imagens, por exemplo, não é possível (ou interessante) acessar as imagens diretamente, pois estas só fazem sentido no contexto de um produto.

## Entidades vs Serviços

Um dos intuitos de projeto é verificar até onde é possível manter um projeto complexo sem o uso de "Serviços de Entidades" - algo muito comum em arquiteturas que Martin Fowler chama de "Domínios Anêmicos". Nesse tipo de arquitetura utiliza-se serviços para realizar a lógica do sistema e utiliza-se as entidades apenas como meio de trafegar e persistir dados.

## Extension Methods como alternativa

A arquitetura proposta aqui visa o uso de extension methods como meio de centralizar a lógica nas entidades fazendo com que operações que envolvam conjuntos de entidades sejam expostos por extension Methods. Dessa maneira remove-se a necessidade de possuir um serviço de cada entidade que manipule a lista de entidades e passa-se essa responsabilidade de manipulação para as próprias entidades através dos extension methods.

## Importância do Namespace

Um dos problemas dos extension methods é dia navegabilidade - é necessário referenciar diretamente o namespace no qual estão inseridos para que apareçam como sugestão de intellisense. Para contornar isso é, considerando que são de fato parte da lógica das entidades, optou-se por se usar o mesmo namespace das entidades - dessa forma sempre que as entidades estiverem acessíveis seus métodos de extensão também estarão.

## Lista de entidades como classe distinta

Uma outra opção de arquitetura seria criar uma nova classe para cada lista de entidades a fim de manipulá-las sem a necessidade de métodos de extensão. Optou-se pelos métodos de extensão, entretanto, por serem mais fáceis de manter do que ter que se preocupar com o ciclo de vida das entidades e dos "encapsuladores" de entidades.
