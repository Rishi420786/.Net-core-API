using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.DataContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<TblUser> tblUsers { get; set; }
        public DbSet<TblRole> tblRoles { get; set; }
        public DbSet<TblRating> tblRatings { get; set; }    
        public DbSet<TblUserRating> tblUserRatings { get; set; }
        public DbSet<TblRolePageMaster> tblRolePageMaster { get; set;}
        public DbSet<TblRolePermissions> tblRolePermissions { get; set; }
        public DbSet<TblStoneMaster> tblStoneMaster { get; set;}
        public DbSet<TblStoneShapeMaster> tblStoneShapeMaster { get; set; }
        public DbSet<TblStoneColorMaster> tblStoneColorMaster { get; set; }
        public DbSet<TblStoneCutMaster> tblStoneCutMaster { get;set; }
        public DbSet<TblQualityMaster> tblQualityMaster { get; set; }   
    }
}
