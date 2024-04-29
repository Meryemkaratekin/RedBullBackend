using System.ComponentModel.DataAnnotations;

namespace RedbullService.Models
{
    public class Atleths
    {
        [Key]
        public int atlet_id { get; set; }
        public int kategori_id { get; set; }
        public String adi { get; set; }
        public String resim_url { get; set; }

    }
}
