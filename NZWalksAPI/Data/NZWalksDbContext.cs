using Microsoft.EntityFrameworkCore;

namespace NZWalksAPI.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Models.Region> Regions { get; set; }
        public DbSet<Models.Difficulty> Difficulties { get; set; }
        public DbSet<Models.Walk> Walks { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    // Seed data for Regions
        //    modelBuilder.Entity<Models.Regions>().HasData(
        //        new Models.Regions { Id = Guid.Parse("56005eaf-7aa7-4244-9b5d-723a25b995c4"), Name = "Auckland", Code = "AKL", RegionImageUrl = "https://images.pexels.com/photos/5342978/pexels-photo-5342978.jpeg" },
        //        new Models.Regions { Id = Guid.Parse("7d42bb7b-baa5-4e3c-a3f6-3b554df46f95"), Name = "Northland", Code = "NTL", RegionImageUrl = "null" },
        //        new Models.Regions { Id = Guid.Parse("a3bd61b1-638d-4643-a2a8-45be6e6a43b8"), Name = "Bay Of Plenty", Code = "BOP", RegionImageUrl = "null" },
        //        new Models.Regions { Id = Guid.Parse("d6a2cb96-f2e3-4417-baa4-b22ad876f4e1"), Name = "Wellington", Code = "WGL", RegionImageUrl = "https://images.pexels.com/photos/33954807/pexels-photo-33954807.jpeg" },
        //        new Models.Regions { Id = Guid.Parse("6e73bf95-6faf-4954-b360-5cb197a3ef25"), Name = "Nelson", Code = "NSL", RegionImageUrl = "https://media.istockphoto.com/id/1209995566/photo/panorama-of-nelson-city-reflected-in-the-maitai-river-new-zealand.jpg?s=1024x1024&w=is&k=20&c=ynC5H3sKnrq4Tc4swHlao07JPv13wPEmdwuGG6d7IQE=" },
        //        new Models.Regions { Id = Guid.Parse("5513d45f-be9e-46df-b40d-cb06e404d552"), Name = "Southland", Code = "STL", RegionImageUrl = "null" }
        //    );
        //    // Seed data for Difficulties
        //    modelBuilder.Entity<Models.Difficulty>().HasData(
        //        new Models.Difficulty { Id = Guid.Parse("fbd4e8ac-4eb5-4199-aefc-4731644fb0ef"), Name = "Easy" },
        //        new Models.Difficulty { Id = Guid.Parse("56da5bcd-0a54-4742-8048-9acec8c0bff8"), Name = "Medium" },
        //        new Models.Difficulty { Id = Guid.Parse("c982ef08-f130-4b09-963b-b4dc44843b2e"), Name = "Hard" }
        //    );
        //}
    }
}
