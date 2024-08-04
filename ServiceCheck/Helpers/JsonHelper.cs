using Newtonsoft.Json;

namespace ServiceCheck.Helpers
{
    public class JsonHelper
    {
        public static string Serialize<T>(T entity)
        {
            try
            {
                return JsonConvert.SerializeObject(entity);
            }
            catch
            {
                return "";
            }
        }

        public static T Deserialize<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default;
            }
        }
    }
}
