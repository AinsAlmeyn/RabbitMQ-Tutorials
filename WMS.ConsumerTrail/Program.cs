using MassTransit;
using WMS.ConsumerTrail.Consumer;
using WMS.Core.Articles.ConversationArticles.RabbitMqConversation.LocationArticles.Response;
using WMS.Service.MassTransitPublisher;

Console.WriteLine("CONSUMER");
string connectionString = "amqps://xurpatmp:0_i4Bp07FWJ9PdOPuyYwbwAmPwOkx-Nr@whale.rmq.cloudamqp.com/xurpatmp";

var busControl = BusFactory.CreateBusWithConsumers(connectionString, cfg =>
{
    cfg.ReceiveEndpoint("request-queue-trail", endpoint =>
    {
        endpoint.Consumer<LocationTrailConsumer>();
    });

    cfg.ReceiveEndpoint("request-queue-trail-second", endpoint =>
    {
        endpoint.Consumer<LocationTrailConsumerSecond>();
    });
});

await busControl.StartAsync();

Console.Read();