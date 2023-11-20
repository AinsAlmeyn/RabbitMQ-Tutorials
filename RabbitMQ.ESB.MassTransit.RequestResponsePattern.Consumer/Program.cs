using MassTransit;
using RabbitMQ.ESB.MassTransit.RequestResponsePattern.Consumer.Consumers;

Console.WriteLine("Consumer");

string rabbitMQUri = "amqps://xurpatmp:0_i4Bp07FWJ9PdOPuyYwbwAmPwOkx-Nr@whale.rmq.cloudamqp.com/xurpatmp";

string requestQueue = "request-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQUri);

    factory.ReceiveEndpoint(requestQueue, endpoint =>
    {
        endpoint.Consumer<ReqeustMessageConsumer>();
    });
});

await bus.StartAsync();

Console.Read();