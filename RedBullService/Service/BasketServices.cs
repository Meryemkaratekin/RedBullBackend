using System.Collections.Generic;
using System.Threading.Tasks;
using RedbullService.Models;
using Microsoft.EntityFrameworkCore;
using RedbullService.Data;

namespace RedbullService.Services
{
    public class BasketService : IBasketService
    {
        private readonly DataContext _context;

        public BasketService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Basket>> GetAllBasketsAsync()
        {
            return await _context.Basket
                                 .Include(b => b.Products)
                                 .Include(b => b.User)
                                 .ToListAsync();
        }

        public async Task<Basket> GetBasketByIdAsync(int id)
        {
            return await _context.Basket
                                 .Include(b => b.Products)
                                 .Include(b => b.User)
                                 .FirstOrDefaultAsync(b => b.urunId == id);
        }

        public async Task<Basket> CreateBasketAsync(Basket basket)
        {
            _context.Basket.Add(basket);
            await _context.SaveChangesAsync();
            return basket;
        }

        public async Task<Basket> UpdateBasketAsync(int id, Basket updatedBasket)
        {
            var existingBasket = await _context.Basket
                                               .FirstOrDefaultAsync(b => b.urunId == id);

            if (existingBasket == null)
            {
                return null; // ID'ye sahip sepet bulunamadı
            }

            existingBasket.kullaniciId = updatedBasket.kullaniciId;
            existingBasket.tutar = updatedBasket.tutar;
            existingBasket.Products = updatedBasket.Products;

            await _context.SaveChangesAsync();
            return existingBasket;
        }

        public async Task<bool> DeleteBasketAsync(int id)
        {
            var basket = await _context.Basket
                                       .FirstOrDefaultAsync(b => b.urunId == id);

            if (basket == null)
            {
                return false; // ID'ye sahip sepet bulunamadı
            }

            _context.Basket.Remove(basket);
            await _context.SaveChangesAsync();
            return true; // Başarıyla silindi
        }
    }
}