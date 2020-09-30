using Loreggia.Delivery.Track.Autenticador.Shared.Helper.Jsons.Resolver;
using Newtonsoft.Json;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Helper.Jsons
{
    public static class JsonHelper
    {
        public static string JsonSerialize<T>(this T item) where T : class =>
            JsonConvert.SerializeObject(item, new JsonSerializerSettings()
            {
                ContractResolver = new PrivateSetterContractResolver()
            });

        public static T JsonDeserialize<T>(this string json) where T : class =>
            JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings()
            {
                ContractResolver = new PrivateSetterContractResolver()
            });
    }
}
