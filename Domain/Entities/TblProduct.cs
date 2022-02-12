using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class TblProduct : BaseEntity
    {
        [ForeignKey("TblCategory")]
        public int CategoryId { get; set; }
        public virtual TblCategory TblCategory { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string Comment { get; set; }
        public string ImageFileName { get; set; }
    }
}
