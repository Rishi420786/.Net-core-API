using ServiceLayer.Dto;

namespace ServiceLayer.IServices
{
    public interface ICommonService
    {
        Task<bool> CreateRating(RatingDto ratingDto);
        Task<IList<RatingDto>> GetRating(int? id);
        Task<bool> UpdateRating(RatingDto ratingDto);
        Task<bool> DeleteRating(int? id);
        Task<bool> SaveUserRating(UserRatingDto ratingDto);
        Task<IList<GetUserRatingDto>> GetUserRating(int? id);
    }
}
