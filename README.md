# Sistema Bancário em C#

## Sobre o projeto

Este projeto é uma aplicação de console desenvolvida em C# com o objetivo de simular operações básicas de um sistema bancário.

O sistema permite criar contas, listar contas cadastradas, realizar depósitos, saques e transferências entre contas.

O projeto foi desenvolvido com foco em prática de Programação Orientada a Objetos (POO), organização de código, uso de interfaces e validações de regras de negócio.

## Funcionalidades

* Criar conta bancária
* Listar contas cadastradas
* Realizar depósitos
* Realizar saques
* Transferir valores entre contas
* Sistema de logs com interface `ILogger`
* Logger em console (`ConsoleLogger`)
* Logger em arquivo (`FileLogger`)
* Validação de saldo e dados de entrada
* Menu interativo no console

## Tecnologias utilizadas

* C#
* .NET
* Programação Orientada a Objetos (POO)
* Interfaces
* Console Application
* Git
* GitHub

## Estrutura do projeto

```text
Program.cs → menu principal e fluxo do sistema

Models/
└── BankAccount.cs

Interfaces/
└── ILogger.cs

Loggers/
├── ConsoleLogger.cs
└── FileLogger.cs
```

## Aprendizados

Durante o desenvolvimento deste projeto, foram praticados conceitos importantes como:

* Classes e objetos
* Encapsulamento
* Métodos e validações
* Interfaces
* Lista de objetos (`List<T>`)
* Estruturas condicionais
* `switch case`
* `foreach`
* `FirstOrDefault`
* `TryParse`
* Organização de código
* Refatoração em pastas e arquivos

## Como executar

1. Clone o repositório

2. Abra o projeto no Visual Studio ou VS Code

3. Execute a aplicação

4. Escolha uma opção no menu do sistema

## Autor

Desenvolvido por Anderson Souza
