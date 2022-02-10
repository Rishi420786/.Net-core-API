using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TblGstMaster
    {
        [Key]
        public int Id { get; set; }
        public double Gst { get; set; }
    }
}
