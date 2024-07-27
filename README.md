# Tech Challenge

Repositório com o projeto que apresenta os entregáveis do Tech Challenge do curso de pós-graduação Software Architecture. O projeto consiste no desenvolvimento de um sistema de autoatendimento para uma lanchonete em expansão, visando otimizar o controle de pedidos e aumentar a eficiência no atendimento. 


##  Acesso ao projeto

Você pode [acessar o código fonte do projeto inicial](https://github.com/BrunoCesarCarvalho/Tech-Challenge-Fiap) 

## Entregáveis

- [Desenho de Arquitetura](/Desenho%20Arquitetura.png)
- [Collection para Postman](/Tech-Challenge-FIAP-Swagger.postman_collection.json)
- [Guia com instruções para execução do projeto](/Instruções%20de%20Criação%20e%20Execução.pdf)
- [Video demonstrando a arquitetura desenvolvida](https://www.youtube.com/watch?v=fjYOcWaiCV4)

##  Fases Tech Challenge

### Fase 1

- Domain Driven Design Brainstorming 
- Aplicação de arquitetura Hexagonal
- Aplicação monolítica com .NET 8 e SQLServer
- Criação de Dockerfile e Docker-compose 

### Fase 2

- Refatoração do código para Clean code e Clean Architecture
- Atualização da solução:
  1. **Checkout Pedido:** Receber produtos solicitados e retornar identificação do pedido.
  2. **Consultar Status Pagamento:** Informar se o pagamento foi aprovado.
  3. **Webhook:** Receber confirmação de pagamento.
  4. **Lista de Pedidos:** Ordenar por status (Pronto > Em Preparação > Recebido) e data, excluindo status Finalizado.
  5. **Atualizar Status do Pedido:** Permitir atualização do status.
  6. **Desafio Extra:** Integrar com Mercado Pago para gerar QRCode e capturar pagamentos.
- Criação de arquitetura em Kubernetes para atender aos requisitos funcionais
  

## Como rodar o projeto

Para executar o projeto, é necessário seguir as instruções descritas no arquivo "Instruções de Criação e Execução", disponibilizado neste mesmo diretório, nos formatos .pdf e .docx.


## Tecnologias utilizadas

As técnicas e tecnologias utilizadas pra isso são:
- .NET 8
- C#
- SQL Server
- Docker
- Kubernetes
- Swagger
- Dependências:
        
    - Microsoft.AspNetCore.Http.Abstractions" Version="2.2.0"
    - Microsoft.AspNetCore.WebUtilities" Version="8.0.5"
    - Microsoft.Extensions.DependencyInjection.Abstractions" Version="8.0.1"
 🏆 
## Equipe

- Bruno Cesar Carvalho(RM 354118) - bruno.cesar.carvalho@hotmail.com 

- Everson Choma (RM 354073) - everson.choma@gmail.com 

- Camila Pessôa(RM 351322) - camilabentespessoa@gmail.com 

- Diego Nunes Reis(RM 353835) - diegonunesftw@gmail.com	 

- Ricardo Soares Nogueira(RM 353218) - ricardosn87@hotmail.com 

 
## Mais informações

- [Miro com documentação do Event Storm](https://miro.com/app/board/uXjVKPoci9E=/?shareablePresentation=1)
