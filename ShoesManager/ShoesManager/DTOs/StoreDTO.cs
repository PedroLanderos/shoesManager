using System.ComponentModel.DataAnnotations;

namespace ShoesManager.DTOs
{
    public record StoreDTO(
        int Id,
        [Required] string Name,
        [Required] string Address
    );

}
