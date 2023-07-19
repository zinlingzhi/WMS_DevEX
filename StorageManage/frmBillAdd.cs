using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using StorageManageLibrary;

namespace StorageManage
{
    /// <summary>
    /// ��������
    /// </summary>
    public partial class frmBillAdd : frmBase
    {
        MaterialManage MaterialManage = new MaterialManage();
        BillManage bm = new BillManage();
        BillAutoIDManage BillAutoIDManage = new BillAutoIDManage();
        DataSet ds = new DataSet();
        public int SendFlag = 0;//1���Ǵ������ϸ��������  0: �ӳ���ⵥ������
        public frmBillAdd()
        {
            InitializeComponent();
        }

     
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            frmSelectMaterial frmSelectMaterial = new frmSelectMaterial();
            frmSelectMaterial.Tag = "";
            frmSelectMaterial.ShowDialog();

            //ѡ����ϼ����
            if (frmSelectMaterial.Tag.ToString() != "")
            { 
                 //�õ�ѡ����ϼ�guid��Ȼ��õ�
                Material material= MaterialManage.GetMaterialByGuid(frmSelectMaterial.Tag.ToString());
               
                //�������
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue(gridMaterialGuid, material.MaterialGuid);
                gridView1.SetFocusedRowCellValue(gridMaterialID, material.MaterialId);
                gridView1.SetFocusedRowCellValue(gridMaterialName, material.MaterialName);
                gridView1.SetFocusedRowCellValue(gridClassName, material.ClassId);
                gridView1.SetFocusedRowCellValue(gridBarNo, material.BarNo);
                gridView1.SetFocusedRowCellValue(gridSpec , material.Spec);
                gridView1.SetFocusedRowCellValue(gridUnit, material.Unit);
                gridView1.SetFocusedRowCellValue(gridRemark , material.Remark);

                //���ⵥ��Ʒ�Ƿ��Զ�����ƽ������
                if (this.Text == "���ⵥ����" || this.Text == "���ⵥ�༭")
                {
                    string AutoFillBillOutPrice = System.Configuration.ConfigurationSettings.AppSettings["IsAutoFillBillOutPrice"].ToString(); ;
                    if (AutoFillBillOutPrice == "true")
                    {
                        decimal priceAVG = 0;
                        string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();
                        //�õ����ϼ���ĳ���ֿ��е�ƽ����,д�뵥������
                        priceAVG = bm.sp_GetMaterialPrice(guid, cboDepot.Text);
                        gridView1.SetFocusedRowCellValue(gridPrice, priceAVG);
                    }
                }
            }
        }

        //����
        public  void BillAdd(string flag,IWin32Window ifrm)
        {
            txtGuid.Text = Guid.NewGuid().ToString();
            txtAutoBillID.Text = GetAutoId(flag);
            txtCreateDate.Text = DateTime.Now.ToString();
            txtCreatePerson.Text = SysParams.UserName;

            this.Tag = flag;// flag ��I:��ⵥ E�����ⵥ
            if (flag == "I")
            {
                //���
                cboBearing.Items.Clear();
                cboBearing.Items.Add("");
                cboBearing.Items.Add("�ջ�");
                cboBearing.Items.Add("�˻�");
                this.Text = "��ⵥ����";
                label5.Text = "��Ӧ��";
               

                CboBind("I");

                cboStorageType.Text = "ԭ�ϲɹ����";
            }
            else
            {
                //����
                cboBearing.Items.Clear();
                cboBearing.Items.Add("");
                cboBearing.Items.Add("����");
                cboBearing.Items.Add("�˻�");
                this.Text = "���ⵥ����";
                label5.Text = "�ͻ�";
               

                CboBind("E");

                cboStorageType.Text = "���۷�������";
                cboDepot.Text = "�ֿ�";

                

                
            }

            //���󲻿���,��˿���
            tsbCheckNoPass.Enabled = false;
            tsbCheckPass.Enabled = false;
           
         
            
            this.gridControl1.DataSource = IniBindTable();
            gridMaterialGuid.Visible = false;


            this.Show(ifrm);
        }



