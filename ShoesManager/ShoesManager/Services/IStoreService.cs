using ShoesManager.DTOs;
using ShoesManager.Models;
using ShoesManager.Responses;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoesManager.Services
{
    public interface IStoreService
    {
        Task<ApiResponse> CreateStoreAsync(StoreDTO storeDTO);
        Task<ApiResponse<StoreDTO>> GetStoreByIdAsync(int id);
        Task<ApiResponse> UpdateStoreAsync(StoreDTO storeDTO);
        Task<ApiResponse> DeleteStoreAsync(int id);
        Task<ApiResponse<IEnumerable<StoreDTO>>> GetAllStoresAsync();
        Task<ApiResponse<IEnumerable<StoreDTO>>> GetStoreByCriteriaAsync(Expression<Func<Store, bool>> predicate);
    }
}