using AutoMapper;
using Northwind.API.Models;
using Northwind.Core.DTOs;
using Northwind.Core.Interfaces;

namespace Northwind.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrdersPlacedMayDTO>> GetAllOrderPlacedInMay()
        {
            var orders = await _orderRepository.GetAllAsync();

            var order = from o in orders
                        //where o.OrderDate == DateTime.Parse("21/May/1996")
                        select new Order
                        {
                            OrderDate = o.OrderDate,
                            ShippedDate = o.ShippedDate,
                            CustomerId = o.CustomerId,  
                            Freight = o.Freight,
                        };
            var mapped = _mapper.Map<IEnumerable<OrdersPlacedMayDTO>>(order);

            return mapped;
        }

        public async Task<IEnumerable<OrdersDTO>> GetTopTenOdersSortByFrieght()
        {
            var orders = await _orderRepository.GetAllAsync();

            var sortrders = (from order in orders
                            orderby order.Freight descending
                            select order).Take(10);

            var mapped = _mapper.Map<IEnumerable<OrdersDTO>>(sortrders);

            return mapped;
        }
    }
}
