namespace MS.Features
{
    public class ConfigurationContext
    {
        public string Key { get; private set; }

        public ConfigurationContext(string key)
        {
            Key = key;
        }
    }
}
