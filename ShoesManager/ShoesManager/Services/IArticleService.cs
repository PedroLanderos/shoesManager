using ShoesManager.DTOs;
using ShoesManager.Models;
using ShoesManager.Responses;
using System.Linq.Expressions;

namespace ShoesManager.Services
{
    public interface IArticleService
    {
        Task<ApiResponse> CreateArticleAsync(ArticleDTO articleDTO);
        Task<ApiResponse<ArticleDTO>> GetArticleByIdAsync(int id);
        Task<ApiResponse> UpdateArticleAsync(ArticleDTO articleDTO);
        Task<ApiResponse> DeleteArticleAsync(int id);
        Task<ApiResponse<IEnumerable<ArticleDTO>>> GetAllArticlesAsync();
        Task<ApiResponse<IEnumerable<ArticleDTO>>> GetProductsByCriteriaAsync(Expression<Func<Article, bool>> predicate);
    }
}
