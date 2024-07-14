using ItAcademy.Application.Infrastructure.Errors.CustomExceptions;
using ItAcademy.Application.Infrastructure.Localization.Errors;
using ItAcademy.Application.Orders.Repositories;
using ItAcademy.Application.Orders.Requests;
using ItAcademy.Domain.EventsAggregate;
using ItAcademy.Domain.OrderAggregate;
using ItAcademy.Domain.UserAggregate;
using ItAcademy.Infrastructure.BaseRepo;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.Infrastructure.Orders
{
    public class OrderRepository : IOrderRepository
    {
        #region Ctor
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly IBaseRepository<Event> _eventRepository;
        private readonly IBaseRepository<User> _userRepository;

        public OrderRepository(IBaseRepository<Order> orderRepository, IBaseRepository<Event> eventRepository, IBaseRepository<User> userRepository)
        {
            _orderRepository = orderRepository;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }
        #endregion
        public async Task<IEnumerable<Order>> GetAllOrders(CancellationToken token, string userName)
        {
            return await _orderRepository.GetCollectionAsync(token, i => i.User.UserName == userName).ConfigureAwait(false);
        }
        public async Task<IEnumerable<Order>> GetAllOrdersForAdmin(CancellationToken token)
        {
            return await _orderRepository.GetQuery().Include(i => i.User).Include(i => i.Event).ToListAsync().ConfigureAwait(false);
        }
        public async Task<bool> AddOrder(CancellationToken token, OrderRequest order, int eventId)
        {
            var current = await _eventRepository.GetQuery(i => i.Id == eventId).SingleOrDefaultAsync().ConfigureAwait(false);
            var user = await _userRepository.GetQuery(i => i.UserName == order.UserName).SingleOrDefaultAsync().ConfigureAwait(false);
            if (current == null || user == null)
                throw new DoesntExistsException(ErrorMessages.NotFound);
            if (current.Quantity > 0)
            {
                var newOrder = new Order()
                {
                    UserId = user.Id,
                    Quantity = order.Quantity,
                    Total = order.Quantity * current.Price,
                    EventId = eventId
                    
                };
                current.Quantity -= order.Quantity;
                await _orderRepository.Create(token, newOrder).ConfigureAwait(false);
                current.Quantity -= order.Quantity;
                _eventRepository.Update(current);
            }
            return await _orderRepository.SaveChangesAsync(token).ConfigureAwait(false);
        }
        
    }
}
