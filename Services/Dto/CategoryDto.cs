using Microsoft.AspNetCore.Http;

namespace ServiceLayer.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string UniqueNumber { get; set; }
        public double Price { get; set; }
        public int StoneCutId { get; set; }
        public int StoneShapeId { get; set; }
        public int StoneColorId { get; set; }
        public int GstId { get; set; }
        public int QualityId { get; set; }
        public string Magnification { get; set; }
        public string OpticCharacter { get; set; }
        public string ReferactiveIndex { get; set; }
        public double Birefringence { get; set; }
        public double SpecificGravity { get; set; }
        public string Comment { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImageFileName { get; set; }
        public bool IsActive { get; set; }
    }
}
