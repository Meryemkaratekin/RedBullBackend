using System.Collections.Generic;
using System.Threading.Tasks;
using RedbullService.Models;

namespace RedbullService.Services
{
    public interface IUserService
    {
        // Tüm kullanıcıları getir
        Task<List<User>> GetAllUsersAsync();

        // ID ile kullanıcıyı getir
        Task<User> GetUsers(int id);

        // Yeni kullanıcı oluştur
        Task<User> CreateUserAsync(User user);

        // Kullanıcıyı güncelle
        Task<User> UpdateUserAsync(int id, User updatedUser);

        // Kullanıcıyı sil
        Task<bool> DeleteUserAsync(int id);
    }
}