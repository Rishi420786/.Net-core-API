using AutoMapper;
using Domain.DataContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Dto;
using ServiceLayer.IServices;

namespace ServiceLayer.Services
{
    public class StoneShapeService : IStoneShapeService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public StoneShapeService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddRecord(StoneShapeDto stoneShapeDto)
        {
            try
            {
                TblStoneShapeMaster tblStoneShape = _mapper.Map<TblStoneShapeMaster>(stoneShapeDto);
                tblStoneShape.CreatedDateTime = DateTime.Now;
                await _context.AddAsync(tblStoneShape);
                bool result = Convert.ToBoolean(await _context.SaveChangesAsync());
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IList<StoneShapeDto>> GetAllRecords()
        {
            try
            {
                return _mapper.Map<IList<StoneShapeDto>>(await _context.tblStoneShapeMaster.ToListAsync());
            }
            catch
            {
                throw;
            }
        }
        public async Task<StoneShapeDto> GetRecordById(int? id)
        {
            try
            {
                return _mapper.Map<StoneShapeDto>(await _context.tblStoneShapeMaster.FirstOrDefaultAsync(x => x.Id == id));
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateRecord(StoneShapeDto stoneShapeDto)
        {
            try
            {
                TblStoneShapeMaster tblStoneShapeMaster = _mapper.Map<TblStoneShapeMaster>(stoneShapeDto);
                tblStoneShapeMaster.LastUpdatedDateTime = DateTime.Now;
                _context.Entry(tblStoneShapeMaster).State = EntityState.Modified;
                bool result = Convert.ToBoolean(await _context.SaveChangesAsync());
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteRecord(int? id)
        {
            try
            {
                TblStoneShapeMaster tblStoneShapeMaster = await _context.tblStoneShapeMaster.FindAsync(id);
                if (tblStoneShapeMaster != null)
                {
                    _context.tblStoneShapeMaster.Remove(tblStoneShapeMaster);
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

        public async Task<bool> IsRecordExist(string shapeName)
        {
            try
            {
                return await _context.tblStoneShapeMaster.AnyAsync(x => x.ShapeName.ToLower() == shapeName);
            }
            catch
            {
                throw;
            }
        }
    }
}
