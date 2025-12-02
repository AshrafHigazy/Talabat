using Shared.DTOs;

namespace ServiceAbstractionLayer
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();

        Task<ProductDTO> GetProductByIdAsync(int id);

        Task<IEnumerable<TypeDTO>> GetAllTypesAsync();

        Task<IEnumerable<BrandDTO>> GetAllBrandsAsync();
    }
}
