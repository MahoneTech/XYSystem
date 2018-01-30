using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYSystem
{
    class XYEntity
    {
        /// <summary>
        /// 股票ID
        /// </summary>
        public int StockID { get; set; }

        /// <summary>
        /// 股票名称
        /// </summary>
        public string StockName { get; set; }

        /// <summary>
        /// 数据日期
        /// </summary>
        public DateTime EffectDate { get; set; }

        /// <summary>
        /// 开盘价
        /// </summary>
        public double OpenPrice { get; set; }

        /// <summary>
        /// 最高成交价
        /// </summary>
        public double HighPrice { get; set; }

        /// <summary>
        /// 收盘成交价
        /// </summary>
        public double ClosePrice { get; set; }

        /// <summary>
        /// 收盘成交价
        /// </summary>
        public double LowPrice { get; set; }

        /// <summary>
        /// 交易额
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// 价格变化量
        /// </summary>
        public double PriceChange { get; set; }

        /// <summary>
        /// 价格变化值
        /// </summary>
        public double ChangePercent { get; set; }

        /// <summary>
        /// 5天均值
        /// </summary>
        public double MP_5_Days { get; set; }

        /// <summary>
        /// 10天均价
        /// </summary>
        public double MP_10_Days { get; set; }

        /// <summary>
        /// 20天均价
        /// </summary>
        public double MP_20_Days { get; set; }

        /// <summary>
        /// 5日均量
        /// </summary>
        public double MV_5_Days { get; set; }

        /// <summary>
        /// 10日均量
        /// </summary>
        public double MV_10_Days { get; set; }

        /// <summary>
        /// 20日均量
        /// </summary>
        public double MV_20_Days { get; set; }

        /// <summary>
        /// 换手率
        /// </summary>
        public double TurnOver { get; set; }
    }
}
