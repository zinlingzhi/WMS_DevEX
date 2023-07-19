using System;
using System.Collections.Generic;
using System.Text;
using Bruce.Jin.DAO;
using System.Data;

namespace StorageManageLibrary
{
    /// <summary>
    /// �ֿ�������
    /// </summary>
    public class DepotManage
    {
        ///<summary>
        /// ��������
        /// </summary>
        /// <param name="pObj">��Ϣ��ʵ����</param>
        /// <returns>���ر���ɹ�(true)��ʧ��(false)</returns>
        public bool Save(Depot pObj)
        {
            try
            {
                if (SaveStatus(pObj) == false)
                {
                    return pObj.Add();
                }
                else
                {

                    return pObj.Update();
                }
            }
            catch (Exception e)
            {
                throw e;

            }
        }


        ///<summary>
        /// �õ���ǰ������״̬�����޸�״̬
        /// </summary>
        /// <param name="pObj">��Ϣ��ʵ��</param>
        /// <returns>����True��False</returns>
        public bool SaveStatus(Depot pObj)
        {
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string pSql = "";
                pSql = "SELECT DepotGuid   FROM   Depot  " +
                    "where DepotGuid  ='" + pObj.DepotGuid + "'";
                DataTable pDT = pComm.ExeForDtl(pSql);
                pComm.Close();
                if (pDT.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

       /// <summary>
       /// �õ�����
       /// </summary>
       /// <returns></returns>
        public DataTable GetDepotData()
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select DepotGuid,DepotName as �ֿ�����,DepotPerson as  ������,Telephone as �绰,Remark as  ��ע from Depot ";
                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }


        /// <summary>
        /// �õ�����
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepotData2()
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select DepotGuid,DepotName as �ֿ�����,DepotPerson as  ������,Telephone as ���ֿ������ʾ˳��,Remark as  ���ֿ������ʾ from Depot  order by   convert(int,telephone) ";
                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }


        /// <summary>
        /// �õ�����
        /// </summary>
        /// <returns></returns>
        public DataTable GetStorageTypeData(string value)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select StorageTypeName from StorageType where flag='" + value + "'";
                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <returns></returns>
        public void DeleteDepot(string DepotGuid)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "delete  from Depot  where  DepotGuid='" + DepotGuid + "'";
                pObj_Comm.Execute(ps_Sql);

                pObj_Comm.Close();

               
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }
    }
}
