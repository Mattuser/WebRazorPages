using MyApp.Entities;
using MyApp.Models;

namespace MyApp.Services
{
    public interface IUserService
    {
        public Task<User> SignUpAsync(SignUpRequest signUpRequest);
        public Task<bool> SignInAsync();
    }
}
