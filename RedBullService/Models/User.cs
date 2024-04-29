using System.ComponentModel.DataAnnotations;

namespace RedbullService.Models
{
    public class User
    {
        [Key]
        public int kullanici_id { get; set; }
        public String kullanici_adi { get; set; }
        public String email;
        public String sifre;
        public ICollection<Basket> baskets { get; set; }    }
}
