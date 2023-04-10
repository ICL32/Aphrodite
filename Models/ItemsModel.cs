using System.ComponentModel.DataAnnotations;

namespace Aphrodite.Models;

public class ItemsModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Cost { get; set; }
    public byte[] ImageData { get; set; }
}

