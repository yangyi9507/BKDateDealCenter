using comm;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Text;

namespace BKDateDealCenter
{
    public class DataDeal
    {
        //连接串        
        readonly string connSting = ConfigurationManager.ConnectionStrings["SysConnectionString"].ConnectionString;

        string cmdText = "";

        #region 插入语句 暂时不启用
        public int Insert(Model.DataModel model) 
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("INSERT INTO test.DataDeal (");
            str.AppendLine("ORDER_NUM,");
            str.AppendLine("MODEL_TYPE,");
            str.AppendLine("STOCK_NUM,");
            str.AppendLine("STORAGE_NUM,");
            str.AppendLine("OUTBOUND_NUM,");
            str.AppendLine("SHORAGE_NUM,");
            str.AppendLine("PRODUCTION_NUM,");
            str.AppendLine("PLAN_NUM)");
            str.AppendLine("VALUES (");
            str.AppendLine("'" + model.ORDER_NUM + "',");
            str.AppendLine("'" + model.MODEL_TYPE + "',");
            str.AppendLine("'" + model.STOCK_NUM + "',");
            str.AppendLine("'" + model.STORAGE_NUM + "',");
            str.AppendLine("'" + model.OUTBOUND_NUM + "',");
            str.AppendLine("'" + model.SHORAGE_NUM + "',");
            str.AppendLine("'" + model.PRODUCTION_NUM + "',");
            str.AppendLine("'" + model.PLAN_NUM + "')");
            cmdText = str.ToString();

            MySqlConnection conn = comm.MySqlHelper.GetConnection(connSting);
            int i = comm.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText);
            return i;
        }
        #endregion

        #region 删除语句 暂时不启用
        public int Delete(int ID)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("DELETE FROM test.DataDeal ");
            str.AppendLine("WHERE id='"+ ID + "';");
            cmdText = str.ToString();
            MySqlConnection conn = comm.MySqlHelper.GetConnection(connSting);
            int val = comm.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText);
            return val;
        }
        #endregion

        #region 查询语句
        public DataTable Select()
        {
            StringBuilder str = new StringBuilder();      
            
            str.Append("SELECT * FROM test.DataDeal ;");            
            
            cmdText = str.ToString();
            
            DataTable dt = comm.MySqlHelper.GetDataTable(connSting, CommandType.Text, cmdText);
            return dt;
        }
        #endregion


        #region 更新语句
        public int Update(Model.DataModel model)
        {

            StringBuilder str = new StringBuilder();
            str.AppendLine("UPDATE test.DataDeal SET ");
            str.AppendLine("ORDER_NUM = '"+ model.ORDER_NUM + "', ");
            str.AppendLine("MODEL_TYPE='" + model.MODEL_TYPE + "', ");
            str.AppendLine("STOCK_NUM='" + model.STOCK_NUM + "', ");
            str.AppendLine("STORAGE_NUM='" + model.STORAGE_NUM + "', ");
            str.AppendLine("OUTBOUND_NUM='" + model.OUTBOUND_NUM + "', ");
            str.AppendLine("SHORAGE_NUM='" + model.SHORAGE_NUM + "', ");
            str.AppendLine("PRODUCTION_NUM='" + model.PRODUCTION_NUM + "',");
            str.AppendLine("PLAN_NUM='" + model.PLAN_NUM + "' ");
            str.AppendLine("WHERE ID='" + model.ID + "';");
            cmdText = str.ToString();

            MySqlConnection conn = comm.MySqlHelper.GetConnection(connSting);
            int i  = comm.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText);
            return i;
        }
        #endregion
    }
}