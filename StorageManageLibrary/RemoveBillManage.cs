using System;
using System.Collections.Generic;
using System.Text;
using Bruce.Jin.DAO;
using System.Data;

namespace StorageManageLibrary
{
    /// <summary>
    /// ��������������
    /// </summary>
    public class RemoveBillManage
    {
        ///<summary>
        /// ��������
        /// </summary>
        /// <param name="pObj">��Ϣ��ʵ����</param>
        /// <returns>���ر���ɹ�(true)��ʧ��(false)</returns>
        public void SaveRemoveBill(RemoveBill RemoveBill, List<RemoveBillDetail> RemoveBillDetail)
        {
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                pComm.BeginTrans();

                //���浥����������
                //��ɾ����������
                string strDeleteSql = "Delete from RemoveBill where  RemoveBillGuid='"+RemoveBill.RemoveBillGuid+"'";
                pComm.Execute(strDeleteSql);

                //������������
                string strInsertSql = GetAddRemoveBillSQL(RemoveBill);
                pComm.Execute(strInsertSql);


                //ɾ����ϸ��
                strDeleteSql = "Delete from RemoveBillDetail where  RemoveBillGuid='" + RemoveBill.RemoveBillGuid + "'";
                pComm.Execute(strDeleteSql);

                //������ϸ������
                for (int i = 0; i < RemoveBillDetail.Count; i++)
                {
                    strInsertSql = GetAddRemoveBillDetailSQL(RemoveBillDetail[i]);
                    pComm.Execute(strInsertSql);
                }


                pComm.CommitTrans();
            
            }
            catch (Exception e)
            {
                pComm.RollbackTrans();
                pComm.Close();
                throw e;

            }
        }




        /// <summary>
        /// �õ�����sql
        /// </summary>
        public string GetAddRemoveBillSQL(RemoveBill RemoveBill)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [RemoveBill](");
            strSql.Append("RemoveBillGuid,CreatePerson,CreateDate,CheckPerson,CheckDate,Remark,BillAutoID,BillDate,DepotOut,DepotIn,HandlePerson,BillID");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + RemoveBill.RemoveBillGuid + "',");
            strSql.Append("'" + RemoveBill.CreatePerson + "',");
            strSql.Append("'" + RemoveBill.CreateDate + "',");
            strSql.Append("'" + RemoveBill.CheckPerson + "',");
            if (RemoveBill.CheckDate == DateTime.Parse("1900-01-01"))
            {
                strSql.Append("null,");
            }
            else
            {
                strSql.Append("'" + RemoveBill.CheckDate + "',");
            }
          
