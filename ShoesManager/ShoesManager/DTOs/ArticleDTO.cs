using System.ComponentModel.DataAnnotations;

namespace ShoesManager.DTOs
{
    public record ArticleDTO(
        int Id,
        [Required] string Name,
        string? Description,
        [Required, Range(0, double.MaxValue)] decimal Price,
        [Required, Range(0, int.MaxValue)] int TotalInShelf,
        [Required, Range(0, int.MaxValue)] int TotalInVault,
        [Required] int StoreId
    );
}
