using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataModel
    {
        #region ID
        private int id;
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        #endregion

        #region 订单号
        private string Order_Num;
        public string ORDER_NUM
        {
            set { Order_Num = value; }
            get { return Order_Num; }
        }
        #endregion

        #region 型号
        private string Oodel_Type;
        public string MODEL_TYPE
        {
            set { Oodel_Type = value; }
            get { return Oodel_Type; }
        }

        #endregion

        #region 库存数
        private string Stock_Num;
        public string STOCK_NUM
        {
            set { Stock_Num = value; }
            get { return Stock_Num; }
        }
        #endregion

        #region 当日入库数
        private string Storage_Num;
        public string STORAGE_NUM
        {
            set { Storage_Num = value; }
            get { return Storage_Num; }
        }
        #endregion

        #region 当日出库数
        private string Outbound_Num;
        public string OUTBOUND_NUM
        {
            set { Outbound_Num = value; }
            get { return Outbound_Num; }
        }
        #endregion

        #region 目前缺货数
        private string SHORAGE_Num;
        public string SHORAGE_NUM
        {
            set { SHORAGE_Num = value; }
            get { return SHORAGE_Num; }
        }
        #endregion

        #region 在产数量
        private string PRODUCTION_Num;
        public string PRODUCTION_NUM
        {
            set { PRODUCTION_Num = value; }
            get { return PRODUCTION_Num; }
        }
        #endregion

        #region 在途计划
        private string PLAN_Num;
        public string PLAN_NUM
        {
            set { PLAN_Num = value; }
            get { return PLAN_Num; }
        }
        #endregion

        #region 待产
        private string flg_delivered;
        public string FLG_DELIVERED
        {
            set { flg_delivered = value; }
            get { return flg_delivered; }
        }
        #endregion

        #region 完成
        private string flg_finish;
        public string FLG_FINISH
        {
            set { flg_finish = value; }
            get { return flg_finish; }
        }
        #endregion

        #region 紧急
        private string flg_emergency;
        public string FLG_EMERGENCY
        {
            set { flg_emergency = value; }
            get { return flg_emergency; }
        }
        #endregion
    }
}
