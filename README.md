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
* Relatório, Criação da Documentação em *Doxygen*

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

* Classes `FileReader`, `Planet`, `Star`
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

### Pedro Bezerra

* Classes `Searcher`, `Handler`, `InvalidFileConfiguration`, 
  `InvalidValueException`
* *Structs* `PlanetQueryParams`, `StarQueryParams`
* *Enum* `QueryParam`

#### Searcher

Classe feita inteiramente por Pedro Bezerra

## Referências

A classe `StringExtensions` foi baseada nesta discussão do *Stack Overflow*,
mais especificamente na segunda resposta a pergunta:

https://stackoverflow.com/questions/4105386/can-maximum-number-of-characters-be-defined-in-c-sharp-format-strings-like-in-c



[github]: https://github.com/condmaker/astrofinder