        //�޸�
        public void BillEdit(string billguid,string flag,IWin32Window ifrm)
        {
            txtGuid.Text = billguid;

            if (flag == "I")
            {
                //���
                cboBearing.Items.Clear();
                cboBearing.Items.Add("");
                cboBearing.Items.Add("�ջ�");
                cboBearing.Items.Add("�˻�");
                this.Text = "��ⵥ�༭";
                label5.Text = "��Ӧ��";

                //����ѡ����
                CboBind("I");
            }
            else
            {
                //����
                cboBearing.Items.Clear();
                cboBearing.Items.Add("");
                cboBearing.Items.Add("����");
                cboBearing.Items.Add("�˻�");
                this.Text = "���ⵥ�༭";
                label5.Text = "�ͻ�";

                //����ѡ����
                CboBind("E");

                cboDepot.Text = "�ֿ�";

            
            }


           
        

            //�õ���������
            DataTable dtl = bm.GetBillData(txtGuid.Text);
            txtGuid.Text = dtl.Rows[0]["billGuid"].ToString();
            dateTimePicker1.Text = dtl.Rows[0]["BillDate"].ToString();
            txtBillID.Text = dtl.Rows[0]["BillDate"].ToString();
            txtBatchNo.Text = dtl.Rows[0]["BatchNo"].ToString();
            cboDepot.Text = dtl.Rows[0]["DepotGuid"].ToString();
            cboDept.Text = dtl.Rows[0]["DeptGuid"].ToString();
            txtRemark.Text = dtl.Rows[0]["Remark"].ToString();
            cboSupplier.Text = dtl.Rows[0]["SupplierGuid"].ToString();
            cboStorageType.Text = dtl.Rows[0]["StorageTypeGuid"].ToString();
            cboBearing.Text = dtl.Rows[0]["Bearing"].ToString();
            cboHandlePerson.Text = dtl.Rows[0]["HandlePerson"].ToString();
            txtAutoBillID.Text = dtl.Rows[0]["BillAutoID"].ToString();
            txtBillID.Text = dtl.Rows[0]["BillID"].ToString();
            this.Tag = flag;// flag ��I:��ⵥ E�����ⵥ

            txtCreateDate.Text = dtl.Rows[0]["CreateDate"].ToString();
            txtCreatePerson.Text = dtl.Rows[0]["CreatePerson"].ToString();
            if (dtl.Rows[0]["CheckDate"].ToString().Contains("1900-01-01")==false)
            {
                txtCheckDate.Text = dtl.Rows[0]["CheckDate"].ToString();
            }
            else
            {
                txtCheckDate.Text = "";
            }
            txtCheckPerson.Text = dtl.Rows[0]["CheckPerson"].ToString();

            if (dtl.Rows[0]["CheckPerson"].ToString() != "")
            {
                //����Ϊ�������
                SetControlEnable(1);
            }
            else
            {
                //����Ϊ��û�����
                SetControlEnable(0);
            }
           
            //�õ���ϸ������
            DataTable dtlDetail = bm.GetBillDetailData(txtGuid.Text);
            this.gridControl1.DataSource = dtlDetail;
            gridMaterialGuid.Visible = false;
            gridMaterialID.Visible = false;

            ds.Tables.Add(dtl.Copy());
            ds.Tables[0].TableName = "dtlBill";
            ds.Tables.Add(dtlDetail.Copy());
            ds.Tables[1].TableName = "dtlBillDetail";


            this.Show(ifrm);
        }

