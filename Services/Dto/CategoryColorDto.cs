namespace ServiceLayer.Dto
{
    public class CategoryColorDto
    {
        public int Id { get; set; } 
        public string Color { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
    }
}
