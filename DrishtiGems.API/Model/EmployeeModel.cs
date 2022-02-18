namespace DrishtiGems.API.Model
{
    public class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public DateTime DOB { get; set; }
        public string PAN { get; set; }
        public string Aadhaar { get; set; }
        public string UniqueId { get; set; }
        public string Destination { get; set; }
        public string Designation { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImageFileName { get; set; }
    }
}
