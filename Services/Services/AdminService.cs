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
                TblRole tblRole = new()
                {
                    RoleName = roles.RoleName
                };
                await _context.AddAsync(tblRole);
                bool result = Convert.ToBoolean(await _context.SaveChangesAsync());
                int roleId = await _context.tblRoles.MaxAsync(x => x.Id);

                foreach (var rolePageIds in roles.RolePageId)
                {
                    TblRolePermissions rolePermissions = new()
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
        public async Task<bool> CreateCategory(CategoryDto category)
        {
            try
            {
                TblCategory tblCategory = _mapper.Map<TblCategory>(category);
                await _context.AddAsync(tblCategory);
                bool result = Convert.ToBoolean(_context.SaveChangesAsync());
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IList<GetCategoryDto>> GetAllCategories()
        {
            try
            {
                var allcategories = await (from categories in _context.tblCategories
                                           join stonecut in _context.tblStoneCutMaster on categories.StoneCutId equals stonecut.Id
                                           join stoneshape in _context.tblStoneShapeMaster on categories.StoneShapeId equals stoneshape.Id
                                           join stonecolor in _context.tblCategoryStoneColors on categories.StoneColorId equals stonecolor.Id
                                           join gst in _context.tblGstMaster on categories.GstId equals gst.Id
                                           join quality in _context.tblQualityMaster on categories.QualityId equals quality.Id
                                           select new GetCategoryDto
                                           {
                                               Id = categories.Id,
                                               CategoryName = categories.CategoryName,
                                               Birefringence = categories.Birefringence,
                                               Comment = categories.Comment,
                                               Gst = gst.Gst,
                                               ImageFileName = categories.ImageFileName,
                                               Magnification = categories.Magnification,
                                               OpticCharacter = categories.OpticCharacter,
                                               Price = categories.Price,
                                               Quality = quality.QualityName,
                                               ReferactiveIndex = categories.ReferactiveIndex,
                                               SpecificGravity = categories.SpecificGravity,
                                               StoneColor = stonecolor.CategoryColor,
                                               StoneCut = stonecut.StoneCutName,
                                               StoneShape = stoneshape.ShapeName,
                                               UniqueNumber = categories.UniqueNumber
                                           }).ToListAsync();
                return allcategories;
            }
            catch
            {
                throw;
            }
        }
        public async Task<GetCategoryDto> GetCategoryById(int id)
        {
            try
            {
                var category = await (from categories in _context.tblCategories
                                      join stonecut in _context.tblStoneCutMaster on categories.StoneCutId equals stonecut.Id
                                      join stoneshape in _context.tblStoneShapeMaster on categories.StoneShapeId equals stoneshape.Id
                                      join stonecolor in _context.tblCategoryStoneColors on categories.StoneColorId equals stonecolor.Id
                                      join gst in _context.tblGstMaster on categories.GstId equals gst.Id
                                      join quality in _context.tblQualityMaster on categories.QualityId equals quality.Id
                                      where categories.Id == id
                                      select new GetCategoryDto
                                      {
                                          Id = categories.Id,
                                          CategoryName = categories.CategoryName,
                                          Birefringence = categories.Birefringence,
                                          Comment = categories.Comment,
                                          Gst = gst.Gst,
                                          ImageFileName = categories.ImageFileName,
                                          Magnification = categories.Magnification,
                                          OpticCharacter = categories.OpticCharacter,
                                          Price = categories.Price,
                                          Quality = quality.QualityName,
                                          ReferactiveIndex = categories.ReferactiveIndex,
                                          SpecificGravity = categories.SpecificGravity,
                                          StoneColor = stonecolor.CategoryColor,
                                          StoneCut = stonecut.StoneCutName,
                                          StoneShape = stoneshape.ShapeName,
                                          UniqueNumber = categories.UniqueNumber
                                      }).FirstOrDefaultAsync();
                return category;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateCategory(CategoryDto category)
        {
            try
            {
                TblCategory tblCategory = _mapper.Map<TblCategory>(category);
                if (tblCategory != null)
                {
                    _context.Entry(tblCategory).State = EntityState.Modified;
                    bool result = Convert.ToBoolean(await _context.SaveChangesAsync());
                    return result;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                TblCategory tblCategory = await _context.tblCategories.FindAsync(id);
                if (tblCategory != null)
                {
                    _context.tblCategories.Remove(tblCategory);
                    bool result = Convert.ToBoolean(await _context.SaveChangesAsync());
                    return result;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<IList<CategoryColorDto>> GetCategoryColors(int? id)
        {
            try
            {
                var CategoryColors = await (from category in _context.tblCategories
                                            join color in _context.tblCategoryStoneColors on category.StoneColorId equals color.Id
                                            select new CategoryColorDto
                                            {
                                                Id = color.Id,
                                                Color = color.CategoryColor,
                                                IsDefault = color.IsDefault,
                                                IsActive = color.IsActive
                                            }).ToListAsync();
                return CategoryColors;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> CreateCategoryColor(AddCategoryColorDto addCategoryColor)
        {
            try
            {
                TblCategoryStoneColor tblCategoryStoneColor = _mapper.Map<TblCategoryStoneColor>(addCategoryColor);
                await _context.AddAsync(tblCategoryStoneColor);
                bool result = Convert.ToBoolean(_context.SaveChangesAsync());
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteCategoryColor(int id)
        {
            try
            {
                TblCategoryStoneColor tblCategoryStoneColor = await _context.tblCategoryStoneColors.FindAsync(id);
                if (tblCategoryStoneColor != null)
                {
                    _context.tblCategoryStoneColors.Remove(tblCategoryStoneColor);
                    bool result = Convert.ToBoolean(await _context.SaveChangesAsync());
                    return result;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> IsRoleExist(string roleName)
        {
            try
            {
                bool isRoleExist = await _context.tblRoles.AnyAsync(x => x.RoleName.ToLower() == roleName);
                return isRoleExist;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> IsCategoryExist(string categoryName)
        {
            try
            {
                bool isCategoryExist = await _context.tblCategories.AnyAsync(x => x.CategoryName.ToLower() == categoryName);
                return isCategoryExist;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> IsColorExist(string colorName)
        {
            try
            {
                bool isColorExist = await _context.tblCategoryStoneColors.AnyAsync(x => x.CategoryColor.ToLower() == colorName);
                return isColorExist;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IList<RolePages>> GetAllPermissions()
        {
            try
            {
                return _mapper.Map<IList<RolePages>>(await _context.tblRolePageMaster.ToListAsync());
            }
            catch
            {
                throw;
            }
        }
    }
}
