using ShoesManager.DTOs;
using ShoesManager.Interfaces;
using ShoesManager.Mappers;
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

        public async Task<ApiResponse> CreateArticleAsync(ArticleDTO articleDTO)
        {
            try
            {
                // Validar que el DTO no sea nulo
                if (articleDTO == null)
                {
                    return new ApiResponse(Success: false, ErrorCode: 400, ErrorMessage: "ArticleDTO cannot be null");
                }

                // Convertir el DTO a entidad
                var article = ArticleMapper.ToEntity(articleDTO);

                // Llamar al repositorio para crear el artículo
                var result = await _articleRepository.CreateArticleAsync(article);

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse(Success: false, ErrorCode: 500, ErrorMessage: ex.Message);
            }
        }

        public async Task<ApiResponse<ArticleDTO>> GetArticleByIdAsync(int id)
        {
            try
            {
                // Validar que el ID sea válido
                if (id <= 0)
                {
                    return new ApiResponse<ArticleDTO>(
                        Success: false,
                        ErrorCode: 400,
                        ErrorMessage: "Invalid article ID",
                        Data: null
                    );
                }

                // Llamar al repositorio para obtener el artículo por ID
                var result = await _articleRepository.GetArticleByIdAsync(id);
                if (!result.Success || result.Data == null)
                {
                    return new ApiResponse<ArticleDTO>(
                        Success: false,
                        ErrorCode: 404,
                        ErrorMessage: "Article not found",
                        Data: null
                    );
                }

                // Convertir la entidad a DTO
                var articleDTO = ArticleMapper.FromEntity(result.Data, null).Item1;

                return new ApiResponse<ArticleDTO>(
                    Success: true,
                    Data: articleDTO
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<ArticleDTO>(
                    Success: false,
                    ErrorCode: 500,
                    ErrorMessage: ex.Message,
                    Data: null
                );
            }
        }

        public async Task<ApiResponse> UpdateArticleAsync(ArticleDTO articleDTO)
        {
            try
            {
                // Validar que el DTO no sea nulo
                if (articleDTO == null)
                {
                    return new ApiResponse(Success: false, ErrorCode: 400, ErrorMessage: "ArticleDTO cannot be null");
                }

                // Convertir el DTO a entidad
                var article = ArticleMapper.ToEntity(articleDTO);

                // Llamar al repositorio para actualizar el artículo
                var result = await _articleRepository.UpdateArticleAsync(article);

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

        public async Task<ApiResponse<IEnumerable<ArticleDTO>>> GetAllArticlesAsync()
        {
            try
            {
                // Llamar al repositorio para obtener todos los artículos
                var result = await _articleRepository.GetAllArticlesAsync();
                if (!result.Success || result.Data == null)
                {
                    return new ApiResponse<IEnumerable<ArticleDTO>>(
                        Success: false,
                        ErrorCode: 500,
                        ErrorMessage: "Failed to retrieve articles",
                        Data: null
                    );
                }

                // Convertir las entidades a DTOs
                var articleDTOs = ArticleMapper.FromEntity(null!, result.Data).Item2;

                return new ApiResponse<IEnumerable<ArticleDTO>>(
                    Success: true,
                    Data: articleDTOs
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<ArticleDTO>>(
                    Success: false,
                    ErrorCode: 500,
                    ErrorMessage: ex.Message,
                    Data: null
                );
            }
        }

        public async Task<ApiResponse<IEnumerable<ArticleDTO>>> GetProductsByCriteriaAsync(Expression<Func<Article, bool>> predicate)
        {
            try
            {
                // Validar que el predicado no sea nulo
                if (predicate == null)
                {
                    return new ApiResponse<IEnumerable<ArticleDTO>>(
                        Success: false,
                        ErrorCode: 400,
                        ErrorMessage: "Predicate cannot be null",
                        Data: null
                    );
                }

                // Llamar al repositorio para obtener los artículos que cumplan con el criterio
                var result = await _articleRepository.GetProductsByCriteriaAsync(predicate);
                if (!result.Success || result.Data == null)
                {
                    return new ApiResponse<IEnumerable<ArticleDTO>>(
                        Success: false,
                        ErrorCode: 500,
                        ErrorMessage: "Failed to retrieve articles",
                        Data: null
                    );
                }

                // Convertir las entidades a DTOs
                var articleDTOs = ArticleMapper.FromEntity(null!, result.Data).Item2;

                return new ApiResponse<IEnumerable<ArticleDTO>>(
                    Success: true,
                    Data: articleDTOs
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<ArticleDTO>>(
                    Success: false,
                    ErrorCode: 500,
                    ErrorMessage: ex.Message,
                    Data: null
                );
            }
        }
    }
}