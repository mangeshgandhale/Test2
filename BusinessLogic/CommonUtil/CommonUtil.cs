using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
public class CommonUtil
    {
        public   List<T> GetObjectsFromGridFormCollection<T>(string gridCollectionPrefix, List<KeyValuePair<string, string>> gridFormKeys, StringBuilder ErrorLog)
        {
            T OutputObject;
            List<T> OutputObjectCollection;
            System.Reflection.PropertyInfo[] info;
            System.Reflection.PropertyInfo objColumn;
            List<KeyValuePair<string, string>> RecordKeys;
            KeyValuePair<string, string> ColumnKey;
            KeyValuePair<string, string> defaultValue = default(KeyValuePair<string, string>);
            string keyLookUpString, keyLookUpStringWithColumn;
            int TotalColumns, TotalRecords;
           

                try
            {
                TotalColumns = gridFormKeys.Where(k => k.Key.Contains((gridCollectionPrefix + "(0)"))).ToList().Count;
                TotalRecords =Convert.ToInt32( gridFormKeys.Count / (double)TotalColumns);
                OutputObjectCollection = new List<T>();
                for (int record = 0; record <= TotalRecords - 1; record++)
                {
                    OutputObject = (T)Activator.CreateInstance(typeof(T));
                    info = OutputObject.GetType().GetProperties();
                    keyLookUpString = gridCollectionPrefix + "(" + record.ToString() + ")";
                    RecordKeys = gridFormKeys.Where(k => k.Key.StartsWith(keyLookUpString)).ToList();
                    for (var columns = 0; columns <= info.Count() - 1; columns++)
                    {
                        objColumn = (System.Reflection.PropertyInfo)info[columns];
                        keyLookUpStringWithColumn = keyLookUpString + "." + objColumn.Name.ToString();
                        ColumnKey = gridFormKeys.Where(k => k.Key.StartsWith(keyLookUpStringWithColumn)).FirstOrDefault();
                        if (!ColumnKey.Equals(defaultValue))
                        {
                            if (string.IsNullOrEmpty(ColumnKey.Value) == false)
                            {
                                Type objType = Nullable.GetUnderlyingType(objColumn.PropertyType);
                                if (objType != null)
                                {
                                    if (objColumn != null && objColumn.CanWrite == true)
                                        objColumn.SetValue(OutputObject, Convert.ChangeType(ColumnKey.Value, objType), null);
                                    else
                                        ErrorLog.AppendLine(gridCollectionPrefix + ": Invalid " + ColumnKey.Key);
                                }
                                else if (objColumn != null && objColumn.CanWrite == true)
                                    objColumn.SetValue(OutputObject, Convert.ChangeType(ColumnKey.Value, objColumn.PropertyType), null);
                                else
                                    ErrorLog.AppendLine(gridCollectionPrefix + ": Invalid " + ColumnKey.Key);
                            }
                        }
                    }
                    gridFormKeys.RemoveAll(k => k.Key.StartsWith(keyLookUpString));
                    OutputObjectCollection.Add(OutputObject);
                    OutputObject = default(T);
                }
                if (OutputObjectCollection != null && OutputObjectCollection.Count > 0)
                    return OutputObjectCollection;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                OutputObject = default(T);
                info = null;
                objColumn = null;
                RecordKeys = null;
                ColumnKey = default(KeyValuePair<string, string>);
                defaultValue = default(KeyValuePair<string, string>);
            }
        }


    }
}
