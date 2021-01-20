using BlogCaNhan.DTOs;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogCaNhan.Data.Repositories
{
    public class AdminRepository : RepositoryBase
    {
        public AdminRepository() : base() { }
        public AdminRepository(BlogCaNhanDbContext _db) : base(_db) { }

        public Admin Login(string username = "", string password = "")
        {
            return db.Admin.Where(item => item.Username == username &&
                item.Password == password && item.isBlock != true).SingleOrDefault();
        }

        public IPagedList<Admin> DanhSachAdmin(int pageNumber, int recordPerPage)
        {
            return db.Admin.Where(item => item.isBlock != true)
                .OrderByDescending(item => item.NgayTao)
                .ToPagedList(pageNumber: pageNumber, pageSize: recordPerPage);
        }
    }
}
