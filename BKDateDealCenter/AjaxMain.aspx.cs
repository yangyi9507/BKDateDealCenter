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
                string[] Arr = {"ID", "ORDER_NUM", "MODEL_TYPE", "STOCK_NUM", "STORAGE_NUM", "OUTBOUND_NUM", "SHORAGE_NUM", "PRODUCTION_NUM", "PLAN_NUM"};

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
                    PLAN_NUM = PLAN_NUM//在途计划
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



    }
}