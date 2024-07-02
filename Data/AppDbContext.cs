﻿using GameZone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GameZone.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Game> games { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Device> devices { get; set; }
        public DbSet<GameDevice> gameDevices { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<City> cities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category[]
                {
                    new Category{Id = 1, Name = "Sports"},
                    new Category{Id = 2, Name = "Action"},
                    new Category{Id = 3, Name = "Adventure"},
                    new Category{Id = 4, Name = "Racing"},
                    new Category{Id = 5, Name = "Fighting"},
                    new Category{Id = 6, Name = "Film"},
                });
            modelBuilder.Entity<Device>().HasData(
               new Device[]
               {
                    new Device{Id = 1, Name = "PlayStation" , Icon="bi bi-playstation"},
                    new Device{Id = 2, Name = "xbox", Icon="bi bi-xbox"},
                    new Device{Id = 3, Name = "Nintendo Switch", Icon="bi bi-nintendo-switch"},
                    new Device{Id = 4, Name = "Pc", Icon="bi bi-pc-display"},
               });
            modelBuilder.Entity<GameDevice>().HasKey(e => new
            {
                e.gameId,
                e.deviceId
            });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "admin",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "user",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}