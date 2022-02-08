using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
