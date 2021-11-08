using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using MercadoPago.Config;
namespace ArrendaSys.Controllers.Api
{
    public class MercadoPagoApiController : ApiController
    {
        [System.Web.Http.Route("Api/MercadoPago/create_preference")]
        [System.Web.Http.ActionName("create_preference")]
        [System.Web.Http.HttpPost]
        public string create_preference()
        {
            MercadoPagoConfig.AccessToken = "APP_USR-5188967914255972-072920-8569e9ebf8526fc9867cd6f044164209-434981148";
            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
                        Title = "Premium",
                        Quantity = 1,
                        CurrencyId = "ARS",
                        UnitPrice = 1m,
                    },
                },
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "https://localhost:44346/MercadoPago/pagoAprobado",
                    Failure = "https://localhost:44346/Home",
                    Pending = "https://localhost:44346/Home",
                },
                AutoReturn = "approved",
            };
            var client = new PreferenceClient();
            Preference preference = client.Create(request);
            string response = preference.Id;
            return response;
        }
    }
}