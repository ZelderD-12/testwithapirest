namespace Store.Connection
{
    public class BDConnection
    {
        private string connectionString= string.Empty;
        public BDConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            connectionString = builder.GetSection("ConnectionStrings:mastercon").Value;
        }
        public string SQLchain()
        {
            return connectionString;
        }
    }
}
