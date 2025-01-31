using Microsoft.EntityFrameworkCore.Migrations;
using ShoesManager.Interfaces;
using ShoesManager.Models;
using ShoesManager.Responses;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoesManager.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStore _storeRepository;

        public StoreService(IStore storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<ApiResponse> CreateStoreAsync(Store store)
        {
            try
            {
                // Validar que la tienda no sea nula
                if (store == null)
                {
                    return new ApiResponse(Success: false, ErrorCode: 400, ErrorMessage: "Store cannot be null");
                }

                // Llamar al repositorio para crear la tienda
                var result = await _storeRepository.CreateStoreAsync(store);

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse(Success: false, ErrorCode: 500, ErrorMessage: ex.Message);
            }
        }

        public async Task<ApiResponse<Store>> GetStoreByIdAsync(int id)
        {
            try
            {
                // Validar que el ID sea válido
                if (id <= 0)
                {
                    return new ApiResponse<Store>(
                        Success: false,
                        ErrorCode: 400,
                        ErrorMessage: "Invalid store ID",
                        Data: null
                    );
                }

                // Llamar al repositorio para obtener la tienda por ID
                var result = await _storeRepository.GetStoreByIdAsync(id);

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse<Store>(
                    Success: false,
                    ErrorCode: 500,
                    ErrorMessage: ex.Message,
                    Data: null
                );
            }
        }

        public async Task<ApiResponse> UpdateStoreAsync(Store store)
        {
            try
            {
                // Validar que la tienda no sea nula
                if (store == null)
                {
                    return new ApiResponse(Success: false, ErrorCode: 400, ErrorMessage: "Store cannot be null");
                }

                // Llamar al repositorio para actualizar la tienda
                var result = await _storeRepository.UpdateStoreAsync(store);

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse(Success: false, ErrorCode: 500, ErrorMessage: ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteStoreAsync(int id)
        {
            try
            {
                // Validar que el ID sea válido
                if (id <= 0)
                {
                    return new ApiResponse(Success: false, ErrorCode: 400, ErrorMessage: "Invalid store ID");
                }

                // Llamar al repositorio para eliminar la tienda
                var result = await _storeRepository.DeleteStoreAsync(id);

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse(Success: false, ErrorCode: 500, ErrorMessage: ex.Message);
            }
        }

        public async Task<ApiResponse<IEnumerable<Store>>> GetAllStoresAsync()
        {
            try
            {
                // Llamar al repositorio para obtener todas las tiendas
                var result = await _storeRepository.GetAllStoresAsync();

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Store>>(
                    Success: false,
                    ErrorCode: 500,
                    ErrorMessage: ex.Message,
                    Data: null
                );
            }
        }

        public async Task<ApiResponse<IEnumerable<Store>>> GetStoreByCriteriaAsync(Expression<Func<Store, bool>> predicate)
        {
            try
            {
                // Validar que el predicado no sea nulo
                if (predicate == null)
                {
                    return new ApiResponse<IEnumerable<Store>>(
                        Success: false,
                        ErrorCode: 400,
                        ErrorMessage: "Predicate cannot be null",
                        Data: null
                    );
                }

                // Llamar al repositorio para obtener las tiendas que cumplan con el criterio
                var result = await _storeRepository.GetStoreByCriteriaAsync(predicate);

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Store>>(
                    Success: false,
                    ErrorCode: 500,
                    ErrorMessage: ex.Message,
                    Data: null
                );
            }
        }
    }
}