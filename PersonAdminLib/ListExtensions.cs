using System;
using System.Collections.Generic;

namespace PersonAdminLib
{
    public static class ListExtensions
    {

        //public static List<string> GetItemsAsString<T>(this List<T> list)
        public static IEnumerable<string> GetItemsAsString<T>(this List<T> list)
        {
            List<string> resultlist = new List<string>();
            /*foreach (var item in list) {

                resultlist.Add(item.ToString()); 

            }

            return resultlist;*/

            foreach (var item in list)
            {

                yield return item.ToString();

            }
        }

    }


}
