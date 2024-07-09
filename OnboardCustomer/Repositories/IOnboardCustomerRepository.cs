using OnboardCustomer.Models.Domain;

namespace OnboardCustomer.Repositories
{
    public interface IOnboardCustomerRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<User> CreateAsync(User user);
    }
}
