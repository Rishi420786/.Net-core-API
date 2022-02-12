using AutoMapper;
using Domain.Entities;
using ServiceLayer.Dto;

namespace DrishtiGems.API.Model
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<TblUser, UserDto>().ReverseMap();

            CreateMap<RatingDto, TblRating>().ReverseMap();
            CreateMap<UserRatingDto, TblUserRating>().ReverseMap();

            CreateMap<CategoryDto, TblCategory>().ReverseMap();
            CreateMap<AddCategoryColorDto, TblCategoryStoneColor>().ReverseMap();

            CreateMap<StoneShapeDto,TblStoneShapeMaster>().ReverseMap();
        }
    }
}
