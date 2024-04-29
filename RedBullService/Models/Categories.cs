using RedBullService.Models;
using System.ComponentModel.DataAnnotations;

namespace RedbullService.Models
{
    public class Categories
    {
        [Key]
        public int urunId { get; set; }
        public int kategoriId { get; set; }

        public virtual Products Product { get; set; }
    }
}
