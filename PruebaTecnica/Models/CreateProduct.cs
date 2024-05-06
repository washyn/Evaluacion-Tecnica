using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models;

public class CreateProduct
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}