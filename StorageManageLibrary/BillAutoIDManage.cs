using System;
using System.Collections.Generic;
using System.Text;
using Bruce.Jin.DAO;
using System.Data;

namespace StorageManageLibrary
{
    /// <summary>
    /// �Զ����
    /// </summary>
    public class BillAutoIDManage
    {
        ///<summary>
        /// �����������ؽ����ѯ
        /// </summary>
        /// <param name="tableid">SQL��ѯ����</param>
        /// <returns>��Ų�ѯ�����DataTable</returns>
        public int GetBillAutoId(string flag)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataTable dtl = new DataTable();
                string StrSQL = " select BillAutoID from BillAutoID  where  Flag='" + flag + "'";

                dtl = pComm.ExeForDtl(StrSQL);
                pComm.Close();
                return int.Parse(dtl.Rows[0]["BillAutoID"].ToString());
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }


        ///<summary>
        /// �����������ؽ����ѯ
        /// </summary>
        /// <param name="tableid">SQL��ѯ����</param>
        /// <returns>��Ų�ѯ�����DataTable</returns>
        public int GetAutoIDAdd(string flag)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                //����ȱ��������
                string StrSQL = "update  BillAutoID  set BillAutoID=BillAutoID+1  where flag='" + flag + "'";
                pComm.Execute(StrSQL);

                //�õ�������ĺ�
                DataTable dtl = new DataTable();
                StrSQL = " select BillAutoID from BillAutoID  where  flag='" + flag + "'";
                dtl = pComm.ExeForDtl(StrSQL);
                pComm.Close();

                return int.Parse(dtl.Rows[0]["BillAutoID"].ToString());

               

            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

    }
}
