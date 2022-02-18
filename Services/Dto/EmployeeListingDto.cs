namespace ServiceLayer.Dto
{
    public class EmployeeListingDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string MobileNo { get; set; }
        public string PAN { get; set; }
        public string Aadhaar { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}
