using AutoMapper;
using DomanLayer.Contracts;
using DomanLayer.Models;
using ServiceAbstractionLayer;
using ServiceLayer.Specifications;
using Shared;
using Shared.DTOs;


namespace ServiceLayer
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {

        #region Types and Brands

        public async Task<IEnumerable<TypeDTO>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<TypeDTO>>(types);
        }

        public async Task<IEnumerable<BrandDTO>> GetAllBrandsAsync()
        {
            var repo = _unitOfWork.GetRepository<ProductBrand, int>();
            var brands = await repo.GetAllAsync();
            return _mapper.Map<IEnumerable<BrandDTO>>(brands);

        }
        #endregion


        public async Task<PaginatedResult<ProductDTO>> GetAllProductsAsync(ProductQueryParams queryParams)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();

            var specs = new ProductWithBrandAndTypeSpecifications(queryParams);
            var products = await repo.GetAllAsync(specs);
            var mappedProducts = _mapper.Map<IEnumerable<ProductDTO>>(products);

            var countSpecs = new ProductCountSpecifications(queryParams);
            var totalCount = await repo.CountAsync(countSpecs);

            return new PaginatedResult<ProductDTO>(queryParams.PageIndex, queryParams.PageSize, totalCount, mappedProducts);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var specs = new ProductWithBrandAndTypeSpecifications(id);

            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(specs);
            return _mapper.Map<ProductDTO>(product);
        }
    }
}
