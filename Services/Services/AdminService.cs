using AutoMapper;
using Domain.DataContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Dto;
using ServiceLayer.IServices;

namespace ServiceLayer.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public AdminService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> CreateRole(RolesDto roles)
        {
            try
            {
                TblRole tblRole = new TblRole()
                {
                    RoleName = roles.RoleName
                };
                await _context.AddAsync(tblRole);
                bool result = Convert.ToBoolean(await _context.SaveChangesAsync());
                int roleId = await _context.tblRoles.MaxAsync(x => x.Id);

                foreach(var rolePageIds in roles.RolePageId)
                {
                    TblRolePermissions rolePermissions = new TblRolePermissions()
                    {
                        RoleId = roleId,
                        RolePageId = rolePageIds
                    };
                    await _context.AddAsync(rolePermissions);
                    result = Convert.ToBoolean(await _context.SaveChangesAsync());
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IList<RoleDetailsDto>> GetRoleDetails()
        {
            try
            {
                IList<RoleDetailsDto> roleDetails = new List<RoleDetailsDto>();
                roleDetails = await (from roles in _context.tblRoles
                                     select new RoleDetailsDto
                                     {
                                         Id = roles.Id,
                                         RoleName = roles.RoleName,
                                         Permissions = (from permission in _context.tblRolePermissions
                                                        join pages in _context.tblRolePageMaster on permission.RolePageId equals pages.Id
                                                        where permission.RoleId == roles.Id
                                                        select new RolePermissionsDto
                                                        {
                                                            Id = permission.Id,
                                                            RolePermission = pages.PageName
                                                        }).ToList()
                                     }).ToListAsync();
                return roleDetails;
            }
            catch { throw; }
        }
    }
}
