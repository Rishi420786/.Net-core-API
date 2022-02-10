using ServiceLayer.Dto;

namespace ServiceLayer.IServices
{
    public interface IAdminService
    {
        Task<bool> CreateRole(RolesDto roles);
        Task<IList<RoleDetailsDto>>GetRoleDetails();
        Task<bool> CreateCategory(CategoryDto category);
        Task<IList<GetCategoryDto>>GetAllCategories();
        Task<GetCategoryDto> GetCategoryById(int id);
        Task<bool>UpdateCategory(CategoryDto category);
        Task<bool>DeleteCategory(int id);
        Task<IList<CategoryColorDto>>GetCategoryColors(int? id);
        Task<bool> CreateCategoryColor(AddCategoryColorDto addCategoryColor);
        Task<bool> DeleteCategoryColor(int id);
        Task<bool> IsRoleExist(string roleName);
        Task<bool>IsCategoryExist(string categoryName);
        Task<bool> IsColorExist(string colorName);
    }
}
