using System.Collections.Generic;
using System.Threading.Tasks;
using RedbullService.Models;
using Microsoft.EntityFrameworkCore;
using RedbullService.Data;

namespace RedbullService.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context; // Veritabanı bağlantısı için DbContext

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.User
                                 .Include(u => u.baskets) // Kullanıcının sepetlerini de dahil et
                                 .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.User
                                 .Include(u => u.baskets)
                                 .FirstOrDefaultAsync(u => u.kullanici_id == id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(int id, User updatedUser)
        {
            var existingUser = await _context.User
                                             .FirstOrDefaultAsync(u => u.kullanici_id == id);

            if (existingUser == null)
            {
                return null; // ID'ye sahip kullanıcı bulunamadı
            }

            // Mevcut kullanıcıyı güncelle
            existingUser.kullanici_adi = updatedUser.kullanici_adi;
            existingUser.email = updatedUser.email;
            existingUser.sifre = updatedUser.sifre;

            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.User
                                     .FirstOrDefaultAsync(u => u.kullanici_id == id);

            if (user == null)
            {
                return false; // ID'ye sahip kullanıcı bulunamadı
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return true; // Kullanıcı başarıyla silindi
        }
    }
}