using ShoesManager.DTOs;
using ShoesManager.Models;

namespace ShoesManager.Mappers
{
    public static class StoreMapper
    {
        public static Store ToEntity(StoreDTO storeDTO) => new()
        {
            Id = storeDTO.Id,
            Name = storeDTO.Name,
            Address = storeDTO.Address
        };

        public static (StoreDTO?, IEnumerable<StoreDTO>?) FromEntity(Store store, IEnumerable<Store>? stores)
        {
            // Si es solo una tienda
            if (store is not null || stores is null)
            {
                var singleStore = new StoreDTO(
                    store!.Id,
                    store.Name!,
                    store.Address!
                );
                return (singleStore, null);
            }

            // Si es una lista de tiendas
            if (stores is not null || store is null)
            {
                var storeList = stores!.Select(s =>
                    new StoreDTO(s.Id, s.Name!, s.Address!)
                ).ToList();

                return (null, storeList);
            }

            // Si ambos valores son null
            return (null, null);
        }
    }
}
