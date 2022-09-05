using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QCModel
    {
        #region ID
        private int id;
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        #endregion

        #region 批号
        private string qcnumber;
        public string QCNumber
        {
            set { qcnumber = value; }
            get { return qcnumber; }
        }
        #endregion


        #region 运行状态
        private string status;
        public string Status
        {
            set { status = value; }
            get { return status; }
        }
        #endregion


        #region 型号
        private string type;
        public string Type
        {
            set { type = value; }
            get { return type; }
        }
        #endregion


        #region 型号
        private string CLASS;
        public string Class
        {
            set { CLASS = value; }
            get { return CLASS; }
        }
        #endregion
    }
}
