using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCaNhan.Data.Repositories
{
    public class RepositoryBase
    {
        protected BlogCaNhanDbContext db;
        public RepositoryBase()
        {
            db = new BlogCaNhanDbContext();
        }

        public RepositoryBase(BlogCaNhanDbContext _db)
        {
            db = _db;
        }

        public async void Save()
        {
            await db.SaveChangesAsync();
        }
    }
}
