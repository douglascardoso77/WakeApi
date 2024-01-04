
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Product
{
    public class ProductDtoUpdate
    {

        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome do produto é um campo obrigatório.")]
        [StringLength(40, ErrorMessage = "Nome do produto deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "valor em estoque deve ser maior ou igual a 0.")]
        public int Stock { get; set; }
        [Range(0, Double.PositiveInfinity, ErrorMessage = "Preço do produto não pode ser negativo.")]
        public decimal Price { get; set; }
    }
}