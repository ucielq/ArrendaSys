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
            MercadoPagoConfig.AccessToken = "APP_USR-3158103808833716-110804-82b3dd8e48a945346b7ed7a01b24c7e5-434981148";
            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
                        Title = "Premium",
                        Quantity = 1,
                        CurrencyId = "ARS",
                        UnitPrice = 2000m,
                    },
                },
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "https://arrendasys.azurewebsites.net/MercadoPago/pagoAprobado",
                    Failure = "https://arrendasys.azurewebsites.net/Home",
                    Pending = "https://arrendasys.azurewebsites.net/Home",
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