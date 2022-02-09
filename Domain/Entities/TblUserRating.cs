using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class TblUserRating : BaseEntity
    {
        [ForeignKey("User")]
        public int ToUserId { get; set; }
        public virtual TblUser User { get; set; }
        [ForeignKey("TblRating")]
        public int RatingId { get; set; }
        public virtual TblRating TblRating { get; set; }
        [ForeignKey("UserTables")]
        public int FromUserId { get; set; }
        public virtual TblUser UserTables { get; set; }
        public string Comments { get; set; }
    }
}
