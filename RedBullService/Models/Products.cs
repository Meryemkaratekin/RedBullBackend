using RedbullService.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedBullService.Models
{
    public class Products
    {
        [Key]
        public int urunId { get; set; } // urun_ıd yerine urunId olarak isimlendirme düzeltildi
        public string urunAdi { get; set; } // urun_adi yerine urunAdi olarak isimlendirme düzeltildi
        public string aciklama { get; set; }
        public string resimUrl { get; set; } // resim_url yerine resimUrl olarak isimlendirme düzeltildi
        public virtual ICollection<Categories> Categories { get; set; } 
        
        public virtual ICollection<Basket> Baskets { get; set; }
    }
}