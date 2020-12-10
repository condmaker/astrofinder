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

### UML e Descrição das Classes

![uml]

## Referencias

Na classe `FileReader`, no método `FormatPar`, foi utilizado uma implementação 
de um Parser Genérico, [aqui][link1]. Neste mesmo método também foi implementado 
um Generic Nullable<T> encontrado [aqui][link2].

A classe `StringEnxtension` foi criada com base na inforamação encontrada
[aqui][link3].

[link1]:  https://stackoverflow.com/questions/2961656/generic-tryparse
[link2]:  https://stackoverflow.com/questions/209160/nullable-type-as-a-generic-parameter-possiblehow-to-remove-elements-from-a-generic-list-while-iterating-over-it
[link3]:  https://stackoverflow.com/questions/4105386/can-maximum-number-of-characters-be-defined-in-c-sharp-format-strings-like-in-c

[github]: https://github.com/condmaker/astrofinder
[diag1]:  Diagramas/diag1.png
[uml]:    Diagramas/uml.png