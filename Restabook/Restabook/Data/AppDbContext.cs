using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restabook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Testimonial> Testimonials { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Chef> Chefs { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }
    }
}
