using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using ModelCPro.EntityFrameWork;
using PagedList;
using PagedList.Mvc;

namespace ModelCPro.DataAccessLayer
{
    public class UserDal
    {
        private CProDbContext db = null;

        public UserDal()
        {
            db = new CProDbContext();
        }
        // Add 1 user vao database
        public long Insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();

            return user.ID;
        }

        // Login v1
        //public bool Login(string userName, string passWord)
        //{
        //    // dem xem co ban ghi nao trung voi userName va passWord truyen vao khong
        //    var login = db.Users.Count(x => x.UserName == userName && x.Password == passWord);
        //    if (login > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
         
        // Login v2
        public int Login(string userName, string passWord)
        {
            var login = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (login == null)
            {
                return 0;
            }
            else
            {
                if (login.Status == false)
                {
                    return -2;
                }
                else
                {
                    if (login.Password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;  
                    }
                }
            }
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x=>x.UserName == userName);
        }

        public User ViewDetail(long id)
        {
            return db.Users.Find(id);
        }
        public IEnumerable<User> GetAllUsers(string searchString,int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                if(!string.IsNullOrEmpty(entity.Password))          
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.Name = entity.Name;
                user.Email = entity.Email;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }
        public bool Delete(long id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
