using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TblStoneColorMaster
    {
        [Key]
        public int Id { get; set; }
        public string ColorName { get; set; }
    }
}
