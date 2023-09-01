namespace BudgetManagerAPI.Connection
{
    public class ConnectionDB
    {
        private string? connectionString = string.Empty;

        public ConnectionDB() 
        {
            var constructor = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            connectionString = constructor.GetSection("ConnectionStrings:DBstring").Value;
        
        }

        public string StringSQL()
        {
            return connectionString;
        }

    }
}
