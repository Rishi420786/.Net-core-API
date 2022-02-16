using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class TblCategoryStoneColor : BaseEntity
    {
        public string CategoryColor { get; set; }
        public bool IsDefault { get; set; }
        [ForeignKey("Category")]
        public int Category_Id { get; set; }
        public virtual TblCategory Category { get; set; }
    }
}
