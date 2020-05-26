using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class GoodRepository : IRepository<Good>
    {
        GoodContext db;

        public GoodRepository(GoodContext db)
        {
            this.db = db;
        }
        public async Task AddAsync(Good item)
        {
            db.Entry(item).State = EntityState.Added;
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Good item = db.Goods.FirstOrDefault(d => d.Id == id);

            if (item != null)
            {
                db.Entry(item).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }
        }

        public async Task<Good> GetByIdAsync(int Id)
        {
            return await db.Goods.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public async Task<bool> UpdateAsync(Good item)
        {
            //var item = await GetByIdAsync(Id);
            Good good = await GetByIdAsync(item.Id);
            if(good!=null)
            {
                db.Entry(good).State = EntityState.Detached;
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Good>> GetAllAsync()
        {
             return await db.Goods.ToListAsync();
        }
    }
}
