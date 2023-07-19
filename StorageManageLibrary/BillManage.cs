using System;
using System.Collections.Generic;
using System.Text;
using Bruce.Jin.DAO;
using System.Data;


namespace StorageManageLibrary
{
    /// <summary>
    /// ����ⵥ������
    /// </summary>
    public class BillManage
    {

        ///<summary>
        /// ��������
        /// </summary>
        /// <param name="pObj">��Ϣ��ʵ����</param>
        /// <returns>���ر���ɹ�(true)��ʧ��(false)</returns>
        public void SaveBill(Bill bill,List<BillDetail> billdetail)
        {
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                pComm.BeginTrans();

                //���浥����������
                //��ɾ����������
                string strDeleteSql = "Delete from Bill where  BillGuid='"+bill.BillGuid+"'";
                pComm.Execute(strDeleteSql);

                //������������
                string strInsertSql = GetAddBillSQL(bill);
                pComm.Execute(strInsertSql);


                //ɾ����ϸ��
                strDeleteSql = "Delete from BillDetail where  BillGuid='" + bill.BillGuid + "'";
                pComm.Execute(strDeleteSql);

                //������ϸ������
                for (int i = 0; i < billdetail.Count; i++)
                {
                    strInsertSql = GetAddBillDetailSQL(billdetail[i]);
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
        public string GetAddBillSQL(Bill bill)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Bill](");
            strSql.Append("BillGuid,BatchNo,CreatePerson,CreateDate,CheckPerson,CheckDate,Flag,Remark,BillAutoID,BillDate,DepotGuid,StorageTypeGuid,SupplierGuid,DeptGuid,HandlePerson,Bearing,BillID");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + bill.BillGuid + "',");
            strSql.Append("'" + bill.BatchNo + "',");
            strSql.Append("'" + bill.CreatePerson + "',");
            strSql.Append("'" + bill.CreateDate + "',");
            strSql.Append("'" + bill.CheckPerson + "',");
            if (bill.CheckDate == DateTime.Parse("1900-01-01"))
            {
                strSql.Append("null,");
            }
            else
            {
                strSql.Append("'" + bill.CheckDate + "',");
            }
            strSql.Append("'" + bill.Flag + "',");
            strSql.Append("'" + bill.Remark + "',");
            strSql.Append("'" + bill.BillAutoID + "',");
            strSql.Append("'" + bill.BillDate + "',");
            strSql.Append("'" + bill.DepotGuid + "',");
            strSql.Append("'" + bill.StorageTypeGuid + "',");
            strSql.Append("'" + bill.SupplierGuid + "',");
            strSql.Append("'" + bill.DeptGuid + "',");
            strSql.Append("'" + bill.HandlePerson + "',");
            strSql.Append("'" + bill.Bearing + "',");
            strSql.Append("'" + bill.BillID + "'");
            strSql.Append(")");
            return strSql.ToString();
        }


        /// <summary>
        /// �õ�����һ����ϸ��SQL
        /// </summary>
        public string GetAddBillDetailSQL(BillDetail billdetail )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [BillDetail](");
            strSql.Append("BillDetailGuid,Remark,BillGuid,MaterialGuid,MaterialID,MaterialName,BarNo,Spec,Unit,Price,Qty,Total");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + billdetail.BillDetailGuid + "',");
            strSql.Append("'" + billdetail.Remark + "',");
            strSql.Append("'" + billdetail.BillGuid + "',");
            strSql.Append("'" + billdetail.MaterialGuid + "',");
            strSql.Append("'" + billdetail.MaterialID + "',");
            strSql.Append("'" + billdetail.MaterialName + "',");
            strSql.Append("'" + billdetail.BarNo + "',");
            strSql.Append("'" + billdetail.Spec + "',");
            strSql.Append("'" + billdetail.Unit + "',");
            strSql.Append("" + billdetail.Price + ",");
            strSql.Append("" + billdetail.Qty + ",");
            strSql.Append("" + billdetail.Total + "");
            strSql.Append(")");
            return strSql.ToString();
        }


