using MyApp.Data;
using MyApp.Entities;
using MyApp.Models;
using BCrypt.Net;
using static BCrypt.Net.BCrypt;

namespace MyApp.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> SignInAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> SignUpAsync(SignUpRequest request)
        {
            var passwordHash = HashPassword(request.Password);

            User userEntity = new User 
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = passwordHash,
                City = request.City,
                State = request.State,
                TermsAgreed = request.TermsAgreed,
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,

            };
            var user = await _dbContext.Users.AddAsync(userEntity);
            await _dbContext.SaveChangesAsync();
                        
            return user.Entity;
        }

     
    }
}
