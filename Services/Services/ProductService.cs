using AutoMapper;
using Domain.DataContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Dto;
using ServiceLayer.IServices;

namespace ServiceLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public ProductService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> CreateProduct(ProductDto product)
        {
            try
            {
                TblProduct tblProduct = _mapper.Map<TblProduct>(product);
                await _context.AddAsync(tblProduct);
                bool Result = Convert.ToBoolean(await _context.SaveChangesAsync());
                return Result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IList<ProductListDto>> GetProductList()
        {
            try
            {
                var products = await (from product in _context.tblProduct
                                      join categories in _context.tblCategories on product.CategoryId equals categories.Id
                                      join stonecut in _context.tblStoneCutMaster on categories.StoneCutId equals stonecut.Id
                                      join stoneshape in _context.tblStoneShapeMaster on categories.StoneShapeId equals stoneshape.Id
                                      join gst in _context.tblGstMaster on categories.GstId equals gst.Id
                                      join quality in _context.tblQualityMaster on categories.QualityId equals quality.Id
                                      select new ProductListDto
                                      {
                                          Id = categories.Id,
                                          Comment = categories.Comment,
                                          ImageFileName = product.ImageFileName,
                                          Price = product.Price,
                                          Height = product.Height,
                                          Length = product.Length,
                                          Weight = product.Weight,
                                          IsActive = product.IsActive,
                                          Width = product.Width,
                                          category = new GetCategoryDto()
                                          {
                                              Id = categories.Id,
                                              IsActive = categories.IsActive,
                                              Birefringence = categories.Birefringence,
                                              CategoryName = categories.CategoryName,
                                              Comment = categories.Comment,
                                              Gst = gst.Gst,
                                              ImageFileName = product.ImageFileName,
                                              Magnification = categories.Magnification,
                                              OpticCharacter = categories.OpticCharacter,
                                              Price = categories.Price,
                                              Quality = quality.QualityName,
                                              ReferactiveIndex = categories.ReferactiveIndex,
                                              SpecificGravity = categories.SpecificGravity,
                                              StoneCut = stonecut.StoneCutName,
                                              StoneShape = stoneshape.ShapeName,
                                              UniqueNumber = categories.UniqueNumber
                                          }
                                      }).ToListAsync();
                return products;
            }
            catch
            {
                throw;
            }
        }
        public async Task<ProductListDto> GetProductById(int? id)
        {
            try
            {
                var prdct = await (from product in _context.tblProduct
                                   join categories in _context.tblCategories on product.CategoryId equals categories.Id
                                   join stonecut in _context.tblStoneCutMaster on categories.StoneCutId equals stonecut.Id
                                   join stoneshape in _context.tblStoneShapeMaster on categories.StoneShapeId equals stoneshape.Id
                                   join gst in _context.tblGstMaster on categories.GstId equals gst.Id
                                   join quality in _context.tblQualityMaster on categories.QualityId equals quality.Id
                                   where product.Id == id
                                   select new ProductListDto
                                   {
                                       Id = categories.Id,
                                       Comment = categories.Comment,
                                       ImageFileName = product.ImageFileName,
                                       Price = product.Price,
                                       Height = product.Height,
                                       Length = product.Length,
                                       Weight = product.Weight,
                                       IsActive = product.IsActive,
                                       Width = product.Width,
                                       category = new GetCategoryDto()
                                       {
                                           Id = categories.Id,
                                           IsActive = categories.IsActive,
                                           Birefringence = categories.Birefringence,
                                           CategoryName = categories.CategoryName,
                                           Comment = categories.Comment,
                                           Gst = gst.Gst,
                                           ImageFileName = product.ImageFileName,
                                           Magnification = categories.Magnification,
                                           OpticCharacter = categories.OpticCharacter,
                                           Price = categories.Price,
                                           Quality = quality.QualityName,
                                           ReferactiveIndex = categories.ReferactiveIndex,
                                           SpecificGravity = categories.SpecificGravity,
                                           StoneCut = stonecut.StoneCutName,
                                           StoneShape = stoneshape.ShapeName,
                                           UniqueNumber = categories.UniqueNumber
                                       }
                                   }).FirstOrDefaultAsync();
                return prdct;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateProduct(ProductDto productDto)
        {
            try
            {
                TblProduct tblProduct = _mapper.Map<TblProduct>(productDto);
                _context.Entry(tblProduct).State = EntityState.Modified;
                bool result = Convert.ToBoolean(await _context.SaveChangesAsync());
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteProduct(int? id)
        {
            try
            {
                TblProduct tblProduct = await _context.tblProduct.FindAsync(id);
                if (tblProduct != null)
                {
                    _context.tblProduct.Remove(tblProduct);
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
    }
}
