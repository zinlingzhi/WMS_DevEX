using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bruce.Jin.DAO;

namespace StorageManageLibrary
{
    /// <summary>
    /// ��������ά��
    /// </summary>
    public class BasicDataManage
    {

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="Flag">(1-��λ 2-��� 3:��װ 4:�Ƽ۷�)</param>
        /// <returns></returns>
        public DataTable GetBasicData(int Flag)
        {
          
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  UnitName  from BasicData where  flag=" + Flag.ToString() + " order by UnitID";
                DataTable  pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

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
        /// �����������
        /// </summary>
        /// <param name="Flag">(1-��λ 2-��� 3:��װ 4:�Ƽ۷�)</param>
        /// <returns></returns>
        public DataTable GetBasicData2(int Flag)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  UnitID,UnitName  from BasicData where  flag=" + Flag.ToString() + " order by UnitID";
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

        ///<summary>
        /// ��������
        /// </summary>
        /// <param name="pObj">��Ϣ��ʵ����</param>
        /// <returns>���ر���ɹ�(true)��ʧ��(false)</returns>
        public bool Save(BasicData pObj)
        {
            try
            {
               return pObj.Add();
               
            }
            catch (Exception e)
            {
                throw e;

            }
        }


        ///<summary>
        /// �����������ؽ����ѯ
        /// </summary>
        /// <param name="tableid">SQL��ѯ����</param>
        /// <returns>��Ų�ѯ�����DataTable</returns>
        public bool DeleteBasicData(string UnitID)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {

                string StrSQL = "delete from  BasicData  where UnitID=" + UnitID;

                pComm.Execute(StrSQL);
                pComm.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }

    }
}
