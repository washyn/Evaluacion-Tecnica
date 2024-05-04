using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnica;

public class ProductController : Controller
{
    private string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";

    public IActionResult GetAllProducts()
    {
        List<string> products = new List<string>();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT Name FROM Products", connection);
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    products.Add(reader.GetString(0));
                }
            }
            finally
            {
                reader.Close();
            }
        }
        return View(products);
    }

    public IActionResult AddProduct(string name)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = "INSERT INTO Products (Name) VALUES (@Name)";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
            }
        }
        return RedirectToAction("GetAllProducts");
    }
}
