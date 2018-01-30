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
        static string conSql = "server=MAHONE\\DATACENTER;database=ProductDB;integrated security=SSPI";
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conSql;
            con.Open();
            SqlCommand com = new SqlCommand()
            {
                Connection = con
            };
            string sql = "SELECT  *FROM    StockDetailDaily(NOLOCK)";//  ORDER BY effectdate DESC ";
            SqlDataAdapter findData = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            Dictionary<int, Dictionary<DateTime, XYEntity>>  Instance = new Dictionary<int, Dictionary<DateTime,XYEntity>>();
            findData.Fill(ds);
            foreach(DataTable dt in ds.Tables)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    Convert2Entity(dr, Instance);
                }
            }


            Dictionary<DateTime,XYEntity> entityDic=null;
            if(Instance.TryGetValue(600000,out entityDic) && entityDic!=null && entityDic.Count>0)
            {
                Console.WriteLine(entityDic.Count);
            }



            
        }

        public static void Convert2Entity(DataRow dr, Dictionary<int, Dictionary<DateTime, XYEntity>> instance)
        {
            XYEntity entityTemp;
            int stockID;
            string StockName;
            DateTime EffectDate;
            double OpenPrice, HighPrice, ClosePrice, LowPrice, Volume, PriceChange, ChangePercent, MP_5_Days, MP_10_Days, MP_20_Days, MV_5_Days, MV_10_Days, MV_20_Days, TurnOver;
            NewMethod(dr, out entityTemp, out stockID, out StockName, out EffectDate, out OpenPrice, out HighPrice, out ClosePrice, out LowPrice, out Volume, out PriceChange, out ChangePercent, out MP_5_Days, out MP_10_Days, out MP_20_Days, out MV_5_Days, out MV_10_Days, out MV_20_Days, out TurnOver);/*实体赋值*/
            entityTemp.StockID = stockID;
            entityTemp.StockName = StockName;
            entityTemp.EffectDate = EffectDate;
            entityTemp.OpenPrice = OpenPrice;
            entityTemp.HighPrice = HighPrice;
            entityTemp.ClosePrice = ClosePrice;
            entityTemp.LowPrice = LowPrice;
            entityTemp.Volume = Volume;
            entityTemp.PriceChange = PriceChange;
            entityTemp.ChangePercent = ChangePercent;
            entityTemp.MP_5_Days = MP_5_Days;
            entityTemp.MP_10_Days = MP_10_Days;
            entityTemp.MP_20_Days = MP_20_Days;
            entityTemp.MV_5_Days = MV_5_Days;
            entityTemp.MV_10_Days = MV_10_Days;
            entityTemp.MV_20_Days = MV_20_Days;
            entityTemp.TurnOver = TurnOver;
            /*加入Dictionary中*/
            Dictionary<DateTime, XYEntity> entity = null;
            if (instance.TryGetValue(stockID, out entity) && entity != null)
            {
                entity[entityTemp.EffectDate] = entityTemp;
            }
            else
            {
                entity = new Dictionary<DateTime, XYEntity>
                {
                    { entityTemp.EffectDate, entityTemp }
                };
                instance[stockID] = entity;
            }
        }

        private static void NewMethod(DataRow dr, out XYEntity entityTemp, out int stockID, out string StockName, out DateTime EffectDate, out double OpenPrice, out double HighPrice, out double ClosePrice, out double LowPrice, out double Volume, out double PriceChange, out double ChangePercent, out double MP_5_Days, out double MP_10_Days, out double MP_20_Days, out double MV_5_Days, out double MV_10_Days, out double MV_20_Days, out double TurnOver)
        {
            entityTemp = new XYEntity();
            /*将DB中object转换成实体值*/
            stockID = Convert.ToInt32(dr.ItemArray[0]);
            StockName = Convert.ToString(dr.ItemArray[1]);
            EffectDate = Convert.ToDateTime(dr.ItemArray[2]).Date;
            OpenPrice = Convert.ToDouble(dr.ItemArray[3]);
            HighPrice = Convert.ToDouble(dr.ItemArray[4]);
            ClosePrice = Convert.ToDouble(dr.ItemArray[5]);
            LowPrice = Convert.ToDouble(dr.ItemArray[6]);
            Volume = Convert.ToDouble(dr.ItemArray[7]);
            PriceChange = Convert.ToDouble(dr.ItemArray[8]);
            ChangePercent = Convert.ToDouble(dr.ItemArray[9]);
            MP_5_Days = Convert.ToDouble(dr.ItemArray[10]);
            MP_10_Days = Convert.ToDouble(dr.ItemArray[11]);
            MP_20_Days = Convert.ToDouble(dr.ItemArray[12]);
            MV_5_Days = Convert.ToDouble(dr.ItemArray[13]);
            MV_10_Days = Convert.ToDouble(dr.ItemArray[14]);
            MV_20_Days = Convert.ToDouble(dr.ItemArray[15]);
            TurnOver = Convert.ToDouble(dr.ItemArray[16]);
        }
    }
}