        private void CboBind(string flag)
        { 
            //�󶨲ֿ�
            DepotManage DepotManage = new DepotManage();
            DataTable dtl = DepotManage.GetDepotData();
            cboDepot.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboDepot.Items.Add(dtl.Rows[i]["�ֿ�����"].ToString());
            }
           
            
            //������
            dtl = DepotManage.GetStorageTypeData(flag);
            cboStorageType.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboStorageType.Items.Add(dtl.Rows[i]["StorageTypeName"].ToString());
            }


            //�󶨲���
            DeptManage DeptManage = new DeptManage();
            dtl = DeptManage.GetDeptData();
            cboDept.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboDept.Items.Add(dtl.Rows[i]["��������"].ToString());
            }


            //�󶨾�����
            EmployeeManage EmployeeManage = new EmployeeManage();
            dtl = EmployeeManage.GetEmployeeData();
            cboHandlePerson.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboHandlePerson.Items.Add(dtl.Rows[i]["Ա������"].ToString());
            }

            //�󶨹�Ӧ��
            if (flag == "I")
            {
                SupplierManage SupplierManage = new SupplierManage();
                dtl = SupplierManage.GetSupplierData();
                cboSupplier.Items.Add("");
                for (int i = 0; i < dtl.Rows.Count; i++)
                {
                    cboSupplier.Items.Add(dtl.Rows[i]["��Ӧ������"].ToString());
                }
            }
            else
            {
                ClientManage ClientManage = new ClientManage();
                dtl = ClientManage.GetClientData();
                cboSupplier.Items.Add("");
                for (int i = 0; i < dtl.Rows.Count; i++)
                {
                    cboSupplier.Items.Add(dtl.Rows[i]["�ͻ�����"].ToString());
                }
            }


        
        }



        //��ʼ�����
        private DataTable IniBindTable()
        {
            DataTable _dt = new DataTable();
            DataColumn _datacol1 = new DataColumn("MaterialGuid");
            DataColumn _datacol2 = new DataColumn("MaterialID");
            DataColumn _datacol3 = new DataColumn("MaterialName");
            DataColumn _datacol4 = new DataColumn("BarNo");
            DataColumn _datacol5 = new DataColumn("Spec");
            DataColumn _datacol6 = new DataColumn("Unit");
            DataColumn _datacol7 = new DataColumn("Qty");
            DataColumn _datacol8 = new DataColumn("Price");
            DataColumn _datacol9 = new DataColumn("Total");
            DataColumn _datacol10 = new DataColumn("Remark");
            DataColumn _datacol11 = new DataColumn("ClassName");

            _dt.Columns.Add(_datacol1);
            _dt.Columns.Add(_datacol2);
            _dt.Columns.Add(_datacol3);
            _dt.Columns.Add(_datacol4);
            _dt.Columns.Add(_datacol5);
            _dt.Columns.Add(_datacol6);
            _dt.Columns.Add(_datacol7);
            _dt.Columns.Add(_datacol8);
            _dt.Columns.Add(_datacol9);
            _dt.Columns.Add(_datacol10);
            _dt.Columns.Add(_datacol11);

            return _dt;

        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelDetail_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "gridTotal" && e.Column.Name != "gridMaterialGuid" && e.Column.Name != "gridMaterialName"
                && e.Column.Name != "gridSpec" && e.Column.Name != "gridUnit" && e.Column.Name != "gridRemark" && e.Column.Name != "gridClassName"
                )
            {

                decimal number = 0;
                decimal price = 0;
                if (gridView1.GetFocusedRowCellValue("Price").ToString() != "")
                {
                    price = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("Price").ToString());
                }
                if (gridView1.GetFocusedRowCellValue("Qty").ToString() != "")
                {
                    number = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("Qty").ToString());
                }

                decimal total = price * number;
                total = decimal.Parse(total.ToString("0.000000"));
                gridView1.SetFocusedRowCellValue(gridTotal, total);
                //gridView1.SetRowCellValue(e.RowHandle, gridTotal, total);

            }

        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();
                frmDepotMaterialStatusQty fdms = new frmDepotMaterialStatusQty();
                fdms.ShowData(guid,this);
               
            }
           
        }

        //����
        private void tsbSave_Click(object sender, EventArgs e)
        {
            gridView1.UpdateCurrentRow();

            if (cboDepot.Text == "")
            {
                this.ShowAlertMessage("����ѡ��ֿ�!");
                return;
            }

            if (cboStorageType.Text== "")
            {
                this.ShowAlertMessage("����ѡ������!");
                return;
            }

            if (this.Tag.ToString() == "I")
            {
                //if (cboSupplier.Text == "")
                //{
                //    this.ShowAlertMessage("����ѡ��Ӧ��!");
                //    return;
                //}
            }
            else
            {
                if (cboSupplier.Text == "")
                {
                    this.ShowAlertMessage("����ѡ��ͻ�!");
                    return;
                }
            }

            //if (cboDept.Text == "")
            //{
            //    this.ShowAlertMessage("����ѡ����!");
            //    return;
            //}

            //if (cboBearing.Text == "")
            //{
            //    this.ShowAlertMessage("����ѡ����!");
            //    return;
            //}

            if (cboHandlePerson.Text == "")
            {
                this.ShowAlertMessage("����ѡ������!");
                return;
            }

            if (gridView1.RowCount <= 0)
            {
                this.ShowAlertMessage("�������ӻ�Ʒ��ϸ����!");
                return;
            }



            Bill Bill = new Bill();
            Bill.BillGuid = txtGuid.Text;
            Bill.BillDate =DateTime.Parse(dateTimePicker1.Text);
            Bill.BillID = txtBillID.Text;
            Bill.BatchNo = txtBatchNo.Text;
            Bill.DepotGuid = cboDepot.Text;
            Bill.DeptGuid = cboDept.Text;
            Bill.SupplierGuid =cboSupplier.Text;
            Bill.StorageTypeGuid = cboStorageType.Text;
            Bill.Flag = this.Tag.ToString();
            Bill.Bearing = cboBearing.Text;
            if (txtCreateDate.Text.Trim() == "")
            {
                Bill.CreateDate = DateTime.Now;
            }
            else
            {
                Bill.CreateDate = DateTime.Parse(txtCreateDate.Text);
            }
            Bill.CreatePerson = SysParams.UserName;
            Bill.CheckDate = DateTime.Parse("1900-01-01");
            Bill.CheckPerson = "";
            Bill.Remark = txtRemark.Text;
            Bill.BillAutoID = txtAutoBillID.Text;
            Bill.HandlePerson = cboHandlePerson.Text;
         

            List<BillDetail> list = new List<BillDetail>();
            BillDetail BillDetail = new BillDetail();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRowView dr = (DataRowView)(gridView1.GetRow(i));

                BillDetail = new BillDetail();
                BillDetail.BillDetailGuid = Guid.NewGuid().ToString();
                BillDetail.BillGuid = Bill.BillGuid;

                BillDetail.MaterialGuid =dr[0].ToString(); //gridView1.GetRowCellValue(i, gridMaterialGuid).ToString();
                BillDetail.MaterialID = dr[1].ToString(); //gridView1.GetRowCellValue(i, gridMaterialGuid).ToString();
                BillDetail.MaterialName = dr[2].ToString();  //gridView1.GetRowCellValue(i, gridMaterialName).ToString();
                BillDetail.BarNo = dr[3].ToString();  //gridView1.GetRowCellValue(i, gridMaterialName).ToString();
                BillDetail.Spec = dr[4].ToString();// gridView1.GetRowCellValue(i, gridSpec).ToString();
                BillDetail.Unit = dr[5].ToString();//gridView1.GetRowCellValue(i, gridUnit).ToString();
                if (dr[6].ToString().Trim() != "")
                {
                    BillDetail.Qty = decimal.Parse(dr[6].ToString());//int.Parse(gridView1.GetRowCellValue(i, gridQty).ToString());
                }
                else
                {
                    BillDetail.Qty = 0;
                }

                if (dr[7].ToString().Trim() != "")
                {
                    BillDetail.Price = decimal.Parse(dr[7].ToString()); //decimal.Parse(gridView1.GetRowCellValue(i, gridPrice).ToString());

                }
                else
                {
                    BillDetail.Price = 0;
                }

                if (dr[8].ToString().Trim() != "")
                {
                    BillDetail.Total = decimal.Parse(dr[8].ToString()); //decimal.Parse(gridView1.GetRowCellValue(i, gridTotal ).ToString());
                }
                else
                {
                    BillDetail.Total = 0;
                }

                BillDetail.Remark = dr[9].ToString();//gridView1.GetRowCellValue(i, gridRemark).ToString();
                list.Add(BillDetail);

            }

            //����
            bm.SaveBill(Bill, list);

            // ���sendflag����1���Ǵ������ϸ��ѯ�н��뱾���ڣ�����ˢ�¸�����
            if (SendFlag == 0)
            {
                if (this.Tag.ToString() == "I")
                {
                    frmBill.frmbill.LoadBill();
                }
                else if (this.Tag.ToString() == "E")
                {
                    frmBillE.frmbille.LoadBill();
                }
            }

            tsbCheckPass.Enabled = true;

            //�õ���ϸ������
            DataTable dtl = bm.GetBillData(txtGuid.Text);
            DataTable dtlDetail = bm.GetBillDetailData(txtGuid.Text);
            this.gridControl1.DataSource = dtlDetail;

            ds.Tables.Clear();
            ds.Tables.Add(dtl.Copy());
            ds.Tables[0].TableName = "dtlBill";
            ds.Tables.Add(dtlDetail.Copy());
            ds.Tables[1].TableName = "dtlBillDetail";


            this.ShowMessage("����ɹ�");
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public string GetAutoId(string flag)
        {

            //�õ��Զ����
            string strautoid = "";
            int autoid = BillAutoIDManage.GetAutoIDAdd(flag);//�õ���ⵥ�ĵ���������
            if (autoid < 10)
            {
                strautoid = "000" + autoid.ToString();
            }
            else if (autoid >= 10 && autoid < 100)
            {
                strautoid = "00" + autoid.ToString();
            }
            else if (autoid >= 100 && autoid < 1000)
            {
                strautoid = "0" + autoid.ToString();
            }
            else if (autoid >= 1000 && autoid < 10000)
            {
                strautoid = autoid.ToString();
            }

            strautoid=DateTime.Now.ToString("yyyyMMdd")+strautoid;
            return strautoid;
        }

        //����
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserRightManage urm = new UserRightManage();
            if (urm.IsOperateRight(SysParams.UserID, "lkdxz") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }


            //�����������
            txtGuid.Text = Guid.NewGuid().ToString();
            txtBillID.Text = "";
            txtBatchNo.Text ="";
            cboDepot.Text = "";
            cboDept.Text = "";
            txtRemark.Text = "";
            cboSupplier.Text = "";
            cboStorageType.Text = "";
            cboBearing.Text = "";
            cboHandlePerson.Text = "";
            
            txtAutoBillID.Text = GetAutoId(this.Tag.ToString());
            

            txtCreateDate.Text = DateTime.Now.ToString();
            txtCreatePerson.Text = SysParams.UserName;
            txtCheckDate.Text = "";
            txtCheckPerson.Text = "";

            if (this.Tag.ToString() == "I")
            {
                this.Text = "��ⵥ����";
                cboStorageType.Text = "ԭ�ϲɹ����";
            }
            else
            {
                this.Text = "���ⵥ����";
                cboStorageType.Text = "���۷�������";
            }

         

            //�����ϸ��
            this.gridControl1.DataSource = IniBindTable();
            gridMaterialGuid.Visible = false;

            //��ʼ����û�����
            SetControlEnable(0);

            tsbCheckPass.Enabled = false;
        }



        //���
        private void tsbCheckPass_Click(object sender, EventArgs e)
        {
            UserRightManage urm = new UserRightManage();
            if (urm.IsOperateRight(SysParams.UserID, "lkdsh") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }

            //�������״̬
            bm.ChcekBill(txtGuid.Text, 1);

            //����Ϊ�������
            SetControlEnable(1);

            // ���sendflag����1���Ǵ������ϸ��ѯ�н��뱾���ڣ�����ˢ�¸�����
            if (SendFlag == 0)
            {
                if (this.Tag.ToString() == "I")
                {
                    frmBill.frmbill.LoadBill();
                }
                else if (this.Tag.ToString() == "E")
                {
                    frmBillE.frmbille.LoadBill();
                }
            }

            txtCheckDate.Text = DateTime.Now.ToString();
            txtCheckPerson.Text = SysParams.UserName;

        }

        //����
        private void tsbCheckNoPass_Click(object sender, EventArgs e)
        {
            UserRightManage urm = new UserRightManage();
            if (urm.IsOperateRight(SysParams.UserID, "lkdsh") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }

            //�������״̬
            bm.ChcekBill(txtGuid.Text,0);

            //����Ϊ��û�����
            SetControlEnable(0);

            // ���sendflag����1���Ǵ������ϸ��ѯ�н��뱾���ڣ�����ˢ�¸�����
            if (SendFlag == 0)
            {
                if (this.Tag.ToString() == "I")
                {
                    frmBill.frmbill.LoadBill();
                }
                else if (this.Tag.ToString() == "E")
                {
                    frmBillE.frmbille.LoadBill();
                }
            }

            txtCheckDate.Text = "";
            txtCheckPerson.Text = "";

        }

        private void SetControlEnable(int pass)
        {
            if (pass == 1)
            {
                //�����
                tsbCheckNoPass.Enabled = true;
                tsbCheckPass.Enabled = false;

                tsbSave.Enabled = false;
                btnDelete.Enabled = false;

                btnAddDetail.Enabled = false;
                btnDelDetail.Enabled = false;
            }
            else
            { 
                //û�����
                tsbCheckNoPass.Enabled = false;
                tsbCheckPass.Enabled = true;

                tsbSave.Enabled = true;
                btnDelete.Enabled = true;

                btnAddDetail.Enabled = true;
                btnDelDetail.Enabled = true;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ȷ��ɾ���õ��ݣ�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //ɾ��
                bm.DeleteBill(txtGuid.Text);

                //���
                btnAdd_Click(null, null);

                 // ���sendflag����1���Ǵ������ϸ��ѯ�н��뱾���ڣ�����ˢ�¸�����
                if (SendFlag == 0)
                {
                    if (this.Tag.ToString() == "I")
                    {
                        frmBill.frmbill.LoadBill();
                    }
                    else if (this.Tag.ToString() == "E")
                    {
                        frmBillE.frmbille.LoadBill();
                    }
                }

               
               
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {

            if (this.Tag.ToString() == "I")
            {
                //��ӡ��ⵥ
                XtraReportBillI XtraReportBillI = new XtraReportBillI(ds);
                XtraReportBillI.ShowPreview();

            }
            else
            {

                //��ӡ��ⵥ
                XtraReportBillE XtraReportBillE = new XtraReportBillE(ds);
                XtraReportBillE.ShowPreview();
            }
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            frmMaterialAdd frmMaterialAdd = new frmMaterialAdd();
            frmMaterialAdd.Invalue = 1;
            frmMaterialAdd.MaterialAdd("", "");
        }

        private void repositoryItemSpinEdit2_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            e.Handled = true;
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void repositoryItemSpinEdit3_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void repositoryItemSpinEdit3_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (this.Text == "���ⵥ����" || this.Text == "���ⵥ�༭")
                {
                    //��������Ʒ�Ƿ��Զ�����ƽ������
                    if (e.KeyValue == 8 || e.KeyValue == 46)
                    {
                        string AutoFillRemovePrice = System.Configuration.ConfigurationSettings.AppSettings["IsAutoFillRemovePrice"].ToString(); ;
                        if (AutoFillRemovePrice == "true")
                        {
                            if (gridView1.GetFocusedRow() != null)
                            {
                                decimal priceAVG = 0;
                                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();
                                //�õ����ϼ���ĳ���ֿ��е�ƽ����,д�뵥������
                                priceAVG = bm.sp_GetMaterialPrice(guid, cboDepot.Text);
                                gridView1.SetFocusedRowCellValue(gridPrice, priceAVG);
                            }
                        }
                    }
                }
            }
            catch
            { }
        }
    }
}