using Microsoft.EntityFrameworkCore;
using OnboardCustomer.Data;
using OnboardCustomer.Models.Domain;

namespace OnboardCustomer.Repositories
{
    public class OnboardCustomerRepository : IOnboardCustomerRepository
    {
        private readonly OnboardCustomerDbContext _dbContext;

        public OnboardCustomerRepository(OnboardCustomerDbContext onboardCustomerDbContext)
        { 
            _dbContext = onboardCustomerDbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
