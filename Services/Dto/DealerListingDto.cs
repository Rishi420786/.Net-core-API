namespace ServiceLayer.Dto
{
    public class DealerListingDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string ShopName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string GstNo { get; set; }
        public int SalesmanId { get; set; }
        public bool IsActive { get; set; }
    }
}
