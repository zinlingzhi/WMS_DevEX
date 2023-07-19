using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bruce.Jin.DAO;

namespace StorageManageLibrary
{
    /// <summary>
    /// ����ѡ��ά��
    /// </summary>
    public class BasicData
    {

        #region Model
        private string _unitname;
        private int _flag;
        /// <summary>
        /// ������λ����
        /// </summary>
        public string UnitName
        {
            set { _unitname = value; }
            get { return _unitname; }
        }
        /// <summary>
        /// �����������(1-��λ 2-��� 3:��װ 4:�Ƽ۷�)
        /// </summary>
        public int flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        #endregion Model

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [BasicData](");
            strSql.Append("UnitName,flag");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + UnitName + "',");
            strSql.Append("" + flag + "");
            strSql.Append(")");
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);

            try
            {
                pComm.Execute(strSql.ToString());//ִ��Sql����޷���ֵ
                pComm.Close();
                return true;
            }
            catch (System.Exception e)
            {
                pComm.Close();
                throw e;
            }		
           
           
        }
    }
}
