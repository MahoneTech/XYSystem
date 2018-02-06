using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;

namespace XYSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var id=new DataCache();
            Dictionary<DateTime, XYEntity> entity;
            if (DataCache.Instance.TryGetValue(3, out entity) && entity != null)
            {
                
            }




        }
    }
}


