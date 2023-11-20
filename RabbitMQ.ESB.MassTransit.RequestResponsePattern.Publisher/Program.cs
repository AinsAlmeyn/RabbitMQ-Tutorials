using MassTransit;
using RabbitMQ.ESB.MassTransit.Shared.RequestResponseMessages;

Console.WriteLine("Publisher");

string rabbitMQUri = "amqps://xurpatmp:0_i4Bp07FWJ9PdOPuyYwbwAmPwOkx-Nr@whale.rmq.cloudamqp.com/xurpatmp";

string requestQueue = "request-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQUri);
});

await bus.StartAsync();

IRequestClient<RequestMessage> request = bus.CreateRequestClient<RequestMessage>(new Uri($"{rabbitMQUri}/{requestQueue}"));

int i = 1;
while (true)
{
    var response = await request.GetResponse<ResponseMessage>(new() { MessageNo = i, Text = $"{i++}. request" });
    Console.WriteLine($"Response Received : {response.Message.Text}");
}
await bus.StopAsync();

Console.Read();