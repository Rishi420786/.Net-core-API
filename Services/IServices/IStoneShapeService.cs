using ServiceLayer.Dto;

namespace ServiceLayer.IServices
{
    public interface IStoneShapeService
    {
        Task<bool> AddRecord(StoneShapeDto stoneShapeDto);
        Task<IList<StoneShapeDto>> GetAllRecords();
        Task<StoneShapeDto> GetRecordById(int? id);
        Task<bool> UpdateRecord(StoneShapeDto stoneShapeDto);
        Task<bool> DeleteRecord(int? id);
        Task<bool> IsRecordExist(string shapeName);
    }
}
