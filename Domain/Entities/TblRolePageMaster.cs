using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TblRolePageMaster
    {
        [Key]
        public int Id { get; set; } 
        public string PageName { get; set; }
    }
}
