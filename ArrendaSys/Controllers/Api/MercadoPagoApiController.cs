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
        public object create_preference()
        {
            MercadoPagoConfig.AccessToken = "app_usr-579a8bef-0b8e-4246-8f8c-708eec0975a0";
            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
            Title = "Premium",
            Quantity = 1,
            CurrencyId = "ARS",
            UnitPrice = 100m,
                    },
                },
            };
            request.AutoReturn = "Approved";
            // Crea la preferencia usando el client
            var client = new PreferenceClient();
            
            Preference preference = client.Create(request);
            object response = new{ data = preference };
            return response;
        }
    }
}