using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess;
namespace BusinessLogic
{
    public class UserBL
    {
        UserDb obj = new UserDb();

        public IEnumerable<UserBO> GetAll()
        {
            return obj.GetAll();

        }
        public void Insert(UserBO _UserBO)
        {
            this.obj.Insert(_UserBO);
        }
    }
}
