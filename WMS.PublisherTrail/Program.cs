using Newtonsoft.Json;
using WMS.Core.Entities.Base;
using WMS.Core.Entities.Database.MongoDb.LocationEntities;
using WMS.Service.ServiceConnector.Connectors;

Console.WriteLine("Hello World!");

#region Get request with querystring = Success
//string url = "http://localhost:7215/api/Delivery/GetAllISSDeliveryHeaderWithFilter";
//ServiceConnector<List<string>> connector = new();


//Dictionary<string, string> queryParams = new Dictionary<string, string>();
//queryParams.Add("customerName", "Musteri adi");
//queryParams.Add("dlvDocNo", "Sip No");
//queryParams.Add("startTime", "2021-01-01 00:00:00");
//queryParams.Add("endTime", "2021-02-02 00:00:00");


//BaseResponse<List<string>> result = await connector.GetAsync(url, queryParams);
//Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
#endregion


LocationConnector<Location> locationConnector = new(new WMS.Service.ServiceConnector.ApiClient.BaseUrlContainer() { LocationServiceUrl = "https://localhost:7168/api/Location" });
var result = await locationConnector.GetAllLocations(new BaseRequest<Location>()
{
    Data = null,
    RequestId = Guid.NewGuid().ToString(),
    Sender = "WMS.PublisherTrail"
});
Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));

Console.Read();