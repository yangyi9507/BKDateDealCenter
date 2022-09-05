using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data;
using comm;
using Model;

namespace BKDateDealCenter
{
    public partial class AjaxMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["Action"] == "GetData")
            {
                //获取页面显示数据
                GetData();
                Response.End();
            }
            else if (Request.Params["Action"] == "UpdateData") 
            {
                //更新数据
                UpdateData();
                Response.End();
            }
            else if (Request.Params["Action"] == "InsertData")
            {
                //插入数据
                InsertData();
                Response.End();
            }
            else if (Request.Params["Action"] == "DeleteData")
            {
                //删除数据
                DeleteData();
                Response.End();
            }
            else if (Request.Params["Action"] == "GetQCData")
            {
                //获取固定资产页面显示数据
                GetQCData();
                Response.End();
            }
            else if (Request.Params["Action"] == "UpdateQCData")
            {
                //更新固定资产数据
                UpdateQCData();
                Response.End();
            }
            else if (Request.Params["Action"] == "InsertQCData")
            {
                //插入固定资产数据
                InsertQCData();
                Response.End();
            }
            else if (Request.Params["Action"] == "DeleteQCData")
            {
                //删除固定资产数据
                DeleteQCData();
                Response.End();
            }
        }

        #region 获取表内的相关数据
        private void GetData() 
        {
            try
            {
                //声明数据处理类,调用查询语句
                DataDeal dataDeal = new DataDeal();
                DataTable dt = dataDeal.Select();
                //页面展示的前台页面数据
                string[] Arr = {"ID", "ORDER_NUM", "MODEL_TYPE", "STOCK_NUM", "STORAGE_NUM", "OUTBOUND_NUM", "SHORAGE_NUM", "PRODUCTION_NUM", "PLAN_NUM", "flg_delivered", "flg_finish", "flg_emergency" };

                string s = Common.GetJsonString(dt.Rows.Count,1, dt, Arr);

                Response.Write(s);
            }
            catch (Exception)
            {
                var result = new { IsSuccess = false, Msg = "查询失败！"};
                string s = new JavaScriptSerializer().Serialize(result);
                Response.Write(s);
            }

        }
        #endregion

        #region 删除相关数据
        private void DeleteData()
        {
            try
            {
                int ID = int.Parse(Request.Params["ID"]);

                //声明数据处理类,删除语句
                DataDeal dataDeal = new DataDeal();
                int i = dataDeal.Delete(ID);
                string Msgstr = "";
                if (i > 0)
                {
                    Msgstr = "删除成功！";
                }
                else
                {
                    Msgstr = "删除失败！";
                }
                var result = new { IsSuccess = false, Msg = Msgstr };
                string s = new JavaScriptSerializer().Serialize(result);
                Response.Write(s);

            }
            catch (Exception)
            {
                var result = new { IsSuccess = false, Msg = "删除失败！" };
                string s = new JavaScriptSerializer().Serialize(result);
                Response.Write(s);
            }

        }
        #endregion

        #region 插入相关数据
        private void InsertData()
        {
            try
            {
                string ORDER_NUM = Request.Params["ORDER_NUM"] == "" ? "0" : Request.Params["ORDER_NUM"];
                string MODEL_TYPE = Request.Params["MODEL_TYPE"] == "" ? "0" : Request.Params["MODEL_TYPE"];
                string STOCK_NUM = Request.Params["STOCK_NUM"] == "" ? "0" : Request.Params["STOCK_NUM"];
                string STORAGE_NUM = Request.Params["STORAGE_NUM"] == "" ? "0" : Request.Params["STORAGE_NUM"];
                string OUTBOUND_NUM = Request.Params["OUTBOUND_NUM"] == "" ? "0" : Request.Params["OUTBOUND_NUM"];
                string SHORAGE_NUM = Request.Params["SHORAGE_NUM"] == "" ? "0" : Request.Params["SHORAGE_NUM"];
                string PRODUCTION_NUM = Request.Params["PRODUCTION_NUM"] == "" ? "0" : Request.Params["PRODUCTION_NUM"];
                string PLAN_NUM = Request.Params["PLAN_NUM"] == "" ? "0" : Request.Params["PLAN_NUM"];


                DataModel model = new DataModel
                {
                    ORDER_NUM = ORDER_NUM,//订单号
                    MODEL_TYPE = MODEL_TYPE,//型号
                    STOCK_NUM = STOCK_NUM,//库存数
                    STORAGE_NUM = STORAGE_NUM,//当日入库数
                    OUTBOUND_NUM = OUTBOUND_NUM,//当日出库数
                    SHORAGE_NUM = SHORAGE_NUM,//目前缺货数
                    PRODUCTION_NUM = PRODUCTION_NUM,//在产数量
                    PLAN_NUM = PLAN_NUM//在途计划
                };

                //声明数据处理类,调用插入语句
                DataDeal dataDeal = new DataDeal();
                int i = dataDeal.Insert(model);
                string Msgstr = "";
                if (i > 0)
                {
                    Msgstr = "插入成功！";
                }
                else
                {
                    Msgstr = "插入失败！";
                }
                var result = new { IsSuccess = false, Msg = Msgstr };
                string s = new JavaScriptSerializer().Serialize(result);
                Response.Write(s);

            }
            catch (Exception)
            {
                var result = new { IsSuccess = false, Msg = "插入失败！" };
                string s = new JavaScriptSerializer().Serialize(result);
                Response.Write(s);
            }

        }
        #endregion

        #region 更新相关数据
        private void UpdateData() 
        {
            try
            {
                int ID = int.Parse(Request.Params["ID"]);

                string ORDER_NUM = Request.Params["ORDER_NUM"] == "" ? "0" : Request.Params["ORDER_NUM"];
                string MODEL_TYPE = Request.Params["MODEL_TYPE"] == "" ? "0" : Request.Params["MODEL_TYPE"];
                string STOCK_NUM = Request.Params["STOCK_NUM"] == "" ? "0" : Request.Params["STOCK_NUM"];
                string STORAGE_NUM = Request.Params["STORAGE_NUM"] == "" ? "0" : Request.Params["STORAGE_NUM"];
                string OUTBOUND_NUM = Request.Params["OUTBOUND_NUM"] == "" ? "0" : Request.Params["OUTBOUND_NUM"];
                string SHORAGE_NUM = Request.Params["SHORAGE_NUM"] == "" ? "0" : Request.Params["SHORAGE_NUM"];
                string PRODUCTION_NUM = Request.Params["PRODUCTION_NUM"] == "" ? "0" : Request.Params["PRODUCTION_NUM"];
                string PLAN_NUM = Request.Params["PLAN_NUM"] == "" ? "0" : Request.Params["PLAN_NUM"];
                string FLG_DELIVERED = Request.Params["flg_delivered"] == "" ? "0" : Request.Params["flg_delivered"];
                string FLG_FINISH = Request.Params["flg_finish"] == "" ? "0" : Request.Params["flg_finish"];
                string FLG_EMERGENCY = Request.Params["flg_emergency"] == "" ? "0" : Request.Params["flg_emergency"];


                DataModel model = new DataModel
                {
                    ID = ID,//key
                    ORDER_NUM = ORDER_NUM,//订单号
                    MODEL_TYPE = MODEL_TYPE,//型号
                    STOCK_NUM = STOCK_NUM,//库存数
                    STORAGE_NUM = STORAGE_NUM,//当日入库数
                    OUTBOUND_NUM = OUTBOUND_NUM,//当日出库数
                    SHORAGE_NUM = SHORAGE_NUM,//目前缺货数
                    PRODUCTION_NUM = PRODUCTION_NUM,//在产数量
                    PLAN_NUM = PLAN_NUM,//在途计划
                    FLG_DELIVERED = FLG_DELIVERED,//待产
                    FLG_FINISH = FLG_FINISH,//完成
                    FLG_EMERGENCY = FLG_EMERGENCY//紧急
                };

                //声明数据处理类,调用更新语句
                DataDeal dataDeal = new DataDeal();
                int i = dataDeal.Update(model);
                string Msgstr = "";
                if (i > 0 )
                {
                    Msgstr = "更新成功！";
                }
                else {
                    Msgstr = "更新失败！";
                }
                var result = new { IsSuccess = false, Msg = Msgstr };
                string s = new JavaScriptSerializer().Serialize(result);
                Response.Write(s);

            }
            catch (Exception)
            {
                var result = new { IsSuccess = false, Msg = "更新失败！" };
                string s = new JavaScriptSerializer().Serialize(result);
                Response.Write(s);
            }

        }
        #endregion

        #region 获取固定资产表内的相关数据
        private void GetQCData()
        {
            try
            {
                //声明数据处理类,调用查询语句
                DataDeal dataDeal = new DataDeal();
                DataTable dt = dataDeal.QCSelect();
                //页面展示的前台页面数据
                string[] Arr = { "ID", "QCNumber", "Status", "Type", "Class" };

                string s = Common.GetJsonString(dt.Rows.Count, 1, dt, Arr);

                Response.Write(s);
            }
            catch (Exception)
            {
                var result = new { IsSuccess = false, Msg = "查询失败！" };
                string s = new JavaScriptSerializer().Serialize(result);
                Response.Write(s);
            }

        }
        #endregion

        #region 删除固定资产相关数据
        private void DeleteQCData()
        {
            try
            {
                int ID = int.Parse(Request.Params["ID"]);

                //声明数据处理类,删除语句
                DataDeal dataDeal = new DataDeal();
                int i = dataDeal.QCDelete(ID);
                string Msgstr = "";
                if (i > 0)
                {
                    Msgstr = "删除成功！";
                }
                else
                {
                    Msgstr = "删除失败！";
                }
                var result = new { IsSuccess = false, Msg = Msgstr };
                string s = new JavaScriptSerializer().Serialize(result);
                Response.Write(s);

            }
            catch (Exception)
            {
                var result = new { IsSuccess = false, Msg = "删除失败！" };
                string s = new JavaScriptSerializer().Serialize(result);
                Response.Write(s);
            }

        }
        #endregion

        #region 插入固定资产相关数据
        private void InsertQCData()
        {
            try
            {
                string QCNumber = Request.Params["QCNumber"] == "" ? "0" : Request.Params["QCNumber"];
                string Status = Request.Params["Status"] == "" ? "0" : Request.Params["Status"];
                string Type = Request.Params["Type"] == "" ? "0" : Request.Params["Type"];
                string Class = Request.Params["Class"] == "" ? "0" : Request.Params["Class"];



                QCModel model = new QCModel
                {
                    QCNumber = QCNumber,//批号
                    Status = Status,//运行状态
                    Type = Type,//型号
                    Class = Class//种类
                };

                //声明数据处理类,调用插入语句
                DataDeal dataDeal = new DataDeal();
                int i = dataDeal.QCInsert(model);
                string Msgstr = "";
                if (i > 0)
                {
                    Msgstr = "插入成功！";
                }
                else
                {
                    Msgstr = "插入失败！";
                }
                var result = new { IsSuccess = false, Msg = Msgstr };
                string s = new JavaScriptSerializer().Serialize(result);
                Response.Write(s);

            }
            catch (Exception)
            {
                var result = new { IsSuccess = false, Msg = "插入失败！" };
                string s = new JavaScriptSerializer().Serialize(result);
                Response.Write(s);
            }

        }
        #endregion

        #region 更新固定资产相关数据
        private void UpdateQCData()
        {
            try
            {
                int ID = int.Parse(Request.Params["ID"]);

                string QCNumber = Request.Params["QCNumber"] == "" ? "0" : Request.Params["QCNumber"];
                string Status = Request.Params["Status"] == "" ? "0" : Request.Params["Status"];
                string Type = Request.Params["Type"] == "" ? "0" : Request.Params["Type"];
                string Class = Request.Params["Class"] == "" ? "0" : Request.Params["Class"];


                QCModel model = new QCModel
                {
                    ID = ID,//key
                    QCNumber = QCNumber,//批次号
                    Status = Status,//运行状态
                    Type = Type,//幸好你
                    Class = Class // 种类
                };

                //声明数据处理类,调用更新语句
                DataDeal dataDeal = new DataDeal();
                int i = dataDeal.QCUpdate(model);
                string Msgstr = "";
                if (i > 0)
                {
                    Msgstr = "更新成功！";
                }
                else
                {
                    Msgstr = "更新失败！";
                }
                var result = new { IsSuccess = false, Msg = Msgstr };
                string s = new JavaScriptSerializer().Serialize(result);
                Response.Write(s);

            }
            catch (Exception)
            {
                var result = new { IsSuccess = false, Msg = "更新失败！" };
                string s = new JavaScriptSerializer().Serialize(result);
                Response.Write(s);
            }

        }
        #endregion
    }
}