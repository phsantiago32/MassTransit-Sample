# MassTransit-Sample

Projeto de exemplo para demonstrar o funcionamento do MassTransit utilizando um Publisher e um Consumer.


### Funcionamento

Ao iniciar o projeto Publisher, nenhuma fila ou exchange é criada.
Ao enviar uma mensagem com o método Send, é criada uma exchange do tipo fanout com o nome passado por parâmetro (order-consumer-queue).

Ao iniciar o projeto Consumer, é criada uma exchange chamada Models:Order, cujo nome reflete o namespace da classe utilizada para representar a mensagem consumida.

Junto a criação da exchange, é feito um bind dessa exchange à outra criada pelo Publisher (order-consumer-queue), fazendo o roteamento de uma exchange para a outra.

É criada a fila order-consumer-queue, fazendo o bind dela à exchange de mesmo nome, passando a receber as mensagens publicadas.

### Como utilizar

Você pode rodar os projetos das seguintes formas:

1. dotnet CLI:

``` shell
cd .\src\

dotnet run --project .\Consumer\Consumer.csproj

dotnet run --project .\Publisher\Publisher.csproj

```

2.  docker-compose

``` shell
docker-compose up
```

Ao utilizar o docker-compose, uma instância do rabbitmq sobe junto com as aplicações.

Com a aplicação rodando, chame o endpoint para enviar uma mensagem para a fila, utilizando a interface do swagger:

> http://localhost:5000/swagger/index.html