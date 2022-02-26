using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Common
{
   public static class CommonDBUtil
    {

     public static string NullToString(object Value)
        {

 return Value == null ? "" : Value.ToString();             
        }
    }
}
