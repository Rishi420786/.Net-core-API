using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class TblUser : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [ForeignKey("TblRole")]
        public int RoleId { get; set; }
        public virtual TblRole TblRole { get; set; }
    }
}
