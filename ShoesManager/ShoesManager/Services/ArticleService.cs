using ShoesManager.Interfaces;
using ShoesManager.Models;
using ShoesManager.Responses;
using System.Linq.Expressions;

namespace ShoesManager.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticle _articleRepository;

        public ArticleService(IArticle articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<ApiResponse> CreateArticleAsync(Article article)
        {
            try
            {
                // Validar que el artículo no sea nulo
                if (article == null)
                {
                    return new ApiResponse(Success: false, ErrorCode: 400, ErrorMessage: "Article cannot be null");
                }

                // Llamar al repositorio para crear el artículo
                var result = await _articleRepository.CreateArticleAsync(article);

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse(Success: false, ErrorCode: 500, ErrorMessage: ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteArticleAsync(int id)
        {
            try
            {
                // Validar que el ID sea válido
                if (id <= 0)
                {
                    return new ApiResponse(Success: false, ErrorCode: 400, ErrorMessage: "Invalid article ID");
                }

                // Llamar al repositorio para eliminar el artículo
                var result = await _articleRepository.DeleteArticleAsync(id);

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse(Success: false, ErrorCode: 500, ErrorMessage: ex.Message);
            }
        }

        public async Task<ApiResponse<IEnumerable<Article>>> GetAllArticlesAsync()
        {
            try
            {
                // Llamar al repositorio para obtener todos los artículos
                var result = await _articleRepository.GetAllArticlesAsync();

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Article>>(
                    Success: false,
                    ErrorCode: 500,
                    ErrorMessage: ex.Message,
                    Data: null
                );
            }
        }

        public async Task<ApiResponse<Article>> GetArticleByIdAsync(int id)
        {
            try
            {
                // Validar que el ID sea válido
                if (id <= 0)
                {
                    return new ApiResponse<Article>(
                        Success: false,
                        ErrorCode: 400,
                        ErrorMessage: "Invalid article ID",
                        Data: null
                    );
                }

                // Llamar al repositorio para obtener el artículo por ID
                var result = await _articleRepository.GetArticleByIdAsync(id);

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse<Article>(
                    Success: false,
                    ErrorCode: 500,
                    ErrorMessage: ex.Message,
                    Data: null
                );
            }
        }

        public async Task<ApiResponse<IEnumerable<Article>>> GetProductsByCriteriaAsync(Expression<Func<Article, bool>> predicate)
        {
            try
            {
                // Validar que el predicado no sea nulo
                if (predicate == null)
                {
                    return new ApiResponse<IEnumerable<Article>>(
                        Success: false,
                        ErrorCode: 400,
                        ErrorMessage: "Predicate cannot be null",
                        Data: null
                    );
                }

                // Llamar al repositorio para obtener los artículos que cumplan con el criterio
                var result = await _articleRepository.GetProductsByCriteriaAsync(predicate);

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Article>>(
                    Success: false,
                    ErrorCode: 500,
                    ErrorMessage: ex.Message,
                    Data: null
                );
            }
        }

        public async Task<ApiResponse> UpdateArticleAsync(Article article)
        {
            try
            {
                // Validar que el artículo no sea nulo
                if (article == null)
                {
                    return new ApiResponse(Success: false, ErrorCode: 400, ErrorMessage: "Article cannot be null");
                }

                // Llamar al repositorio para actualizar el artículo
                var result = await _articleRepository.UpdateArticleAsync(article);

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse(Success: false, ErrorCode: 500, ErrorMessage: ex.Message);
            }
        }
    }
}