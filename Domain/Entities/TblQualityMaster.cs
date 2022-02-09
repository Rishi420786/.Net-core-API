using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TblQualityMaster
    {
        [Key]
        public int Id { get; set; } 
        public string QualityName { get; set; }
    }
}
