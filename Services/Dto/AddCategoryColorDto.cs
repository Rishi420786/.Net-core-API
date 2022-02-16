namespace ServiceLayer.Dto
{
    public class AddCategoryColorDto
    {
        public string CategoryColor { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}
