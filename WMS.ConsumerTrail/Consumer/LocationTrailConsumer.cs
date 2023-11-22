using MassTransit;
using System.Text.Json;
using WMS.Core.Entities.Communication.RabbitMq.Locations.Request;
using WMS.Core.Entities.Communication.RabbitMq.Locations.Response;
using WMS.Core.Entities.Database.MongoDb.Locations;

namespace WMS.ConsumerTrail.Consumer
{
    public class LocationTrailConsumer : IConsumer<LocationTrailRequest>
    {
        public async Task Consume(ConsumeContext<LocationTrailRequest> context)
        {
            var location = new Location()
            {
                Code = "LOC002",
                DefinitionLang = "GELEN MESAJ",
                LocationType = "Receiving",
                WidthM = 3.0m,
                DepthM = 4.0m,
                HeightM = 3.5m,
                VolumeM3 = 42.0m,
                State = "Inactive",
                WeightCapacityKg = 1500m,
                Aisle = "A2",
                Bay = "B2",
                Column = "C2",
                Stair = "S2",
                DistanceFactorX = 1.3m,
                DistanceFactorY = 1.4m,
                Parent = "WH-B",
                Barcode = "0987654321"
            };
            var locationResponse = new LocationTrailResponse()
            {
                isSuccess = true,
                Location = location
            };

            await context.RespondAsync<LocationTrailResponse>(locationResponse);
        }
    }
    public class LocationTrailConsumerSecond : IConsumer<LocationTrailRequest>
    {
        public async Task Consume(ConsumeContext<LocationTrailRequest> context)
        {
            var location = new Location()
            {
                Code = "LOC002",
                DefinitionLang = "GELEN MESAJ",
                LocationType = "Receiving",
                WidthM = 3.0m,
                DepthM = 4.0m,
                HeightM = 3.5m,
                VolumeM3 = 42.0m,
                State = "Inactive",
                WeightCapacityKg = 1500m,
                Aisle = "A2",
                Bay = "B2",
                Column = "C2",
                Stair = "S2",
                DistanceFactorX = 1.3m,
                DistanceFactorY = 1.4m,
                Parent = "WH-B",
                Barcode = "0987654321"
            };
            var options = new JsonSerializerOptions
            {
                WriteIndented = true // Bu seçenek JSON'ı girintili (indented) bir şekilde yazdırır
            };

            string jsonString = JsonSerializer.Serialize(location, options);
            await Console.Out.WriteLineAsync(jsonString);
        }
    }
}
