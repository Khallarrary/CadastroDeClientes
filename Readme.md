# Cadastro de Clientes com Autenticação

Este é um sistema de **cadastro de clientes** com autenticação de usuários, desenvolvido em **C# (Console Application)**. O sistema permite o gerenciamento de clientes e usuários, garantindo segurança através de **hash de senha (SHA-256)**.

## Funcionalidades

- Autenticação de usuários (login com usuário e senha)
- Armazenamento seguro de senhas utilizando SHA-256
- Criação automática de usuário administrador padrão (`admin/admin`)
- Cadastro e consulta de clientes
- Registro de novos usuários no sistema
- Menu interativo no console para navegação

## Usuário Padrão

Caso o arquivo de usuários (`usuarios_hash.txt`) não exista, o sistema criará automaticamente o usuário administrador.

**Usuário:** admin  
**Senha:** admin

## Segurança

As senhas não são armazenadas em texto puro. O sistema utiliza o algoritmo **SHA-256** para gerar o hash das senhas, aumentando a segurança das informações.

## Tecnologias Utilizadas

- C#
- .NET
- Console Application
- Criptografia com SHA-256
- Manipulação de arquivos (File I/O)

## Melhorias Futuras

- Integração com banco de dados MySQL
- Implementação de edição e exclusão de clientes
- Separação em camadas (Repository / Service)
- Criação de interface gráfica com WPF ou React + Electron
- Desenvolvimento de API REST para integração com outras aplicações
