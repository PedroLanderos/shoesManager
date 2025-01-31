using Microsoft.EntityFrameworkCore;
using ShoesManager.Data;
using ShoesManager.Interfaces;
using ShoesManager.Models;
using ShoesManager.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoesManager.Repositories
{
    public class StoreRepository : IStore
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context)
        {
            _context = context;
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

                // Agregar la tienda a la base de datos
                _context.Stores.Add(store);
                await _context.SaveChangesAsync();

                return new ApiResponse(Success: true);
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
                // Buscar la tienda por ID
                var store = await _context.Stores.FindAsync(id);
                if (store == null)
                {
                    return new ApiResponse<Store>(
                        Success: false,
                        ErrorCode: 404,
                        ErrorMessage: "Store not found",
                        Data: null
                    );
                }

                return new ApiResponse<Store>(
                    Success: true,
                    Data: store
                );
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

                // Actualizar la tienda en la base de datos
                _context.Stores.Update(store);
                await _context.SaveChangesAsync();

                return new ApiResponse(Success: true);
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
                // Buscar la tienda por ID
                var store = await _context.Stores.FindAsync(id);
                if (store == null)
                {
                    return new ApiResponse(Success: false, ErrorCode: 404, ErrorMessage: "Store not found");
                }

                // Eliminar la tienda de la base de datos
                _context.Stores.Remove(store);
                await _context.SaveChangesAsync();

                return new ApiResponse(Success: true);
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
                // Obtener todas las tiendas de la base de datos
                var stores = await _context.Stores.ToListAsync();

                return new ApiResponse<IEnumerable<Store>>(
                    Success: true,
                    Data: stores
                );
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

                // Filtrar las tiendas según el criterio proporcionado
                var stores = await _context.Stores
                    .Where(predicate)
                    .ToListAsync();

                return new ApiResponse<IEnumerable<Store>>(
                    Success: true,
                    Data: stores
                );
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