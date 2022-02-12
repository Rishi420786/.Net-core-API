using ServiceLayer.Dto;

namespace ServiceLayer.IServices
{
    public interface IStoneShapeService
    {
        Task<bool> CreateStoneShape(StoneShapeDto stoneShapeDto);
        Task<IList<StoneShapeDto>> GetAllStoneShapes();
        Task<StoneShapeDto> GetStoneShapeById(int? id);
        Task<bool> UpdateStoneShape(StoneShapeDto stoneShapeDto);
        Task<bool> DeleteStoneShape(int? id);
        Task<bool> IsStoneShapeExist(string shapeName);
    }
}
