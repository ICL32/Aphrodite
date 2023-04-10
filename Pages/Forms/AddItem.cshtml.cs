using Aphrodite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;

namespace Aphrodite.Pages.Forms
{
    public class AddItem : PageModel
    {
        [BindProperty]
        public ItemsModel Item { get; set; }
        
        [BindProperty]
        public IFormFile UploadedImage { get; set; }
        

        public async Task<IActionResult> OnPostAsync()
        {

            // Convert the uploaded image to a byte array
            if (UploadedImage != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await UploadedImage.CopyToAsync(memoryStream);
                    Item.ImageData = memoryStream.ToArray();
                }
            }
            
            using (var connection = new MySqlConnection("server=localhost;database=Aphrodite;uid=Aphrodite;pwd=1234"))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO aphrodite.items (Id, Name, Cost, ImageData) VALUES (@id, @name, @cost, @imageData)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", Item.Id);
                    command.Parameters.AddWithValue("@name", Item.Name);
                    command.Parameters.AddWithValue("@cost", Item.Cost);
                    command.Parameters.AddWithValue("@imageData", Item.ImageData);
                    await command.ExecuteNonQueryAsync();
                }
            }

            Console.WriteLine($"Item saved: Id = {Item.Id}, Name = {Item.Name}, Cost = {Item.Cost}");

            return RedirectToPage("/Index");
        }
    }
}