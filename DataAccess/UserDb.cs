using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using System.Data.Entity;

namespace DataAccess
{
  
    public class UserDb
    {
        //public UserDb()
        //{
        //    this.Model1 = new LinkHubDbEntities();
        //}
        //public IEnumerable<T_VirtualUser> GetAll1()
        //{
        //    return this.GetAll();
        //}

        public IEnumerable<UserBO> GetAll()
        {
            return this.GetAll();

        }

        public void Insert(UserBO _UserBO)
        {

            using (somaEntities db = new somaEntities())
            {



                var _ouser = new M_User()
                {
                    UserName = _UserBO.UserName,
                    password = _UserBO.password
                };
                db.M_User.Add(_ouser);

                db.SaveChanges();


            }


           


            //db.SaveChanges()

            //db.UserBO.Add(_UserBO);
            //using (var context = new Model1())
            //{
            //    var std = context..First<Student>();
            //    std.FirstName = "Steve";
            //    context.SaveChanges();
            //}
        }
    }
}
