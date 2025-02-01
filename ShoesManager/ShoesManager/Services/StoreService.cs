using ShoesManager.DTOs;
using ShoesManager.Interfaces;
using ShoesManager.Mappers;
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

        public async Task<ApiResponse> CreateStoreAsync(StoreDTO storeDTO)
        {
            try
            {
                // Validar que el DTO no sea nulo
                if (storeDTO == null)
                {
                    return new ApiResponse(Success: false, ErrorCode: 400, ErrorMessage: "StoreDTO cannot be null");
                }

                // Convertir el DTO a entidad
                var store = StoreMapper.ToEntity(storeDTO);

                // Llamar al repositorio para crear la tienda
                var result = await _storeRepository.CreateStoreAsync(store);

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse(Success: false, ErrorCode: 500, ErrorMessage: ex.Message);
            }
        }

        public async Task<ApiResponse<StoreDTO>> GetStoreByIdAsync(int id)
        {
            try
            {
                // Validar que el ID sea válido
                if (id <= 0)
                {
                    return new ApiResponse<StoreDTO>(
                        Success: false,
                        ErrorCode: 400,
                        ErrorMessage: "Invalid store ID",
                        Data: null
                    );
                }

                // Llamar al repositorio para obtener la tienda por ID
                var result = await _storeRepository.GetStoreByIdAsync(id);
                if (!result.Success || result.Data == null)
                {
                    return new ApiResponse<StoreDTO>(
                        Success: false,
                        ErrorCode: 404,
                        ErrorMessage: "Store not found",
                        Data: null
                    );
                }

                // Convertir la entidad a DTO
                var storeDTO = StoreMapper.FromEntity(result.Data, null).Item1;

                return new ApiResponse<StoreDTO>(
                    Success: true,
                    Data: storeDTO
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<StoreDTO>(
                    Success: false,
                    ErrorCode: 500,
                    ErrorMessage: ex.Message,
                    Data: null
                );
            }
        }

        public async Task<ApiResponse> UpdateStoreAsync(StoreDTO storeDTO)
        {
            try
            {
                // Validar que el DTO no sea nulo
                if (storeDTO == null)
                {
                    return new ApiResponse(Success: false, ErrorCode: 400, ErrorMessage: "StoreDTO cannot be null");
                }

                // Convertir el DTO a entidad
                var store = StoreMapper.ToEntity(storeDTO);

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

        public async Task<ApiResponse<IEnumerable<StoreDTO>>> GetAllStoresAsync()
        {
            try
            {
                // Llamar al repositorio para obtener todas las tiendas
                var result = await _storeRepository.GetAllStoresAsync();
                if (!result.Success || result.Data == null)
                {
                    return new ApiResponse<IEnumerable<StoreDTO>>(
                        Success: false,
                        ErrorCode: 500,
                        ErrorMessage: "Failed to retrieve stores",
                        Data: null
                    );
                }

                // Convertir las entidades a DTOs
                var storeDTOs = StoreMapper.FromEntity(null!, result.Data).Item2;

                return new ApiResponse<IEnumerable<StoreDTO>>(
                    Success: true,
                    Data: storeDTOs
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<StoreDTO>>(
                    Success: false,
                    ErrorCode: 500,
                    ErrorMessage: ex.Message,
                    Data: null
                );
            }
        }

        public async Task<ApiResponse<IEnumerable<StoreDTO>>> GetStoreByCriteriaAsync(Expression<Func<Store, bool>> predicate)
        {
            try
            {
                // Validar que el predicado no sea nulo
                if (predicate == null)
                {
                    return new ApiResponse<IEnumerable<StoreDTO>>(
                        Success: false,
                        ErrorCode: 400,
                        ErrorMessage: "Predicate cannot be null",
                        Data: null
                    );
                }

                // Llamar al repositorio para obtener las tiendas que cumplan con el criterio
                var result = await _storeRepository.GetStoreByCriteriaAsync(predicate);
                if (!result.Success || result.Data == null)
                {
                    return new ApiResponse<IEnumerable<StoreDTO>>(
                        Success: false,
                        ErrorCode: 500,
                        ErrorMessage: "Failed to retrieve stores",
                        Data: null
                    );
                }

                // Convertir las entidades a DTOs
                var storeDTOs = StoreMapper.FromEntity(null!, result.Data).Item2;

                return new ApiResponse<IEnumerable<StoreDTO>>(
                    Success: true,
                    Data: storeDTOs
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<StoreDTO>>(
                    Success: false,
                    ErrorCode: 500,
                    ErrorMessage: ex.Message,
                    Data: null
                );
            }
        }
    }
}