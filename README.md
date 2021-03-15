Projeto de exemplo para demonstrar o funcionamento do MassTransit utilizando um Publisher e um Consumer


### Funcionamento

Ao iniciar o projeto Publisher, nenhuma fila ou exchange é criada
Ao enviar uma mensagem com o método Send, é criada uma exchange do tipo fanout com o nome passado por parâmetro (order-consumer-queue)

Ao iniciar o projeto Consumer, é criada uma exchange chamada Models:Order, cujo nome reflete o namespace da classe utilizada para representar a mensagem consumida

Junto a criação da exchange, é feito um bind dessa exchange à outra criada pelo Publisher (order-consumer-queue), fazendo o roteamento de uma exchange para a outra

É criada a fila order-consumer-queue, fazendo o bind dela à exchange de mesmo nome, passando a receber as mensagens publicadas