# Sistema de Gestão de Biblioteca 📚

Bem-vindo ao repositório do projeto Sistema de Gestão de Biblioteca! Aqui, apresentamos um sistema robusto e eficiente para gerenciar o acervo, usuários e empréstimos de uma biblioteca, atendendo às necessidades específicas de funcionários, professores e alunos, seguindo os requisitos do projeto. A atividade foi desenvolvida ao longo do curso de formação back-end em C#, oferecido pela Ada Tech em parceria com o Mercado Eletrônico. 

## ℹ️ Sobre o Projeto

### Requisitos do Sistema ✅

- **Tipos de Usuários:**
  - Funcionários da biblioteca (Atendente, Bibliotecário, Diretor)
  - Professores
  - Estudantes

- **Privilégios de Acesso:**
  - Estudantes têm acesso apenas ao acervo público e podem entrar na fila de espera para reservar livros.
  - Professores têm acesso a livros dos acervos público e restrito e podem entrar na fila de espera para reservar livros.
  - Todo funcionário pode verificar se o livro está no sistema e se está disponível, e também pode cadastrar um novo livro ou atualizar o número de exemplares.
  - Os atendentes podem atualizar registros de usuários e permitir o empréstimo do livro.
  - O diretor cadastra novos funcionários.
    
- **Autenticação:**
  - Funcionários usam email e senha.
  - Professor usam email e senha (esta expira a cada mês).
  - Alunos usam apenas o número de matrícula.

- **Reserva de Livros:**
  - Professores têm prioridade sobre os Estudantes nas reservas.
  - Reservas antigas têm prioridade sobre as mais recentes.

- **Setores de Livros:**
  - Acervo público (pelo menos 2 exemplares conservados)
  - Acervo restrito (um exemplar conservado ou todos em mau estado)
  - Fora de estoque (perdidos, danificados ou todos emprestados)

- **Atualização de Dados:**
  - Os dados são manipulados através de arquivos JSON para Livros, Funcionários e Estudantes.

### Documentação do Projeto 📄

- [Documentação Detalhada](https://www.canva.com/design/DAF2Ocil80Y/ZkbyOB1s1WjI3qKBEWbsiA/view)
- [Notion](https://www.notion.so/Sistema-de-Gest-o-de-Biblioteca-183224ccc67340fea83b50ae4c3eee5c?pvs=4)
- [Diagrama de Classes](https://www.notion.so/Mermaid-f5ff8a018d9b480ea8a665056b3c0401)

## 👥 Membros do Projeto

- [Ângela](https://github.com/angelar)
- [Camila Zambanini](https://github.com/czambanini)
- [Herlon R Ludwig](https://github.com/herlonrl)
- [Kaique Ramos](https://github.com/KaiqueRamoss)
- [Maria Eduarda Sampaio](https://github.com/MariaEduardaSampaio)
- [Miguel Pereira de Sousa](https://github.com/Koohra)
- [Suellen Seiberlick Reis](https://github.com/suellensr)

## 📝 Conclusão
Dúvidas ou sugestões? Entre em contato conosco! 📧

**Divirta-se explorando e desenvolvendo o Sistema de Gestão de Biblioteca!** 📖✨
