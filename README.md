# Projeto 1 da Disciplina de Linguagens de Programação 2

## *Astrofinder*

* Marco Domingos, a21901309  
* Daniel Fernandes, a21902752  
* Pedro Bezerra, a21900974  

## Autoria

Nesta secção será indicado exatamente o que cada aluno fez no projeto. Para além
do que será mencionado, cada aluno também trabalhou em pequenas partes do
programa dos outros membros do grupo (arranjar *bugs*, pequenas
funcionalidades).

As secções serão separadas por alunos e o que cada um deles fez. Não haverão
classes/interfaces/enumerados/etc... repetidos entre secções, e as 'pequenas
contribuições' já referidas estarão nas secções onde tal contribuição foi 
feita.

Todos os membros fizeram a classe `Program`.

[**Link para o repositório *Github* do projeto**][github]

### Marco Domingos

* Classes `InteractiveClient`, `ConsoleClient`, `StringExtensions`
* Interface `ICelestialBody`
* Parte de **Autoria** e **Arquitetura da Solução** no Relatório
* Criação da Documentação em *Doxygen*

#### `InteractiveClient`

Classe feita inteiramente por Marco Domingos.

#### `ConsoleClient`

Classe feita inteiramente por Marco Domingos.

#### `String Extensions`

Classe feita inteiramente por Marco Domingos (Porém feita a partir de 
terceiros, ver [Referências](#referências) para mais detalhes).

#### `ICelestialBody`

Interface feita completamente por Marco Domingos.

### Daniel Fernandes

* Classes `FileReader`, `Planet`, `Star`, `InvalidFileConfiguration`
* UML

#### `FileReader`

Classe feita inteiramente por Daniel Fernandes.

#### `Planet` e `Star`

Maioria das classes feitas por Daniel Fernandes. Com os métodos `static` de 
comparação (como `CompareByName` e `CompareByStar`) sendo feitos por Pedro
Bezerra, documentação incluida. 

Os métodos `ToString()` e `ToStringDetailed()` em ambas as classes foram
implementados por Marco Domingos (documentação incluida), junto com o 
método `CompareByPlanets` (e sua documentação) na classe `Star`.

#### `InvalidFileConfiguration`

Classe feita, em sua maioria, por Daniel Fernandes. Documentadas por Marco Domingos.

### Pedro Bezerra

* Classes `Searcher`, `Handler`, `InvalidValueException`
* *Structs* `PlanetQueryParams`, `StarQueryParams`
* *Enum* `QueryParam`
* Parte de **Autoria** e tudo de **Referências** no Relatório

#### `Searcher`

Classe feita, em sua maioria, por Pedro Bezerra, com algumas mudanças no
construtor relacionadas a `FileReader` sendo feitas por Daniel Fernandes.

A adição de uma *query* no método `SearchStars()` (mais especificamente a 
de número de planetas) foi adicionada por Marco Domingos.

#### `Handler`

Classe feita, em sua maioria, por Pedro Bezerra. O método `ReadFile()` foi 
feito por Daniel Fernandes (mas não documentado pelo mesmo).

Os métodos `ClearPlanetParams()` e `ClearStarParams()` foram feitos e
documentados por Marco Domingos.

#### `InvalidValueException`

Classes totalmente feitas por Pedro Bezerra. Documentadas por Marco Domingos.

#### `PlanetQueryParams` e `StarQueryParams`

*Structs* feitas, em sua maioria, por Pedro Bezerra. O método `ClearParams()`
em ambas as *structs* foram feitas e documentadas por Marco Domingos.

#### `QueryParam`

Enumerado feito, em sua maioria, por Pedro Bezerra. `S_MIN_NUM_PLANETS` e 
`S_MAX_NUM_PLANETS` foram adicionados por Marco Domingos.

## Arquitetura da Solução

A forma de implementação utilizada foi a **Interativa em Consola**. Foi também
implementada parte da **Fase avançada**, sendo possível pesquisar planetas a 
partir de estrelas e vice-versa. Porém a função de observar detalhes da estrela
a partir da informação detalhada de um planeta e vice-versa não foi
implementada.

### *Loop* do Programa e Descrição da Solução

![diag1]

Como é possível ver no fluxograma, o programa não pode iniciar se não tiver um
ficheiro válido. Ao carregar o ficheiro (a partir da classe `Handler`, uma
classe *Facade* entre `FileReader` e `Searcher`), o programa entra no *loop* 
principal, onde é mostrado o ecrã com as várias opções já descritas no 
fluxograma. Observações importantes:

* Todos os *inputs* **não são** *case-sensitive*, para conveniência
do utilizador.
* A tecla 'q' irá fechar o programa em qualquer altura que o programa regista
inputs.

O programa faz todo este *loop* já mencionado em `InteractiveClient`, com os
vários *prints* em `ConsoleClient`, que também guarda os *inputs*. A parte do 
*loop* em sí foi feita de maneira normal, com blocos `while`, `do while`, `for`
e `foreach`.

Quando o jogador carrega um novo ficheiro (no inicio ou ao decorrer do 
programa), os respetivos planetas e estrelas são guardadas em
`IEnumerable` como variáveis de instância da classe `Searcher` (de 
forma a cumprir um dos princípios **SOLID**, especificamente o **L**). Elas vão
ser depois utilizadas para dar uma `ICollection` a um método em 
`InteractiveClient`.

Esta lista é então modificada de forma a filtrar e ordenar as várias pesquisas
do usuário, mas sempre antes de o usuário fazer uma nova pesquisa, a anterior
é descartada a favor de uma nova. A instanciação das coleções é então uma 
`List`, visto que o método `Sort()` da mesma é necessário.

Como já dito no início, a classe `Handler` irá ser responsável por filtrar e
ordenar as pesquisas, sendo uma *facade* para `Searcher`. `Searcher` utiliza 
fortemente **LINQ** e filtra a lista a partir de uma grande *query* que compara 
uma *struct* de filtragem (sendo esta *StarQueryParams* para estrelas e 
*PlaneyQueryParams* para planetas) com os `IEnumerable`s de planetas e estrelas 
na classe, vendo se a *struct* contém certo filtro.

Um outro algorítmo de *query* utilizado é na pesquisa avançada de planetas e
estrelas, também em `Searcher`, utilizando `join` de **LINQ**. Esta pesquisa
faz com que seja possível filtrar campos de estrelas na coleção de planetas e
vice-versa. Irá retornar um `IEnumerable` de estrelas ou planetas.

Após filtrar e ordenar a lista, o programa passa então para a visualização
dessa lista, que é toda feita em `ConsoleClient`. É possível movimentar a lista
e ver certos corpos celestiais em maior detalhe. Com as setas do teclado.

Em termos de erros, as classes `InvalidFileConfiguration` e
`InvalidValueException` foram criadas para arremessar e apanhar vários erros,
sendo a primeira relacionada ao carregamento do ficheiro (ficheiro inválido ou
não encontrado, por exemplo), e a segunda sendo mais geral, para qualquer erro
de valor.   
O programa utiliza as mensagens de erro de forma menos detalhada de forma a dar
informação pertinente ao usuário. 

Para finalizar, a maioria das variáveis númericas no programa são `short` ou
a versão *nullable* `short?`, de forma a salvar recursos e otimizar o programa.

### UML e Descrição das Classes

Esta secção irá demontrar o diagrama UML do projeto e comentar sobre a
organização do mesmo. Algumas classes apresentadas no diagrama-- as mais símples 
ou que não têm muitas ligações por exemplo, não serão especificadas.

![uml]

***OBS: As classes/interfaces em azul são as classes base do C#.***

#### Classe `Program`

Apenas instancia `InteractiveClient` e corre o `MainLoop()` no método `Main()`,
tendo assim uma relação de dependência com a referida classe.

#### Classe `InteractiveClient`

Responsável por todos os *loops* do programa e movimentação pelo mesmo, esta
classe tem uma variável de intância de:

* `ConsoleClient` para demonstrar informação no ecrã e capturar *inputs*
* `Handler`, para leitura de ficheiros e filtragem de pesquisas.

Visto que não são listas ou coleções, a ligação entre `InteractiveClient` e as
classes referidas é uma de associação.

`InteractiveClient` também utiliza uma coleção de `Planet` e uma coleção de
`Star` no método `SearchCelestialBody<T>`, e uma exceção de tipo
`InvalidValueException`.

#### Classe `Handler`

Handler é a classe *facade* que cuida, por trás das cenas, dos ficheiros e 
da filtragem de informação, visto isto ela têm variáveis de instância de:

* `FileReader`
* `Searcher`
* `PlanetQueryParams` para salvar os parâmetros dos planetas
* `StarQueryParams` para salvar os parâmetros das estrelas.

Pela mesma razão da classe anterior, estas são todas ligações de associação.

#### Classe `FileReader`

É a classe que trata do ficheiro atual e cria coleções de estrelas e planetas a
partir deste. Suas variáveis de instância relevantes são:

* Uma coleção de `Planet`s, como `ICollection<Planets>`
* Uma lista de `Star`s, como `List<Stars>`

Visto que isto são ambas coleções e contêm várias instâncias de `Planet` e
`Star`, `FileReader` têm ligações de agregação com estas classes. A coleção de
estrelas necessita ser uma lista devido a necessidade de utilizar métodos como
`IndexOf()` mais para frente.

`FileReader` também utiliza em alguns métodos a classe
`InvalidFileConfiguration` para exceções.

#### Classe `Searcher`

É a classe responsável por receber coleções (no caso da declaração, apenas
`IEnumerable`s) de estrelas e planetas e as filtrar. As suas variáveis de
instância são:

* Um `IEnumerable` de `Planet`s
* Um `IEnumberable` de `Star`s

Pelos mesmos motivos da classe anterior, estas ligações são de agregação.

Esta classe também utiliza bastante em seus métodos as *structs* 
`PlanetQueryParams` e `StarQueryParams`, de forma a fazer a filtragem.

#### Classes `Star` e `Planet`

Contem informações sobre ou um planeta ou uma estrela, apanhadas a partir de um
ficheiro em `FileReader`. Ambas implementam duas interfaces:

* `IEquatable`, de forma a implementarem o método `Equals()`
* `ICelestialBody`, para ambas as classes terem semelhanças entre si e poderem
ser identificadas facilmente.

Estas classes são também as únicas do programa que utilizam `StringExtensions`
(mesmo estas podendo ser utilizadas pelo programa todo), mais especificamente
no *override* de `ToString()`-- para limitar a quantidade de informação que
irá aparecer na lista de planetas.

#### *Structs* `PlanetQueryParams` e `StarQueryParams`

Guardam informações de *inputs* do usuário de forma a serem comparados com uma
coleção de planetas ou estrelas. Utilizam o enumerado `QueryParam`, que define
as várias possibilidades de filtragem.

## Referencias

Na classe `FileReader`, no método `FormatPar`, foi utilizado uma implementação 
de um Parser Genérico, [aqui][link1]. Neste mesmo método também foi implementado 
um Generic Nullable<T> encontrado [aqui][link2].

A classe `StringExtension` foi criada com base na inforamação encontrada
[aqui][link3].

Os métodos de comparação em `Planet` e `Star` foram criados com base neste
[link][link4].

[link1]:  https://stackoverflow.com/questions/2961656/generic-tryparse
[link2]:  https://stackoverflow.com/questions/209160/nullable-type-as-a-generic-parameter-possiblehow-to-remove-elements-from-a-generic-list-while-iterating-over-it
[link3]:  https://stackoverflow.com/questions/4105386/can-maximum-number-of-characters-be-defined-in-c-sharp-format-strings-like-in-c
[link4]:  https://stackoverflow.com/questions/2480111/c-sharp-how-to-implement-multiple-comparers-for-an-icomparablet-class

[github]: https://github.com/condmaker/astrofinder
[diag1]:  Diagramas/diag1.png
[uml]:    Diagramas/uml.png