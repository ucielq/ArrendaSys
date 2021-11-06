using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;

namespace ArrendaSys
{
    public class MercadoPago
    {

        public async Task createPreferences()
        {
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

            // Crea la preferencia usando el client
            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(request);
        }
    }
}