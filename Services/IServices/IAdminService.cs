using ServiceLayer.Dto;

namespace ServiceLayer.IServices
{
    public interface IAdminService
    {
        Task<bool> CreateRole(RolesDto roles);
        Task<IList<RoleDetailsDto>>GetRoleDetails();
    }
}