        /// <summary>
        /// �õ�����
        /// </summary>
        /// <returns></returns>
        public DataTable GetBillData()
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  BillGuid,BatchNo ,HandlePerson,CreatePerson,CreateDate,CheckPerson,CheckDate,Flag,Remark,BillAutoID,BillDate,DepotGuid,StorageTypeGuid,SupplierGuid,DeptGuid,Bearing,BillID  from Bill  order by CreateDate desc";
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
        public DataTable GetBillDetailData(string BillGuid)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  MaterialGuid,MaterialID,MaterialName,BarNo,Spec,Unit,Qty,Price,Total,Remark,(select ClassName from V_MaterialClass  where    MaterialGuid=BillDetail.MaterialGuid) as ClassName from BillDetail where BillGuid='" + BillGuid + "' order by SortID";
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
        public DataTable GetBillData(string billguid)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  BillGuid,BatchNo ,HandlePerson,CreatePerson,CreateDate,CheckPerson,CheckDate,Flag,Remark,BillAutoID,BillDate,DepotGuid,"
                              + "StorageTypeGuid,SupplierGuid,DeptGuid,Bearing,BillID  from Bill where BillGuid='" + billguid + "'  order by CreateDate desc";
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
        /// �õ�����--��ⵥ
        /// </summary>
        /// <returns></returns>
        public DataTable GetBillDataImport_CN()
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  BillGuid,BillAutoID as ���,BillID as  ����,BillDate as ҵ������,DepotGuid as  �������,Bearing as  ����,"
                   +"StorageTypeGuid as ����, DeptGuid as ����,SupplierGuid as ��Ӧ��,HandlePerson as ������,BatchNo as ����,CreatePerson as �Ƶ���, "
                    + "CreateDate as �Ƶ�ʱ��,CheckPerson as �����,CheckDate as  �������  from Bill  where flag='I' order by CreateDate desc";
              
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
        /// �õ�����--��ⵥ
        /// </summary>
        /// <returns></returns>
        public DataTable GetBillDataImport_CN(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  BillGuid,BillAutoID as ���,BillID as  ����,BillDate as ҵ������,DepotGuid as  �������,Bearing as  ����,"
                   + "StorageTypeGuid as ����, DeptGuid as ����,SupplierGuid as ��Ӧ��,HandlePerson as ������,BatchNo as ����,CreatePerson as �Ƶ���, "
                    + "CreateDate as �Ƶ�ʱ��,CheckPerson as �����,CheckDate as  �������  from Bill   " + strsql + " order by CreateDate desc";

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
        /// �õ�����--���ⵥ
        /// </summary>
        /// <returns></returns>
        public DataTable GetBillDataExport_CN()
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  BillGuid,BillAutoID as ���,BillID as  ����,BillDate as ҵ������,DepotGuid as  �������,Bearing as  ����,"
                   + "StorageTypeGuid as ����, DeptGuid as ����,SupplierGuid as �ͻ�,HandlePerson as ������,BatchNo as ����,CreatePerson as �Ƶ���, "
                    + "CreateDate as �Ƶ�ʱ��,CheckPerson as �����,CheckDate as  �������  from Bill  where flag='E' order by CreateDate desc";

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
        /// �õ�����-���ⵥ
        /// </summary>
        /// <returns></returns>
        public DataTable GetBillDataExport_CN(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  BillGuid,BillAutoID as ���,BillID as  ����,BillDate as ҵ������,DepotGuid as  �������,Bearing as  ����,"
                   + "StorageTypeGuid as ����, DeptGuid as ����,SupplierGuid as �ͻ�,HandlePerson as ������,BatchNo as ����,CreatePerson as �Ƶ���, "
                    + "CreateDate as �Ƶ�ʱ��,CheckPerson as �����,CheckDate as  �������  from Bill   " + strsql + " order by CreateDate desc";

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
        public void DeleteBill(string BillGuid)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                pObj_Comm.BeginTrans();
                //ɾ������
                string ps_Sql = "delete  from Bill  where  BillGuid='" + BillGuid + "'";
                pObj_Comm.Execute(ps_Sql);

                //ɾ����ϸ��
                ps_Sql = "delete  from BillDetail  where  BillGuid='" + BillGuid + "'";
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
        public void ChcekBill(string BillGuid,int pass )
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                 string ps_Sql ="";
                //ɾ������
                if (pass==1)
                {
                    //ͨ��
                    ps_Sql = "update  Bill  set CheckPerson='" + SysParams.UserName + "',CheckDate='"+DateTime.Now.ToString()+"'  where  BillGuid='" + BillGuid + "'";
                
                }else
                {
                    //��ͨ��
                    ps_Sql = "update  Bill  set CheckPerson='',CheckDate=null  where  BillGuid='" + BillGuid + "'";
                
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


        //----------------------------------------------����ⵥ��ϸ��ѯ----------------------------------
        /// <summary>
        /// �õ�����-��ⵥ
        /// </summary>
        /// <returns></returns>
        public DataTable GetInDepotDetailData(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  *  from  V_InDepotDetail   " + strsql + " order by BillDate";

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
        /// �õ�����-���ⵥ
        /// </summary>
        /// <returns></returns>
        public DataTable GetOutDepotDetailData(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  *  from  V_OutDepotDetail   " + strsql + " order by BillDate";

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

        //---------------------------------------------------------------------------------------


        //----------------------------------------------�������ܱ�--------------------------------
         /// <summary>
        /// �õ�����-�����ܱ�
        /// </summary>
        /// <returns></returns>
        public DataTable GetInDepotSumData(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "   select  InterName,MaterialName,Spec,Unit,sum(Qty) as Qty,sum(Total) as Total,count(*) as billcount "
                               + "  from  dbo.V_InDepotDetail " + strsql + " group by InterName,MaterialName,Spec,Unit"
                               + "    order by InterName  ";

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
        /// �õ�����-������ܱ�
        /// </summary>
        /// <returns></returns>
        public DataTable GetOutDepotSumData(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "   select  InterName,MaterialName,Spec,Unit,sum(Qty) as Qty,sum(Total) as Total,count(*) as billcount "
                               + "  from  dbo.V_OutDepotDetail " + strsql + " group by InterName,MaterialName,Spec,Unit"
                               + "    order by InterName  ";

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
        //-------------------------------------------------------------------------------------------------

       /// <summary>
        /// �õ�����-����ѯ(��������⣬����)
       /// </summary>
       /// <param name="strsql">��ѯ�����ֿ�</param>
       /// <param name="strsql2">��ѯ��������</param>
       /// <param name="depot">�ֿ���</param>
       /// <returns></returns>
        public DataTable sp_GetDepotMaterailSum(string strsql1, string strsql2, string strsql3, string depot, string strsql4, string strsql5)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataSet dset = new DataSet();
                string[,] par;
                par = new string[6, 2];
                par[0, 0] = "@WhereSql";
                par[0, 1] = strsql1;
                par[1, 0] = "@WhereSql2";
                par[1, 1] = strsql2;
                par[2, 0] = "@WhereSql3";
                par[2, 1] = strsql3;
                par[3, 0] = "@Depot";
                par[3, 1] = depot;
                par[4, 0] = "@WhereSql4";
                par[4, 1] = strsql4;
                par[5, 0] = "@WhereSql5";
                par[5, 1] = strsql5;

                dset = pComm.ExcuteSp("sp_GetDepotDetailSum", par);

                pComm.Close();
                return dset.Tables[0];
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }


        /// <summary>
        /// �õ�����-�շ�����ܱ�(��������⣬����)
        /// </summary>
        /// <param name="strsql">��ѯ�����ֿ�</param>
        /// <param name="strsql2">��ѯ��������</param>
        /// <param name="depot">�ֿ���</param>
        /// <returns></returns>
        public DataTable sp_GetDepotClassDetailSum(string BeginDate, string EndDate, string Depot, string BarNo,
                                                   string MaterialID,string MaterialName,string Spec,string Classid)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataSet dset = new DataSet();
                string[,] par;
                par = new string[8, 2];
                par[0, 0] = "@BeginDate";
                par[0, 1] = BeginDate;
                par[1, 0] = "@EndDate";
                par[1, 1] = EndDate;
                par[2, 0] = "@Depot";
                par[2, 1] = Depot;
                par[3, 0] = "@BarNo";
                par[3, 1] = BarNo;
                par[4, 0] = "@MaterialID";
                par[4, 1] = MaterialID;
                par[5, 0] = "@MaterialName";
                par[5, 1] = MaterialName;
                par[6, 0] = "@Spec";
                par[6, 1] = Spec;
                par[7, 0] = "@ClassID";
                par[7, 1] = Classid;
                dset = pComm.ExcuteSp("sp_GetDepotClassDetailSum", par);

                pComm.Close();
                return dset.Tables[0];
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }



        /// <summary>
        /// �õ�����-�շ����ͻ��ܱ�(��������⣬����)
        /// </summary>
        /// <param name="strsql">��ѯ�����ֿ�</param>
        /// <param name="strsql2">��ѯ��������</param>
        /// <param name="depot">�ֿ���</param>
        /// <returns></returns>
        public DataTable sp_GetDepotClassTypeDetailSum(string BeginDate, string EndDate, string Depot, string BarNo,
                                                   string MaterialID, string MaterialName, string Spec, string Classid)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataSet dset = new DataSet();
                string[,] par;
                par = new string[8, 2];
                par[0, 0] = "@BeginDate";
                par[0, 1] = BeginDate;
                par[1, 0] = "@EndDate";
                par[1, 1] = EndDate;
                par[2, 0] = "@Depot";
                par[2, 1] = Depot;
                par[3, 0] = "@BarNo";
                par[3, 1] = BarNo;
                par[4, 0] = "@MaterialID";
                par[4, 1] = MaterialID;
                par[5, 0] = "@MaterialName";
                par[5, 1] = MaterialName;
                par[6, 0] = "@Spec";
                par[6, 1] = Spec;
                par[7, 0] = "@ClassID";
                par[7, 1] = Classid;
                dset = pComm.ExcuteSp("sp_GetDepotClassTypeDetailSum", par);

                pComm.Close();
                return dset.Tables[0];
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }


        //----------------------------�ֿ��շ���ϸ�벿���շ���ϸ--------------------------------
        /// <summary>
        /// �õ�����-�ֿ��շ���ϸ��
        /// </summary>
        /// <returns></returns>
        public DataTable GetInOutDepotDetailData(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  *  from  V_ALLDepotDetail   " + strsql + " order by BillDate";

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
        /// �õ�����-�����ϸ��
        /// </summary>
        /// <returns></returns>
        public DataTable sp_GetDepotMaterialDetailSum(string Depot,string MaterialID)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataSet dset = new DataSet();
                string[,] par;
                par = new string[2, 2];
                par[0, 0] = "@Depot";
                par[0, 1] = Depot;
                par[1, 0] = "@MaterialID";
                par[1, 1] = MaterialID;
                dset = pComm.ExcuteSp("sp_GetDepotMaterialDetailSum", par);

                pComm.Close();
                return dset.Tables[0];
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

        /// <summary>
        /// �õ�ĳ���ϼ������вֿ��еĿ������
        /// </summary>
        /// <returns></returns>
        public DataTable sp_GetMaterialSumByDepot(string MaterialGuID)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataSet dset = new DataSet();
                string[,] par;
                par = new string[1, 2];
                par[0, 0] = "@MaterialGuID";
                par[0, 1] = MaterialGuID;
                dset = pComm.ExcuteSp("sp_GetMaterialSumByDepot", par);

                pComm.Close();
                return dset.Tables[0];
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

        /// <summary>
        /// �õ�ĳ���ϼ���ƽ������
        /// </summary>
        /// <returns></returns>
        public decimal sp_GetMaterialPrice(string MaterialGuID,string Depot)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                decimal price=0;
                DataSet dset = new DataSet();
                string[,] par;
                par = new string[1, 2];
                par[0, 0] = "@MaterialGuID";
                par[0, 1] = MaterialGuID;
                dset = pComm.ExcuteSp("sp_GetMaterialSumByDepot", par);

                pComm.Close();

                if (dset.Tables[0].Rows.Count>0)
                {
                    DataRow[] drArr=dset.Tables[0].Select("DepotName='"+Depot+"'");
                    if (drArr.Length > 0)
                    {
                        DataRow dr=drArr[0];
                        price = decimal.Parse(dr[2].ToString());
                    }
                   
                }

                return price;
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }


        /// <summary>
        /// �õ�����-���ֿ���ܱ�
        /// </summary>
        /// <returns></returns>
        public DataTable sp_GetAllDepotSum(string MaterialGuid, string begindate, string enddate)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataSet dset = new DataSet();
                string[,] par;
                par = new string[3, 2];
                par[0, 0] = "@MaterialGuid";
                par[0, 1] = MaterialGuid;
                par[1, 0] = "@BeginDate";
                par[1, 1] = begindate;
                par[2, 0] = "@EndDate";
                par[2, 1] = enddate;
                dset = pComm.ExcuteSp("sp_GetAllDepotSum", par);

                pComm.Close();
                return dset.Tables[0];
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

     
    }
}
