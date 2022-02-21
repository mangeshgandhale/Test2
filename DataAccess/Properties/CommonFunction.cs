using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; 
using System.Reflection;
 
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace MVC3Layer.common
{
    public static class CommonFunction
    {

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName) 
                    pro.SetValue(obj, Convert.ChangeType(dr[column.ColumnName], pro.PropertyType), null);

                    else
                        continue;
                }
            }
            return obj;
        }
        public static List<T> ToListof<T>(this DataTable dt)
        {
            var targetList= (dynamic)null; ;
            try
            {
            
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var objectProperties = typeof(T).GetProperties(flags);
              targetList = dt.AsEnumerable().Select(dataRow =>
            {
                var instanceOfT = Activator.CreateInstance<T>();

                foreach (var properties in objectProperties.Where(properties => columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
                { 
                    properties.SetValue(instanceOfT, Convert.ChangeType(dataRow[properties.Name], properties.PropertyType), null);

                }
                return instanceOfT;
            }).ToList();
            }
            catch (Exception ex)
            {

            }
            return targetList;
        }
        
       
     
   

       
           }
}