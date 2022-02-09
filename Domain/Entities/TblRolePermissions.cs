using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class TblRolePermissions
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("TblRole")]
        public int RoleId { get; set; }
        public virtual TblRole TblRole { get; set; }
        [ForeignKey("RolePageMaster")]
        public int RolePageId { get; set; }
        public virtual TblRolePageMaster RolePageMaster { get; set; }
    }
}
