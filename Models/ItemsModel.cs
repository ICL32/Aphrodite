using System.ComponentModel.DataAnnotations;

namespace Aphrodite.Models;

public class ItemsModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public float Cost { get; set; }
    [Required]
    public byte[] ImageData { get; set; }
}

