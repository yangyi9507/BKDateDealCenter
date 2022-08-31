using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace comm
{
    public class Common
    {
        #region 获取json
        /// <summary>
        /// 获取json
        /// </summary>
        /// <param name="iTotalCount">总数</param>
        /// <param name="iPageIndex">当前页索引</param>
        /// <param name="_dt">数据集</param>
        /// <param name="strField">要显示的字段名称</param>
        /// <returns></returns>
        public static string GetJsonString(int iTotalCount,int pageIndex, DataTable _dt, string[] strField)
        {
            try
            {
                StringBuilder _strbld = new StringBuilder();
                _strbld.Append("{\"Rows\":[");

                if (_dt != null)
                {
                    for (int i = 0; i < _dt.Rows.Count; i++)
                    {
                        _strbld.Append("{");
                        if (strField != null)
                        {
                            for (int j = 0; j < strField.Length; j++)
                            {
                                if (j != strField.Length - 1)
                                    _strbld.Append("\"" + strField[j] + "\":\"" + AddSlashes(_dt.Rows[i][strField[j]].ToString().Replace('"', '“')) + "\",");
                                else
                                    _strbld.Append("\"" + strField[j] + "\":\"" + AddSlashes(_dt.Rows[i][strField[j]].ToString().Replace('"', '“')) + "\"");
                            }
                        }

                        if (i != _dt.Rows.Count - 1)
                            _strbld.Append("},");
                        else
                            _strbld.Append("}");

                    }
                }
                _strbld.Append("],\"Total\":" + iTotalCount + "}");

                return _strbld.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// Returns a string with backslashes before characters that need to be quoted
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string AddSlashes(string s)
        {
            s = s.Replace("\\", "\\\\");
            string Result = s;
            try
            {
                Result = System.Text.RegularExpressions.Regex.Replace(s, @"[\000\010\011\012\015\032\047\140]", "");
            }
            catch (Exception)
            {

            }
            return Result;

        }
    }
}