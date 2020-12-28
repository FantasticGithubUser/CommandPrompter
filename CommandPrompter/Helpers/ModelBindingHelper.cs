using Newtonsoft.Json;

namespace CommandPrompter.Helpers
{
    public static class ModelBindingHelper
    {
        public static T BindModel<T>(string json) where T : class, new()
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
