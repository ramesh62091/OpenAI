namespace OpenAIChatGPT.Controllers
{
    public interface IConfigProvider
    {
        string GetAPIKey { get; }
    }

    public class ConfigProvider : IConfigProvider
    {
        private readonly IConfiguration _configuration;
        public ConfigProvider(IConfiguration configProvider)
        {
            _configuration = configProvider;
        }

        public string GetAPIKey => GetValue<string>("Authentication:OpenAIAPIKey");
        private T GetValue<T>(string key)
        {
            return _configuration.GetValue<T>(key) ?? throw new KeyNotFoundException($"{key} not found!");
        }
    }
}
