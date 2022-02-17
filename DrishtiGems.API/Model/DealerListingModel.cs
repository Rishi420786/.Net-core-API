namespace DrishtiGems.API.Model
{
    public class DealerListingModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string ShopName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string GstNo { get; set; }
        public bool IsActive { get; set; }
    }
}
