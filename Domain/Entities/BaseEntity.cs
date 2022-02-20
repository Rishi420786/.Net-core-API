using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; } 
        public int CreatedBy { get; set; }
        public int UpdatedBy { get;set;}
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }  
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }

    }
}
