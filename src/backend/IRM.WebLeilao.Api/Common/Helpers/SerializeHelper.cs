using Newtonsoft.Json;

namespace IRM.WebLeilao.Api.Common.Helpers
{
    public class SerializeHelper
    {
        public static string SerializeObject(object entidade)
        {
            var objetoSerializado = JsonConvert.SerializeObject(entidade, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                Formatting = Formatting.Indented
            });

            return objetoSerializado;

        }
    }
}