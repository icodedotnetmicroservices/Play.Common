namespace Play.Common.Settings
{
    public class MongoDbSettings
    {
        public string Host { get; init; }
        public int Port { get; init; }

        // Expression body definition, it's a property defined directly by the value on the right side.
        public string ConnectionString => $"mongodb://{Host}:{Port}";
    }
}