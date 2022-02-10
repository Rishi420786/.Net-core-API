using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TblRole
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
