using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalksAPI.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Seed data for Roles
        //    var readerRoleID = "b3552442-0665-4852-9165-61cc5be57a6c";
        //    var writerRoleID = "5c3cffe6-3f44-42c4-877b-55282836f6c3";

        //    var roles = new List<IdentityRole>
        //    {
        //        new IdentityRole{Id = readerRoleID, ConcurrencyStamp = readerRoleID, Name = "Reader", NormalizedName = "READER" },
        //        new IdentityRole{Id = writerRoleID, ConcurrencyStamp = readerRoleID, Name = "Writer", NormalizedName = "WRITER" }
        //    };

        //    modelBuilder.Entity<IdentityRole>().HasData(roles);
        //}
    }
}
