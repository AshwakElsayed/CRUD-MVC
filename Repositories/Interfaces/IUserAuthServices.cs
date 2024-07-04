using MovieStore_MVC.Models.DTO;

namespace MovieStore_MVC.Repositories.Interfaces
{
    public interface IUserAuthServices
    {
        Task<Status> LoginAsync(Login model);
        Task LogoutAsync();
        Task<Status> RegisterAsync(Registration model);
        //Task<Status> ChangePasswordAsync(ChangePassword model, string username);
    }
}
