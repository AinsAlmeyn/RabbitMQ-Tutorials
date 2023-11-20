using MassTransit;
using WMS.Core.Articles.ConnectionAndSettingsArticles.RabbitMQ;
using WMS.Core.Articles.Conversation.RabbitMq.Locations.Request;
using WMS.Core.Articles.Conversation.RabbitMq.Locations.Response;
using WMS.Core.Articles.Database.MongoDb.Locations;
using WMS.Service.QueueManagerService;

Console.WriteLine("PUBLISHER");
string connectionString = "amqps://xurpatmp:0_i4Bp07FWJ9PdOPuyYwbwAmPwOkx-Nr@whale.rmq.cloudamqp.com/xurpatmp";
WmsQueueManager massPubisher = new WmsQueueManager(() => new RabbitMqConnection
{
    ConnectionString = connectionString,
    RequestQueue = "request-queue-trail"
});

#region Request Response
Response<LocationTrailResponse> result = await massPubisher.PublishRequest<LocationTrailRequest, LocationTrailResponse>(new LocationTrailRequest()
{
    isSuccess = false,
    Location = new Location
    {
        Code = "LOC001",
        DefinitionLang = "GIDEN DATA",
        LocationType = "Storage",
        WidthM = 2.5m,
        DepthM = 3.0m,
        HeightM = 2.2m,
        VolumeM3 = 16.5m,
        State = "Active",
        WeightCapacityKg = 1000m,
        Aisle = "A1",
        Bay = "B1",
        Column = "C1",
        Stair = "S1",
        DistanceFactorX = 1.1m,
        DistanceFactorY = 1.2m,
        Parent = "WH-A",
        Barcode = "1234567890"
    }
});
Console.WriteLine(result.Message.isSuccess + " " + result.Message.Location.DefinitionLang);
#endregion

#region Async Publish
//massPubisher.SendMessageAsync<LocationTrailRequest>("request-queue-trail-second", new LocationTrailRequest()
//{
//    isSuccess = false,
//    Location = new Location
//    {
//        Code = "LOC001",
//        DefinitionLang = "GIDEN DATA",
//        LocationType = "Storage",
//        WidthM = 2.5m,
//        DepthM = 3.0m,
//        HeightM = 2.2m,
//        VolumeM3 = 16.5m,
//        State = "Active",
//        WeightCapacityKg = 1000m,
//        Aisle = "A1",
//        Bay = "B1",
//        Column = "C1",
//        Stair = "S1",
//        DistanceFactorX = 1.1m,
//        DistanceFactorY = 1.2m,
//        Parent = "WH-A",
//        Barcode = "1234567890"
//    }
//});
#endregion

Console.Read();