namespace ServiceLayer.Dto
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string UniqueNumber { get; set; }
        public double Price { get; set; }
        public string StoneCut { get; set; }
        public string StoneShape { get; set; }
        public string StoneColor { get; set; }
        public double Gst { get; set; }
        public string Quality { get; set; }
        public string Magnification { get; set; }
        public string OpticCharacter { get; set; }
        public string ReferactiveIndex { get; set; }
        public double Birefringence { get; set; }
        public double SpecificGravity { get; set; }
        public string Comment { get; set; }
        public string ImageFileName { get; set; }
    }
}
