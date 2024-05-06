namespace PruebaTecnica.Others;

public static class Extensions
{
    public static string GetDefaultConexion(this IConfiguration configuration)
    {
        return configuration.GetConnectionString("Default") ?? throw new ArgumentException("Conexion string not found.");
    }
}