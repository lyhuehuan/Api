using WebApi.Dtos.UserDtos;
using WebApi.Models;

namespace WebApi.Services.IServices
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task Register(RegisterRequest model);
        Task Update(int id, UpdateRequest model);
        Task Delete(int id);
    }
}
