using ShoesManager.Models;
using ShoesManager.Responses;
using System.Linq.Expressions;

namespace ShoesManager.Interfaces
{
    public interface IStore
    {
        Task<ApiResponse> CreateStoreAsync(Store article);
        Task<ApiResponse<Store>> GetStoreByIdAsync(int id);
        Task<ApiResponse> UpdateStoreAsync(Store article);
        Task<ApiResponse> DeleteStoreAsync(int id);
        Task<ApiResponse<IEnumerable<Store>>> GetAllStoresAsync();
        Task<ApiResponse<IEnumerable<Store>>> GetStoreByCriteriaAsync(Expression<Func<Store, bool>> predicate);
    }
}
