using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CommerceCommon.Model;

public class Product
{
    public long Id { get; set; }
    [Required] public string? Name { get; set; }
    [Required] public string? Description { get; set; }
    [Required] public decimal Price { get; set; }

    [Required, DisplayName("Product Image")]
    public string? Base64Img { get; set; }

    public int Quantity { get; set; }
    public bool Featured { get; set; }
    public DateTime DateUploaded { get; set; }
}