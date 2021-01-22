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

        public IPagedList<Admin> AdminBlocked(int pageNumber, int recordPerPage)
        {
            return db.Admin.Where(item => item.isBlock == true)
                .OrderByDescending(item => item.Id)
                .ToPagedList(pageNumber, recordPerPage);
        }

        public IPagedList<Admin> SupperAdmin(int pageNumber, int recordPerPage)
        {
            return db.Admin.Where(item => item.isSupper == true)
                .OrderByDescending(item => item.Id)
                .ToPagedList(pageNumber, recordPerPage);
        }

        public void ThemMoi(Admin admin)
        {
            admin.NgayTao = DateTime.Now;
            db.Admin.Add(admin);
            Save();
        }

        public bool Block(int id = 0)
        {
            var result = db.Admin.SingleOrDefault(item => item.Id == id);
            if(result != null)
            {
                result.isBlock = true;
                Save();
                return true;
            }
            return false;
        }

        public bool Unlock(int id = 0)
        {
            var admin = db.Admin.SingleOrDefault(item => item.Id == id);
            if(admin != null)
            {
                admin.isBlock = false;
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
