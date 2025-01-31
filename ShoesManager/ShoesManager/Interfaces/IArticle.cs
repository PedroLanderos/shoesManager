using ShoesManager.Models;
using ShoesManager.Responses;
using System.Linq.Expressions;

namespace ShoesManager.Interfaces
{
    public interface IArticle
    {
        Task<ApiResponse> CreateArticleAsync(Article article);
        Task<ApiResponse<Article>> GetArticleByIdAsync(int id);
        Task<ApiResponse> UpdateArticleAsync(Article article);
        Task<ApiResponse> DeleteArticleAsync(int id);
        Task<ApiResponse<IEnumerable<Article>>> GetAllArticlesAsync();
        Task<ApiResponse<IEnumerable<Article>>> GetProductsByCriteriaAsync(Expression<Func<Article, bool>> predicate);
    }
}
