namespace ServiceLayer.Dto
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string Comment { get; set; }
        public string ImageFileName { get; set; }
        public bool IsActive { get; set; }
        public GetCategoryDto category { get; set; }
    }
}
