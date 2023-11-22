using MassTransit;
using WMS.ConsumerTrail.Consumer;
using WMS.Service.QueueManagerService;

Console.WriteLine("CONSUMER");
string connectionString = "amqps://xurpatmp:0_i4Bp07FWJ9PdOPuyYwbwAmPwOkx-Nr@whale.rmq.cloudamqp.com/xurpatmp";

var busControl = BusFactory.CreateBusWithConsumers(connectionString, cfg =>
{
    //cfg.ReceiveEndpoint("request-queue-trail", endpoint =>
    //{
    //    endpoint.Consumer<LocationTrailConsumer>();
    //    endpoint.PrefetchCount = 16;
    //    endpoint.UseConcurrencyLimit(10); // Adjust as necessary
    //});

    cfg.ReceiveEndpoint("LOCATION", endpoint =>
    {
        endpoint.Consumer<LocationTrailConsumerThird>();
    });

    //cfg.ReceiveEndpoint("request-queue-trail-second", endpoint =>
    //{
    //    endpoint.Consumer<LocationTrailConsumerSecond>();
    //});
});

await busControl.StartAsync();

Console.Read();