

using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models.Orders;
using DomainLayer.Models.Products;
using ServiceAbstractionLayer;
using Shared.DTOS.Authentication;
using Shared.DTOS.OrderDtos;

namespace ServiceLayer
{
    public class OrderServices(IMapper mapper ,IBasketRepository basketRepository, IUnitOfWork unitOfWork) : IOrderServices
    {
        public async Task<OrderToRuternDto> CreateOrderAsync(OrderDto orderDto, string Email)
        {
            var OrderAddress = mapper.Map<AddressDTO, OrderAddress>(orderDto.Address);
            var Basket = await basketRepository.GetBasketAsync(orderDto.BasketId) ?? throw new BasketNotFoundException();

            List<OrderItem> orderItems = [];

            var ProductRepo = unitOfWork.GetRepository<Product, int>();
            
            foreach(var Item in Basket.Items)
            {
                var Product = await ProductRepo.GetByIdAsync(Item.Id) ?? throw new ProductNotFound(Item.Id);

                var OrdeerItem = new OrderItem()
                {
                    Prouduct = new ProuductItemOrder()
                    {
                        ProductItemId = Product.Id,
                        ProductName = Product.Name,
                        PictureUrl = Product.PictureUrl,
                    },
                    Quantity = Item.Quantity,
                    Price= Product.Price ,
                };
                orderItems.Add(OrderItem);
            }

            var DeliveryMethodRepo =await unitOfWork.GetRepository<DeliveryMethod, int>().GetByIdAsync(orderDto.DeliveryMethodId)
                ??throw new DeliveryMethodNotFoundException(orderDto.DeliveryMethodId);

            var Subtotal = orderItems.Sum(I => I.Price * I.Quantity);

            var Order = new Order(Email , OrderAddress, DeliveryMethodRepo, orderItems, Subtotal);

            unitOfWork.GetRepository<Order,Guid>().Add(Order);

            await unitOfWork.SaveChangesAsync();
            return mapper.Map<Order, OrderToRuternDto>(Order);
        }   
        
    }
}
