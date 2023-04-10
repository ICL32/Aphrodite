using Aphrodite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;

namespace Aphrodite.Pages;

public class Item : PageModel
{
    public List<ItemsModel> Items { get; set; }
    public async Task<IActionResult> OnGetAsync()
    {
        using (var connection = new MySqlConnection("server=localhost;database=Aphrodite;uid=Aphrodite;pwd=1234"))
        {
            await connection.OpenAsync();

            var query = "SELECT Id, Name, Cost, ImageData FROM Items";
            using (var command = new MySqlCommand(query, connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    Items = new List<ItemsModel>();
                    while (await reader.ReadAsync())
                    {
                        var item = new ItemsModel
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Cost = reader.GetFloat("Cost"),
                            ImageData = (byte[])reader["ImageData"]
                        };
                        Items.Add(item);
                    }
                }
            }
        }

        return Page();
    }
}