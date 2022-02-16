using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class TblDealers : BaseEntity
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual TblUser User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShopName { get; set; }
        public string Discount { get; set; }
        public string GstNo { get; set; }
        public string MobileNo { get; set; }
        public DateTime DOB { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string ImageFileName { get; set; }
        [ForeignKey("TblEmployeeMaster")]
        public int SalesmanId { get; set; }
        public virtual TblEmployeeMaster TblEmployeeMaster { get; set; }
    }
}
