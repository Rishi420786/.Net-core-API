namespace DrishtiGems.API.Model
{
    public class DealerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ShopName { get; set; }
        public string Discount { get; set; }
        public string GstNo { get; set; }
        public string MobileNo { get; set; }
        public DateTime DOB { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImageFileName { get; set; }
        public int SalesmanId { get; set; }
    }
}
