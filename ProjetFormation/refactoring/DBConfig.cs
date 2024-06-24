public static class DBConfig
{
    private static readonly string connectionString = "Server=128.98.12.1;Database=prodDB1;User Id=admin;Password=$p@sswOrd!!;";

    public static string GetConnectionString()
    {
        return connectionString;
    }
}
