using Shared.DTOS.BasketDtos;


namespace ServiceAbstractionLayer
{

    public interface IBasketService
    {
        Task<BasketDTO> GetAsync(string id);
        Task<BasketDTO> UpdateAsync(BasketDTO basketDTO);
        Task DeleteAsync(string id);


    }
}

