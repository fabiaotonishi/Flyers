using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Flyers.Web.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject<T>(this ISession sessao, string chave, T tipo)
        {
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            sessao.SetString(chave, JsonConvert.SerializeObject(tipo, Formatting.Indented, jsonSettings));
        }

        public static T GetObject<T>(this ISession sessao, string chave)
        {
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            var value = sessao.GetString(chave);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value, jsonSettings);
        }
    }
}
