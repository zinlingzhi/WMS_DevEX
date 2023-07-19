using System;
using System.Collections.Generic;
using System.Text;
using Bruce.Jin.DAO;
using System.Data;
namespace StorageManageLibrary
{
    /// <summary>
    /// �������������
    /// </summary>
    public class StorageClassManage
    {
        /// <summary>
        /// �������з�����Ϣ
        /// </summary>
        /// <returns>pDTMain ��Ʒ��Ϣ��</returns>
        public string GetMaxNodeData(string fatherid)
        {
            string ps_Sql = "";
            DataTable pDTMain = new DataTable();
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                ps_Sql = "SELECT Max(InterID) as InterID FROM StorageClass where FatherID ='" + fatherid + "'";
                pDTMain = pObj_Comm.ExeForDtl(ps_Sql);
                pObj_Comm.Close();

                if (pDTMain.Rows[0]["InterID"].ToString() == "")
                {
                    return fatherid + "0001";
                }
                else
                {
                    return pDTMain.Rows[0]["InterID"].ToString();
                }
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public void InsertTypeNode(string strInterID, string InterName, string strFatherID)
        {
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);

            try
            {


                string StrSQL = "";
                StrSQL = "insert into  StorageClass(InterID,InterName,FatherID) values('" + strInterID + "','" + InterName + "','" + strFatherID + "')";

                pComm.Execute(StrSQL);

                pComm.Close();


            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }



        ///<summary>
        /// ɾ����������
        /// </summary>
        public void DeleteNodeData(string interid)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {

                string StrSQL = " delete from StorageClass where InterID ='" + interid + "'";

                pComm.Execute(StrSQL);
                pComm.Close();


            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

        /// <summary>
        /// �õ����в�Ʒ������Ϣ
        /// </summary>
        /// <returns>pDTMain �ֶ���Ϣ��</returns>
        public DataTable GetStorageClassData()
        {
            string ps_Sql = "";
            DataTable pDTMain = new DataTable();
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                ps_Sql = "select * from StorageClass ";
                pDTMain = pObj_Comm.ExeForDtl(ps_Sql);


                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }
    }
}
