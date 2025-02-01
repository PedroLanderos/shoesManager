using ShoesManager.DTOs;
using ShoesManager.Models;

namespace ShoesManager.Mappers
{
    public static class ArticleMapper
    {
        public static Article ToEntity(ArticleDTO articleDTO) => new()
        {
            Id = articleDTO.Id,
            Name = articleDTO.Name,
            Description = articleDTO.Description,
            Price = articleDTO.Price,
            TotalInShelf = articleDTO.TotalInShelf,
            TotalInVault = articleDTO.TotalInVault,
            StoreId = articleDTO.StoreId
        };

        public static (ArticleDTO?, IEnumerable<ArticleDTO>?) FromEntity(Article article, IEnumerable<Article>? articles)
        {
            // Si es solo un artículo
            if (article is not null || articles is null)
            {
                var singleArticle = new ArticleDTO(
                    article!.Id,
                    article.Name!,
                    article.Description,
                    article.Price,
                    article.TotalInShelf,
                    article.TotalInVault,
                    article.StoreId
                );
                return (singleArticle, null);
            }

            // Si es una lista de artículos
            if (articles is not null || article is null)
            {
                var articleList = articles!.Select(a =>
                    new ArticleDTO(
                        a.Id,
                        a.Name!,
                        a.Description,
                        a.Price,
                        a.TotalInShelf,
                        a.TotalInVault,
                        a.StoreId
                    )
                ).ToList();

                return (null, articleList);
            }

            // Si ambos valores son null
            return (null, null);
        }
    }
}
