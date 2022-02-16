using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class TblCategory : BaseEntity
    {
        public string CategoryName { get; set; }
        public string UniqueNumber { get; set; }
        public double Price { get; set; }
        [ForeignKey("StoneCutMaster")]
        public int StoneCutId { get; set; }
        public virtual TblStoneCutMaster StoneCutMaster { get; set; }
        [ForeignKey("StoneShapeMaster")]
        public int StoneShapeId { get; set; }
        public virtual TblStoneShapeMaster StoneShapeMaster { get; set; }
        [ForeignKey("GstMaster")]
        public int GstId { get; set; }
        public virtual TblGstMaster GstMaster { get; set; }
        [ForeignKey("QualityMaster")]
        public int QualityId { get; set; }
        public virtual TblQualityMaster QualityMaster { get; set; }
        public string Magnification { get; set; }
        public string OpticCharacter { get; set; }
        public string ReferactiveIndex { get; set; }
        public double Birefringence { get; set; }
        public double SpecificGravity { get; set; } 
        public string Comment { get; set; }
        public string ImageFileName { get; set; } 
    }
}
