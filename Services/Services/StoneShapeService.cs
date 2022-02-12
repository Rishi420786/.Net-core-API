using AutoMapper;
using Domain.DataContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Dto;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<bool> CreateStoneShape(StoneShapeDto stoneShapeDto)
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
        public async Task<IList<StoneShapeDto>> GetAllStoneShapes()
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
        public async Task<StoneShapeDto> GetStoneShapeById(int? id)
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
        public async Task<bool> UpdateStoneShape(StoneShapeDto stoneShapeDto)
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

        public async Task<bool> DeleteStoneShape(int? id)
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

        public async Task<bool> IsStoneShapeExist(string shapeName)
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
