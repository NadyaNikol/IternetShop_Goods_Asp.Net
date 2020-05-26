using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class UserRepository 
    {
        GoodContext db;

        public UserRepository(GoodContext db)
        {
            this.db = db;
        }
  

        public async Task<List<User>> GetAllAsync()
        {
            return await db.Users.ToListAsync();
        }

        public async Task AddAsync(User item)
        {
            db.Entry(item).State = EntityState.Added;
            await db.SaveChangesAsync();
        }

        public async Task<User> FindUserByLoginAsync(string email, string password)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
