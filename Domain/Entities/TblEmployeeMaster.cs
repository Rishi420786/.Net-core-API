using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class TblEmployeeMaster : BaseEntity
    {
        [ForeignKey("TblUser")]
        public int UserId { get; set; }
        public virtual TblUser TblUser { get; set; }
        public string MobileNo { get; set; }
        public DateTime DOB { get; set; }
        public string PAN { get; set; }
        public string Aadhaar { get; set; }
        public string UniqueId { get; set; }
        public string Destination { get; set; }
        public string Designation { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string ImageFileName { get; set; }
    }
}
