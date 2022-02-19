using ApplicationDomain.Entities;
using AspNetCore.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        protected IHttpContextAccessor _httpContextAccessor { get; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public object GetUnitOfWorkContext()
        {
            return this;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var configLoader = new ConfigurationLoader<ApplicationDbContext>(builder);
            configLoader.Load();
        }

        public override int SaveChanges()
        {
            Tracking();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            Tracking();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            Tracking();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void Tracking()
        {
            foreach (var entity in ChangeTracker
                           .Entries()
                           .Where(p => p.Entity is EntityBase<int> && (p.State == EntityState.Added || p.State == EntityState.Modified))
                           .Select(p => p.Entity).Cast<EntityBase<int>>())
            {
                entity.CreatedDate = entity.CreatedByUserId == 0 ? DateTime.Now : entity.CreatedDate;
                entity.UpdatedDate = DateTime.Now;

                var userId = this._httpContextAccessor?.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "-1";
                entity.CreatedByUserId = entity.CreatedByUserId == 0 ? int.Parse(userId) :entity.CreatedByUserId;
                entity.UpdatedByUserId = int.Parse(userId);
            }
        }
    }
}