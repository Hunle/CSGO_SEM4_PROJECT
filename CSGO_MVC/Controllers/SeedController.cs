using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using Models;


namespace CSGO_MVC.Controllers
{
    public sealed partial class SeedController 
    {

        private static readonly MediaTypeHeaderValue _mediaTypeValue = new MediaTypeHeaderValue("application/json");
        private static readonly MediaTypeWithQualityHeaderValue _mediaTypeWithQualityValue = new MediaTypeWithQualityHeaderValue("application/json");
        private static readonly Uri _serviceUri = new Uri("https://api.random.org/json-rpc/2/invoke", UriKind.Absolute);
        //private static readonly IDictionary<string, JsonRpcResponseContract> _contracts = CreateContracts();

        private readonly string _apiKey = "1e90f201-feed-4ebd-849f-34c40709e027";
        private readonly HttpMessageInvoker _httpInvoker;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        




    }
}