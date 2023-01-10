using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class UserDao
    {
        private DBContext db;

        public UserDao()
        {
            db = new DBContext();
        }

        public long Insert(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return user.ID;
        }


        public User GetById(string userName)
        {
            return db.User.SingleOrDefault(x => x.UserName == userName);
        }


        public int login(string userName, string passWord)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == userName);
            if(result == null )
            {
                return 0;
            }
            else
            {
                if(result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if( result.Password== passWord ) 
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
    }
}
