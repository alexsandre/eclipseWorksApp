# Projeto
Esse é o código-fonte do Desafio Técnico proposto pela Eclipse Works como uma etapa de um processo seletivo.
 
_**O Desafio foi dividido em 3 fases, abaixo apresento e explico as minhas decisões referentes a Fase 1 - API Coding**_

## Fase 1 - API Coding
A fase 1 do desafio diz respeito a implementação de uma API Rest de um sistema de controle de projetos e as tarefas relcionadas.

A descrição do desafio com o que era proposto e espera se encontra [aqui](https://meteor-ocelot-f0d.notion.site/NET-C-5281edbec2e4480d98552e5ca0242c5b). Por não saber se o documento ficaria sempre disponível, fiz uma cópia local nesse projeto, está [aqui](https://github.com/alexsandre/eclipseWorksApp/blob/main/Docs/DesafioTecnico.md).

### Como executar o projeto?

O projeto está configurado para rodar com o docker/compose. Portanto, o comando abaixo será suficiente para executá-lo em qualquer máquina que tenha com o docker/compose:

```
 
docker compose up
 
```

Após o comando ser executado com sucesso, a API estará rodando no endereço [http://localhost:8080](http://localhost:8080). Eu permitir o swagger rodar mesmo em ambiente de produção, para facilitar ver os endpoints, ele estará rodando no endereço: [http://localhost:8080/swagger](http://localhost:8080/swagger)


### Como está estruturado o projeto?
Para desenvolver o projeto utilizei o .NET 8.0, além de:
* PostgreSQL como banco de dados.
* Entity Framework Core como meu ORM.
* A lib Mediatr para criar no projeto da API uma estrutura de Commands/Handlers.
* A lib NUnit para teste unitários.


Desenvolvi o projeto pensando em construir um domínio separado da camada de aplicação e de infraestrutura, abaixo relaciono os projetos dentro da solução e por qual parte cada uma é responsável:


#### EclipseWorksApp.API
Projeto contendo toda a estrutura da API, responsável por receber as chamadas Rest. Utilizei o Mediatr para utilizar uma abordagem de commands/handlers, tornando a implementação dos controllers/actions melhor, e tirando de dentro das actions um maior conhecimento do negócio, deixando por conta dos handlers fazerem o papel de classes de aplicação, que consomem o domínio e a infraestrutura conforme necessidade.


#### EclipseWorksApp.Domain
Projeto de domínio, contendo a modelagem de classes relacionado ao problema proposto. Aqui as classes se comunicam sem depender de como estão sendo chamadas, se é por um api rest ou de outra forma. Tornando esse projeto capaz de trabalhar com diferentes formas de acesso. Podendo ser reaproveitada para outras API ou outros templates de projeto(console, desktop, entre outros).


#### EclipseWorksApp.Domain.Tests
Esse é o projeto com os testes unitários das classes do domínio.


#### EclipseWorksApp.Infra
Projeto responsável pela parte de infraestrutura, de códigos e uso de libs que não precisam estar no domínio e podem/devem ser abstraídas. Nesse projeto em específico acabou ficando responsável somente pelas classes de mapeamento objeto-relacional das classes de domínio. Como usei o Entity Framework Core, foi nesse projeto onde deixei o mapeamento das classes para as tabelas e também onde criei o contexto do banco.



### Quais são os endpoints?
Abaixo estão relacionados os endpoints da aplicação:


| Url                                              | Método HTTP | Descrição                                     | 
| -------------                                    | ------------| -------------                                 |
| /api/Projects                                    |  GET        | Retorna todos os projetos de um usuário logado|
| /api/Projects                                    |  POST       | Cria um novo projeto para o usuário logado    |
| /api/Projects                                    |  DELETE     | Deleta um projeto do usuário logado           |
| /api/Reports/Performance                         |  GET        | Retorna os dados deo relatório de Performance dos usuários |
| /api/projects/{idProject}/Tasks                  |  GET        | lista as Tarefas de um Projeto |
| /api/projects/{idProject}/Tasks                  |  POST       | Cria uma nova tarefa para um projeto |
| /api/projects/{idProject}/Tasks/{idTask}         |  PATCH      | Atualiza informações da Tarefa indicada |
| /api/projects/{idProject}/Tasks/{idTask}         |  DELETE     | Exclui a Tarefa indicada |
| /api/projects/{idProject}/Tasks/{idTask}/Comments|  POST       | Cria um novo comentário na referida Tarefa |

##### Observação: 
Na descrição do Desafio foi informado que não era necessário fazer o crud de usuários, nem autenticação. Para simular o comportamento de um usuário logado ou não, criei uma tabela de usuários preenchida na primeira execução do banco Postgres e em todas as chamadas para a API eu espero um Header Http chamado _**User-Logged**_ que deve ter o código de um dos usuários do banco. É com base nesse header que irei saber se há um usuário logado ou não, e também verifico o acesso ao relatório de desempenho, que só alguns usuários podem ter acesso. Na tabela de usuários existem 5 registros e os de Id igual a 3 e 5 possuem perfil de _**Gerente**_.
 
  
   
## Fase 2 - Refinamento

Na fase de refinamento as questões e sugestões que me vieram a cabeça foram:

* Existe a possibilidade de a quantidade limite de tasks por projeto mudar, ou se tornar um valor cobrado? Atualmente são 20, mas isso poderia ser para contas free, usuário pago poderiam ter mais, conforme o valor que pagam. Então quanto mais flexível isso for no sistema, melhor.


* Está no radar a implementação de um controle de acesso mais sofisticado? Quem pode ver as tarefas de quem, quem pode criar tarefas no projeto de quem? Talvez implementar um feature de convite, onde vc envia para uma pessoa o convite para 'Trabalhar' em um projeto que é seu. Permitindo assim que ela pessoa possa ter autonomia de criar tarefas, editar, excluir, etc. Talvez até definindo no ato do convite, o que ela pessoa poderá fazer no projeto, só um leitor, um editor ou outro papel.

* Um outro questionamento é sobre a data de vencimento na tarefa, há a expectativa dela ser usada para notificação ou  um alerta para o usuário? O quanto isso é importante?

* Há a expectativa de além do criador da tarefa poder informar mais participantes? Me parece algo interessante, mas que claramente é algo que precisaria ser discutido se é interessante/importante para os usuários.

## Fase 3 - Final

Para a parte final do Desafio, sobre o que eu melhoria no projeto tenho os seguintes apontamentos:

* Utilização de um bom framework de validação, como o FluentValidation, para validar os inputs nos endpoints. Acho que imaginei um mundo perfeito e então não fiz essa parte a contento.

* Trabalharia mais no domínio tentando deixar ele ainda mais rico e autoexplicativo. Tornando sua compreensão mais fácil e rápida.


* Também podemos pensar em melhorar as escolhas de padrão e implementação para o controle do histórico de mudanças das tarefas. Acho que ele pode ficar melhor com uso de alguns padrões, além de ficar mais limpo também. Atualmente achei a solução que encontrei meio turva.


* Quanto a arquitetura do projeto todo, atualmente acho que ele se encaixa mais em um CQS e não CQRS porque apesar de fazer uso de Commands e Queries eles continuam bem interligadas. Acho que essa pode ser uma evolução importante, ter um modelo para escrita, voltada para as regras de negócio e um modelo para a leitura dos dados.

* Acredito que o item anterior, a separação de modelos para escrita e leitura, pode permitir um melhor e mais fácil uso de soluções de cache, como o Redis, quando necessário. Essa separação também facilitaria no uso de ferramentas diferentes para os modelos diferentes. Por exemplo: usar no modelo de escrita o EF Core, porque tem controle de alterações, de transações. E no modelo de leitura, o Dapper, algo que priorize o desempenho nas consultas.


* Acredito também que a separação dos endpoints em projetos menores pode permitir uma maior manutenibilidade no futuro. Além de proporcionar uma separação maior em futuros deploys e em caso de necessitar escalar a aplicação, podendo aumentar a disponibilidade somente de uma parte e não da aplicação todo.


* Um ponto que a separação de responsabilidades de leitura e escrita ajudariam é, no caso de aumento da aplicação, fazer a migração para uma arquitetura baseada em eventos assíncronos, de consistência eventual. Podemos enviar os commands para uma fila e processa assincronamente, sem fazer o usuário esperar resposta do servidor. Tornando sua experiência mais fluída. 