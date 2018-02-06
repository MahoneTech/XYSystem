using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace XYSystem
{
    public sealed class DataCache
    {
        static string conSql = "server=MAHONE\\DATACENTER;database=ProductDB;integrated security=SSPI";
        public static Dictionary<int, Dictionary<DateTime, XYEntity>> Instance = new Dictionary<int, Dictionary<DateTime, XYEntity>>();

        public DataCache()
        {
            var con = new SqlConnection {ConnectionString = conSql};
            con.Open();
            var sql = "SELECT  *FROM    StockDetailDaily(NOLOCK)";//  ORDER BY effectdate DESC ";
            var findData = new SqlDataAdapter(sql, con);
            var ds = new DataSet();
            findData.Fill(ds);
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ArrangeData(dr, Instance);
                }
            }
        }

        public static void ArrangeData(DataRow dr, Dictionary<int, Dictionary<DateTime, XYEntity>> instance)
        {
            XYEntity entityTemp;
            int stockId;
            string stockName;
            DateTime effectDate;
            double openPrice,highPrice,closePrice,lowPrice,volume,priceChange,changePercent,mp5Days,mp10Days,mp20Days,mv5Days,mv10Days,mv20Days,turnOver;
            Convert2Entity(dr, out entityTemp, out stockId, out stockName, out effectDate, out openPrice, out highPrice, out closePrice, out lowPrice, out volume, out priceChange, out changePercent, out mp5Days, out mp10Days, out mp20Days, out mv5Days, out mv10Days, out mv20Days, out turnOver);/*实体赋值*/
            entityTemp.StockID = stockId;
            entityTemp.StockName = stockName;
            entityTemp.EffectDate = effectDate;
            entityTemp.OpenPrice = openPrice;
            entityTemp.HighPrice = highPrice;
            entityTemp.ClosePrice = closePrice;
            entityTemp.LowPrice = lowPrice;
            entityTemp.Volume = volume;
            entityTemp.PriceChange = priceChange;
            entityTemp.ChangePercent = changePercent;
            entityTemp.MP_5_Days = mp5Days;
            entityTemp.MP_10_Days = mp10Days;
            entityTemp.MP_20_Days = mp20Days;
            entityTemp.MV_5_Days = mv5Days;
            entityTemp.MV_10_Days = mv10Days;
            entityTemp.MV_20_Days = mv20Days;
            entityTemp.TurnOver = turnOver;
            /*加入Dictionary中*/
            Dictionary<DateTime, XYEntity> entity;
            if (instance.TryGetValue(stockId, out entity) && entity != null)
            {
                entity[entityTemp.EffectDate] = entityTemp;
            }
            else
            {
                entity = new Dictionary<DateTime, XYEntity>
                {
                    { entityTemp.EffectDate, entityTemp }
                };
                instance[stockId] = entity;
            }
        }

        /// <summary>
        /// 将OBJ转换为Entity
        /// </summary>
        private static void Convert2Entity(DataRow dr, out XYEntity entityTemp, out int stockID, out string StockName, out DateTime EffectDate, out double OpenPrice, out double HighPrice, out double ClosePrice, out double LowPrice, out double Volume, out double PriceChange, out double ChangePercent, out double MP_5_Days, out double MP_10_Days, out double MP_20_Days, out double MV_5_Days, out double MV_10_Days, out double MV_20_Days, out double TurnOver)
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
