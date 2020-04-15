using System.ComponentModel.DataAnnotations;

namespace Delopgaveprojekt.Models
{
    public partial class Stock
    {
        public Stock()
        {
            
        }

        [Key]
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
    }
}
