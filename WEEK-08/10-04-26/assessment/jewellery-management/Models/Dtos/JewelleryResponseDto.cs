using System.ComponentModel.DataAnnotations;
namespace JewelleryApi.Models.Dtos
{
    public class JewelleyResponseDto
    {
        [Required]
        public Guid Id{get; set;}

        [Required]
        [StringLength(50,MinimumLength =(3))]
        public string Name{get; set;}= string.Empty;


        [Required]
        [StringLength(50,MinimumLength =(3))]
        public string Material{get; set;} = string.Empty;

        [Required]
        [StringLength(50,MinimumLength =(3))]
        public string Category{ get; set;} = string.Empty;

        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
    }
}