using CarRentApp.Domain.Identity;
using CarRentApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Repository.Implementation
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<AppUser> entities;
        string errorMessage = string.Empty;

        public AppUserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<AppUser>();
        }
        public void Delete(AppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public AppUser Get(string? id)
        {

            return entities
               .Include(z => z.RentedVehicles)
               .Include("RentedVehicle.User")
               .SingleOrDefault(s => s.Id == id);

        }

        public IEnumerable<AppUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(AppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(AppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
