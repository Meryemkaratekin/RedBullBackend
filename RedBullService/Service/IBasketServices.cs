using System.Collections.Generic;
using System.Threading.Tasks;
using RedbullService.Models;

namespace RedbullService.Services
{
    public interface IBasketService
    {
        // Tüm sepetleri listele
        Task<List<Basket>> GetAllBasketsAsync();

        // ID ile sepeti getir
        Task<Basket> GetBasketByIdAsync(int id);

        // Yeni sepet oluştur
        Task<Basket> CreateBasketAsync(Basket basket);

        // Sepeti güncelle
        Task<Basket> UpdateBasketAsync(int id, Basket updatedBasket);

        // Sepeti sil
        Task<bool> DeleteBasketAsync(int id);
    }
}