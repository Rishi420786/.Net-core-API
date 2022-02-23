using AutoMapper;
using Common.CommonUtility;
using Domain.DataContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepositoryService;
using ServiceLayer.Dto;
using ServiceLayer.IServices;

namespace ServiceLayer.Services
{
    public class DealerService : IDealerService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IDealerRepository _dealerRepository;
        public DealerService(ApplicationDBContext context, IMapper mapper, IDealerRepository dealerRepository)
        {
            _context = context;
            _mapper = mapper;
            _dealerRepository = dealerRepository;
        }
        public async Task<bool> AddRecord(DealerDto dealer)
        {
            try
            {
                TblUser tblUser = new()
                {
                    FirstName = dealer.FirstName,
                    LastName = dealer.LastName,
                    Password = dealer.PasswordHash,
                    Username = dealer.UserName,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDateTime = DateTime.Now,
                    RoleId = 1
                };
                await _context.AddAsync(tblUser);
                bool result = Convert.ToBoolean(await _context.SaveChangesAsync());
                if (result)
                {
                    TblDealers tblDealers = _mapper.Map<TblDealers>(dealer);
                    tblDealers.UserId = tblUser.Id;
                    result = await _dealerRepository.Add(tblDealers);
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IList<DealerListingDto>> GetAllRecords()
        {
            try
            {
                var dealers = await (from dealer in _context.tblDealers
                                     join user in _context.tblUsers on dealer.UserId equals user.Id
                                     select new DealerListingDto
                                     {
                                         Id = dealer.Id,
                                         Address = dealer.Address,
                                         FullName = user.FirstName + Constants.Space + user.LastName,
                                         GstNo = dealer.GstNo,
                                         IsActive = dealer.IsActive,
                                         MobileNo = dealer.MobileNo,
                                         ShopName = dealer.ShopName,
                                         UserName = user.Username
                                     }).ToListAsync();
                return dealers;
            }
            catch
            {
                throw;
            }
        }
        public async Task<DealerDto> GetRecordById(int? id)
        {
            try
            {
                var dealer = await (from deal in _context.tblDealers
                                    join user in _context.tblUsers on deal.UserId equals user.Id
                                    select new DealerDto
                                    {
                                        Id = deal.Id,
                                        Address = deal.Address,
                                        Discount = deal.Discount,
                                        DOB = deal.DOB,
                                        FirstName = user.FirstName,
                                        GstNo = deal.GstNo,
                                        ImageFileName = deal.ImageFileName,
                                        LastName = user.LastName,
                                        MobileNo = deal.MobileNo,
                                        SalesmanId = deal.SalesmanId,
                                        ShopName = deal.ShopName,
                                        State = deal.State,
                                        UserName = user.Username
                                    }).FirstOrDefaultAsync();
                return dealer;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateRecord(DealerDto dealerDto)
        {
            try
            {
                bool result = false;
                TblUser? tblUser = await (from dealer in _context.tblDealers
                                          join user in _context.tblUsers on dealer.UserId equals user.Id
                                          where dealer.Id == dealerDto.Id
                                          select user).FirstOrDefaultAsync();
                if (tblUser != null)
                {
                    tblUser.FirstName = dealerDto.FirstName;
                    tblUser.LastName = dealerDto.LastName;
                    tblUser.LastUpdatedDateTime = DateTime.Now;
                    tblUser.Username = dealerDto.UserName;
                    _context.Entry(tblUser).State = EntityState.Modified;
                    result = Convert.ToBoolean(_context.SaveChangesAsync());
                    if (result)
                    {
                        TblDealers? tblDealers = await _context.tblDealers.FindAsync(dealerDto.Id);
                        tblDealers.Discount = dealerDto.Discount;
                        tblDealers.DOB = dealerDto.DOB;
                        tblDealers.Discount = dealerDto.Discount;
                        tblDealers.Address = dealerDto.Address;
                        tblDealers.GstNo = dealerDto.GstNo;
                        if (tblDealers.ImageFileName != null || tblDealers.ImageFileName != string.Empty)
                        {
                            tblDealers.ImageFileName = dealerDto.ImageFileName;
                        }
                        tblDealers.MobileNo = dealerDto.MobileNo;
                        tblDealers.SalesmanId = dealerDto.SalesmanId;
                        tblDealers.ShopName = dealerDto.ShopName;
                        tblDealers.State = dealerDto.State;
                        result = await _dealerRepository.Update(tblDealers);
                    }
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteRecord(int? dealerId)
        {
            try
            {
                bool result = false;
                TblDealers? tblDealers = await _context.tblDealers.FindAsync(dealerId);
                if (tblDealers != null)
                {
                    result = await _dealerRepository.Remove(tblDealers);
                    TblUser? tblUser = await _context.tblUsers.FindAsync(tblDealers.UserId);
                    if (tblUser != null)
                    {
                        _context.tblUsers.Remove(tblUser);
                        result = Convert.ToBoolean(await _context.SaveChangesAsync());
                    }
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> IsRecordExist(string username)
        {
            try
            {
                return await _context.tblUsers.AnyAsync(x => x.Username == username);
            }
            catch
            {
                throw;
            }
        }
    }
}
