using System.ComponentModel.DataAnnotations;

namespace Restaurant_Favs_BackEnd.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public string description { get; set; }
        public string restaurant { get; set; }
        public int rating { get; set; }
        public bool orderAgain { get; set; }
    }
}
