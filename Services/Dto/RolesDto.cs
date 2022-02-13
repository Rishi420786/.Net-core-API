namespace ServiceLayer.Dto
{
    public class RolesDto
    {
        public string RoleName { get; set; }
        public List<int> RolePageId { get; set; }
    }
    public class RoleDetailsDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public IList<RolePermissionsDto> Permissions { get; set; }
    }
    public class RolePermissionsDto
    {
        public int Id { get; set; }
        public string RolePermission { get; set; }
    }
    public class RolePages
    {
        public int Id { get; set; }
        public string PageName { get; set; }
    }
}
