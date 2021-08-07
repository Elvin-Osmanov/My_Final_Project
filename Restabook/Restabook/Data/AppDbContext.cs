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

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductTag> ProductTags { get; set; }

        public DbSet<ProductPhoto> ProductPhotos { get; set; }

        public DbSet<ProductReview> ProductReviews { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactMessage> ContactMessages { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Checkout> Checkouts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }



    }
}
