using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TblStoneCutMaster
    {
        [Key]
        public int Id { get; set; }
        public string StoneCutName { get; set; }
    }
}