            strSql.Append("'" + RemoveBill.Remark + "',");
            strSql.Append("'" + RemoveBill.BillAutoID + "',");
            strSql.Append("'" + RemoveBill.BillDate + "',");
            strSql.Append("'" + RemoveBill.DepotOut + "',");
            strSql.Append("'" + RemoveBill.DepotIn + "',");
            strSql.Append("'" + RemoveBill.HandlePerson + "',");
            strSql.Append("'" + RemoveBill.BillID + "'");
            strSql.Append(")");
            return strSql.ToString();
        }


        /// <summary>
        /// �õ�����һ����ϸ��SQL
        /// </summary>
        public string GetAddRemoveBillDetailSQL(RemoveBillDetail RemoveBillDetail)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [RemoveBillDetail](");
            strSql.Append("RemoveBillDetailGuid,Remark,RemoveBillGuid,MaterialGuid,MaterialID,MaterialName,BarNo,Spec,Unit,Price,Qty,Total");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + RemoveBillDetail.RemoveBillDetailGuid + "',");
            strSql.Append("'" + RemoveBillDetail.Remark + "',");
            strSql.Append("'" + RemoveBillDetail.RemoveBillGuid + "',");
            strSql.Append("'" + RemoveBillDetail.MaterialGuid + "',");
            strSql.Append("'" + RemoveBillDetail.MaterialID + "',");
            strSql.Append("'" + RemoveBillDetail.MaterialName + "',");
            strSql.Append("'" + RemoveBillDetail.BarNo + "',");
            strSql.Append("'" + RemoveBillDetail.Spec + "',");
            strSql.Append("'" + RemoveBillDetail.Unit + "',");
            strSql.Append("" + RemoveBillDetail.Price + ",");
            strSql.Append("" + RemoveBillDetail.Qty + ",");
            strSql.Append("" + RemoveBillDetail.Total + "");
            strSql.Append(")");
            return strSql.ToString();
        }


        /// <summary>
        /// �õ�����
        /// </summary>
        /// <returns></returns>
        public DataTable GetRemoveBillData()
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  RemoveBillGuid ,HandlePerson,CreatePerson,CreateDate,CheckPerson,CheckDate,Remark,BillAutoID,BillDate,DepotOut,DepotIn,BillID  from RemoveBill  order by CreateDate desc";
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
        public DataTable GetRemoveBillDetailData(string RemoveBillGuid)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  MaterialGuid,MaterialID,MaterialName,BarNo,Spec,Unit,Qty,Price,Total,Remark,(select ClassName from V_MaterialClass  where    MaterialGuid=RemoveBillDetail.MaterialGuid) as ClassName  from RemoveBillDetail where RemoveBillGuid='" + RemoveBillGuid + "' order by SortID";
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
        public DataTable GetRemoveBillData(string RemoveBillGuid)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  RemoveBillGuid ,HandlePerson,CreatePerson,CreateDate,CheckPerson,CheckDate,Remark,BillAutoID,BillDate,DepotOut,"
                              + "DepotIn,BillID  from RemoveBill where RemoveBillGuid='" + RemoveBillGuid + "'  order by CreateDate desc";
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
        /// �õ�����-������
        /// </summary>
        /// <returns></returns>
        public DataTable GetRemoveBillData_CN(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  RemoveBillGuid,BillAutoID as ���,BillID as  ����,BillDate as ҵ������,DepotOut as  �����ֿ�,DepotIn as  ����ֿ�,"
                   + "HandlePerson as ������, CreateDate as �Ƶ�ʱ��,CheckPerson as �����,CheckDate as  �������  from RemoveBill   " + strsql + " order by CreateDate desc";

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
        /// �õ�����-������
        /// </summary>
        /// <returns></returns>
        public DataTable GetRemoveBillData_CN()
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  RemoveBillGuid,BillAutoID as ���,BillID as  ����,BillDate as ҵ������,DepotOut as  �����ֿ�,DepotIn as  ����ֿ�,"
                   + "HandlePerson as ������, CreateDate as �Ƶ�ʱ��,CheckPerson as �����,CheckDate as  �������  from RemoveBill   order by CreateDate desc";

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
        public void DeleteRemoveBill(string RemoveBillGuid)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                pObj_Comm.BeginTrans();
                //ɾ������
                string ps_Sql = "delete  from RemoveBill  where  RemoveBillGuid='" + RemoveBillGuid + "'";
                pObj_Comm.Execute(ps_Sql);

                //ɾ����ϸ��
                ps_Sql = "delete  from RemoveBillDetail  where  RemoveBillGuid='" + RemoveBillGuid + "'";
                pObj_Comm.Execute(ps_Sql);

                pObj_Comm.CommitTrans();
                pObj_Comm.Close();


            }
            catch (Exception e)
            {
                pObj_Comm.RollbackTrans();
                pObj_Comm.Close();
                throw e;
            }
        }




        /// <summary>
        /// �������״̬��
        /// </summary>
        /// <returns></returns>
        public void ChcekRemoveBill(string RemoveBillGuid, int pass)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                 string ps_Sql ="";
                //ɾ������
                if (pass==1)
                {
                    //ͨ��
                    ps_Sql = "update  RemoveBill  set CheckPerson='" + SysParams.UserName + "',CheckDate='"+DateTime.Now.ToString()+"'  where  RemoveBillGuid='" + RemoveBillGuid + "'";
                
                }else
                {
                    //��ͨ��
                    ps_Sql = "update  RemoveBill  set CheckPerson='',CheckDate=null  where  RemoveBillGuid='" + RemoveBillGuid + "'";
                
                }
                
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
