using AutoMapper;
using Common.CommonUtility;
using Domain.DataContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Dto;
using ServiceLayer.IServices;

namespace ServiceLayer.Services
{
    public class CommonService : ICommonService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public CommonService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> CreateRating(RatingDto ratingDto)
        {
            try
            {
                TblRating tblRating = _mapper.Map<TblRating>(ratingDto);
                tblRating.CreatedDateTime = DateTime.Now;
                tblRating.IsActive = true;
                await _context.AddAsync(tblRating);
                bool result = Convert.ToBoolean(await _context.SaveChangesAsync());
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IList<RatingDto>> GetRating(int? id)
        {
            try
            {
                IList<RatingDto> ratings = null;
                if (id != null)
                {
                    ratings = _mapper.Map<IList<RatingDto>>(await _context.tblRatings.Where(x => x.Id == id).ToListAsync());
                    return ratings;
                }
                else
                {
                    ratings = _mapper.Map<IList<RatingDto>>(await _context.tblRatings.ToListAsync());
                    return ratings;
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateRating(RatingDto ratingDto)
        {
            try
            {
                TblRating tblRating = _mapper.Map<TblRating>(ratingDto);
                tblRating.LastUpdatedDateTime = DateTime.Now;
                if (tblRating != null)
                {
                    _context.Entry(tblRating).State = EntityState.Modified;
                    bool Result = Convert.ToBoolean(await _context.SaveChangesAsync());
                    return Result;
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
        public async Task<bool> DeleteRating(int? id)
        {
            try
            {
                TblRating tblRating = await _context.tblRatings.FindAsync(id);
                if (tblRating != null)
                {
                    _context.tblRatings.Remove(tblRating);
                    bool Result = Convert.ToBoolean(await _context.SaveChangesAsync());
                    return Result;
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
        public async Task<bool> SaveUserRating(UserRatingDto ratingDto)
        {
            try
            {
                TblUserRating tblUserRating = _mapper.Map<TblUserRating>(ratingDto);
                tblUserRating.IsActive = true;
                tblUserRating.CreatedDateTime = DateTime.Now;
                await _context.AddAsync(tblUserRating);
                bool result = Convert.ToBoolean(await _context.SaveChangesAsync());
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IList<GetUserRatingDto>> GetUserRating(int? id)
        {
            try
            {
                IList<GetUserRatingDto> userRating = null;
                if (id != null)
                {
                    userRating = await (from userRatings in _context.tblUserRatings
                                        join rating in _context.tblRatings on userRatings.RatingId equals rating.Id
                                        join fromUser in _context.tblUsers on userRatings.FromUserId equals fromUser.Id
                                        join toUser in _context.tblUsers on userRatings.ToUserId equals toUser.Id
                                        where userRatings.ToUserId == id
                                        select new GetUserRatingDto
                                        {
                                            Id = userRatings.Id,
                                            Comments = userRatings.Comments,
                                            Rating = rating.Rating,
                                            RatingName = rating.RatingName,
                                            FromUserName = fromUser.FirstName + Constants.Space + fromUser.LastName,
                                            ToUserName = toUser.FirstName + Constants.Space + toUser.LastName
                                        }).ToListAsync();
                    return userRating;
                }
                else
                {
                    userRating = await (from userRatings in _context.tblUserRatings
                                        join rating in _context.tblRatings on userRatings.RatingId equals rating.Id
                                        join fromUser in _context.tblUsers on userRatings.FromUserId equals fromUser.Id
                                        join toUser in _context.tblUsers on userRatings.ToUserId equals toUser.Id
                                        select new GetUserRatingDto
                                        {
                                            Id = userRatings.Id,
                                            Comments = userRatings.Comments,
                                            Rating = rating.Rating,
                                            RatingName = rating.RatingName,
                                            FromUserName = fromUser.FirstName + Constants.Space + fromUser.LastName,
                                            ToUserName = toUser.FirstName + Constants.Space + toUser.LastName
                                        }).ToListAsync();
                    return userRating;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
