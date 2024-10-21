using CSMWebsite2024.Data.Posts;
using CSMWebsite2024.Data.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMWebsite2024.EntityFramework
{
	public class DefaultDbContext : DbContext
	{
		public DefaultDbContext(DbContextOptions options): base(options)
		{
		}

		public DbSet<Post>? Posts { get;set; } //Use Plural name for table names
		public DbSet<User>? Users { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid? userId1 = Guid.NewGuid();
            Guid? userId2 = Guid.NewGuid();
            Guid? userId3 = Guid.NewGuid();

			List<User> users = new List<User>()
            {
                new User()
                {
                    Id = userId1,
                    EmailAddress = "etirel@mailinator.com",
                    FirstName = "Elspeth",
                    LastName = "Tirel",
                    Points = 3
                },
                new User()
                {
                    Id =userId2,
					EmailAddress = "jbeleren@mailinator.com",
					FirstName = "Jace",
					LastName = "Beleren",
					Points = 3
				},
                new User()
                {
                    Id =userId3,
					EmailAddress = "lvess@mailinator.com",
					FirstName = "Liliana",
					LastName = "Vess",
					Points = 3
				}
            };

			List<Post> posts = new List<Post>()
			{
				new Post()
				{	
					Id = Guid.NewGuid(),
					Title = "SCHOOL YEAR IS OPEN",
					Description = "Admins open the school year",
					AuthorId = userId1,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
				},
                new Post()
                {
                    Id = Guid.NewGuid(),
                    Title = "IS COURSE HAS NEW STUDENTS",
                    Description = "IS Department welcomes 24 new students",
                    AuthorId = userId2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Post()
                {
                    Id = Guid.NewGuid(),
                    Title = "SPORTSFEST IS APPROACHING",
                    Description = "See Academic Calendar for details",
                    AuthorId = userId3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
            };

			modelBuilder.Entity<User>().HasData(users);
			modelBuilder.Entity<Post>().HasData(posts);

        }
    }
}
