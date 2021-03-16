# MassTransit-Sample

Projeto de exemplo para demonstrar o funcionamento do MassTransit utilizando um Publisher e um Consumer, conectados ao RabbitMQ.


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

2.  docker-compose:

``` shell
cd .\.docker\

docker-compose up
```

3. Visual Studio:

    ![vs-docker](https://i.imgur.com/KBTLU3W.jpg)

Por padrão, a aplicação se conecta a uma instância externa do RabbitMQ via docker, para isso crie uma network chama "app" e rode o container do RabbitMQ apontando para essa network, ex:

``` shell
docker create network app

docker run --rm -it --network app --hostname rabbitmq --name rabbitmq -p 15672:15672 -p 5672:5672 rabbitmq:3-management
```

Para rodar uma instância do RabbitMQ junto com as aplicações basta remover os comentários e remover as linhas 4, 5 e 6 no docker-compose.yaml

Com a aplicação rodando, chame o endpoint para enviar uma mensagem para a fila, utilizando a interface do swagger ou via curl:

> http://localhost:5000/swagger/index.html

``` shell
curl -X POST "http://localhost:5000/api/Order" -H  "accept: */*" -H  "Content-Type: application/json" -d "123"
```