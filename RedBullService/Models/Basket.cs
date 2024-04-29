using RedBullService.Models;
using System.ComponentModel.DataAnnotations;

namespace RedbullService.Models
{
    public class Basket
    {
        [Key]
        public int urunId { get; set; }
        public int kullaniciId { get; set; }
        public virtual ICollection<Products> Products { get; set; }
        public virtual Products Product { get; set; }
        public ICollection<Basket> baskets{ get; set; }
        public ICollection<User> users { get; set; }
        public virtual User User { get; set; }
        public int tutar { get; set; }
        }}
    

