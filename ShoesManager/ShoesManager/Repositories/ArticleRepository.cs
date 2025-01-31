using Microsoft.EntityFrameworkCore;
using ShoesManager.Data;
using ShoesManager.Interfaces;
using ShoesManager.Models;
using ShoesManager.Responses;
using System.Linq.Expressions;

namespace ShoesManager.Repositories
{
    public class ArticleRepository : IArticle
    {
        private readonly AppDbContext _context;

        public ArticleRepository(AppDbContext context)
        {
            _context = context;
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

                // Agregar el artículo a la base de datos
                _context.Articles.Add(article);
                await _context.SaveChangesAsync();

                return new ApiResponse(Success: true);
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
                // Buscar el artículo por ID
                var article = await _context.Articles.FindAsync(id);
                if (article == null)
                {
                    return new ApiResponse(Success: false, ErrorCode: 404, ErrorMessage: "Article not found");
                }

                // Eliminar el artículo de la base de datos
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();

                return new ApiResponse(Success: true);
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
                // Obtener todos los artículos de la base de datos
                var articles = await _context.Articles.ToListAsync();

                return new ApiResponse<IEnumerable<Article>>(
                    Success: true,
                    Data: articles
                );
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
                // Buscar el artículo por ID
                var article = await _context.Articles.FindAsync(id);
                if (article == null)
                {
                    return new ApiResponse<Article>(
                        Success: false,
                        ErrorCode: 404,
                        ErrorMessage: "Article not found",
                        Data: null
                    );
                }

                return new ApiResponse<Article>(
                    Success: true,
                    Data: article
                );
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

                // Filtrar los artículos según el criterio proporcionado
                var articles = await _context.Articles
                    .Where(predicate)
                    .ToListAsync();

                return new ApiResponse<IEnumerable<Article>>(
                    Success: true,
                    Data: articles
                );
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

                // Actualizar el artículo en la base de datos
                _context.Articles.Update(article);
                await _context.SaveChangesAsync();

                return new ApiResponse(Success: true);
            }
            catch (Exception ex)
            {
                return new ApiResponse(Success: false, ErrorCode: 500, ErrorMessage: ex.Message);
            }
        }
    }
}