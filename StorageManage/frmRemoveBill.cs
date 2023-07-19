using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StorageManageLibrary;
using DevExpress.Utils;

namespace StorageManage
{
    /// <summary>
    /// ��������������
    /// </summary>
    public partial class frmRemoveBill : frmBase
    {
        RemoveBillManage RemoveBillManage = new RemoveBillManage();
        public static frmRemoveBill frmremovebill;
        public frmRemoveBill()
        {
            InitializeComponent();
            frmremovebill = this;
            IniControl_CN();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserRightManage urm = new UserRightManage();
            if (urm.IsOperateRight(SysParams.UserID, "dbdxz") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }


            frmRemoveBillAdd frmRemoveBillAdd = new frmRemoveBillAdd();
            frmRemoveBillAdd.BillAdd(this);
        }

        public void LoadBill()
        {
            string strsql = " where  BillDate>='" + BeginDate.Text + " 00:00:00'" + " and BillDate<='" + endDate.Text + " 23:59:59'";

            DataTable dtl = RemoveBillManage.GetRemoveBillData_CN(strsql);
            this.gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;
            gridView1.Columns[7].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns[7].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns[9].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns[9].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
           
        }

        private void frmRemoveBill_Load(object sender, EventArgs e)
        {
            BeginDate.Text = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
            endDate.Text = DateTime.Now.ToShortDateString();

            LoadBill();

            //�󶨵����ֿ�
            DepotManage DepotManage = new DepotManage();
            DataTable dtl = DepotManage.GetDepotData();
            cboDepotOut.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboDepotOut.Items.Add(dtl.Rows[i]["�ֿ�����"].ToString());
            }


            //�󶨵���ֿ�
            dtl = DepotManage.GetDepotData();
            cboDepotIn.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboDepotIn.Items.Add(dtl.Rows[i]["�ֿ�����"].ToString());
            }

            //�󶨾�����
            EmployeeManage EmployeeManage = new EmployeeManage();
            dtl = EmployeeManage.GetEmployeeData();
            cboHandlePerson.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboHandlePerson.Items.Add(dtl.Rows[i]["Ա������"].ToString());
            }



        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbedit_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmRemoveBillAdd frmRemoveBillAdd = new frmRemoveBillAdd();
                frmRemoveBillAdd.BillEdit(guid,this);
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmRemoveBillAdd frmRemoveBillAdd = new frmRemoveBillAdd();
                frmRemoveBillAdd.BillEdit(guid,this);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                DataRowView dr = (DataRowView)(gridView1.GetFocusedRow());
                if (dr[8].ToString() == "")
                {

                    if (MessageBox.Show("ȷ��ɾ�������ݣ�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        dr = (DataRowView)(gridView1.GetFocusedRow());
                        RemoveBillManage.DeleteRemoveBill(dr[0].ToString());

                        gridView1.DeleteSelectedRows();
                        this.ShowMessage("ɾ���ɹ�!");
                    }
                }
                else
                {
                    this.ShowAlertMessage("�˵�������ˣ�������ɾ��!!");
                }
            }
        }

        private void btnQty_Click(object sender, EventArgs e)
        {
            //��ѯ
            string strSQL = " where 1=1 ";
            if (BeginDate.Text != "")
            {
                strSQL = strSQL + " and BillDate>='" + BeginDate.Text.Replace("'", "''") + " 00:00:00'"; 
            }

            if (endDate.Text  != "")
            {
                strSQL = strSQL + " and BillDate<='" + endDate.Text.Replace("'", "''") + " 23:59:59'";
            }

            if (cboDepotOut.Text != "")
            {
                strSQL = strSQL + " and DepotOut like '" + cboDepotOut.Text.Replace("'", "''") + "%'";
            }

            if (cboDepotIn.Text != "")
            {
                strSQL = strSQL + " and DepotIn like '" + cboDepotIn.Text.Replace("'", "''") + "%'";
            }

            if (txtBillID.Text != "")
            {
                strSQL = strSQL + " and BillID like '" + txtBillID.Text.Replace("'", "''") + "%'";
            }

            if (cboHandlePerson.Text != "")
            {
                strSQL = strSQL + " and HandlePerson like '" + cboHandlePerson.Text.Replace("'", "''") + "%'";
            }

            if (txtSpec.Text != "")
            {
                strSQL = strSQL + " and RemoveBillGuid  in (select RemoveBillGuid from RemoveBillDetail where Spec like '" + txtSpec.Text.Replace("'", "''") + "%')";
            }

            if (txtMaterialName.Text != "")
            {
                strSQL = strSQL + " and RemoveBillGuid  in (select RemoveBillGuid from RemoveBillDetail where MaterialName like '" + txtMaterialName.Text.Replace("'", "''") + "%')";
            } 

            DataTable dtl = RemoveBillManage.GetRemoveBillData_CN(strSQL);
            this.gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;
            gridView1.Columns[7].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns[7].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns[9].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns[9].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }

        #region �ؼ�����
        /// <summary>
        /// ���ؼ�����
        /// </summary>
        private void IniControl_CN()
        {

            //DevExpress.XtraBars.Localization.BarLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraBarsLocalizationCHS();
            ////DevExpress.XtraCharts.Localization.ChartLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraChartsLocalizationCHS();
            //DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraEditorsLocalizationCHS();
            //DevExpress.XtraGrid.Localization.GridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraGridLocalizationCHS();
            //DevExpress.XtraLayout.Localization.LayoutLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraLayoutLocalizationCHS();
            //DevExpress.XtraNavBar.NavBarLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraNavBarLocalizationCHS();
            //DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraPivotGridLocalizationCHS();
            //DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraPrintingLocalizationCHS();
            //DevExpress.XtraReports.Localization.ReportLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraReportsLocalizationCHS();
            //DevExpress.XtraRichTextEdit.Localization.XtraRichTextEditLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraRichTextEditLocalizationCHS();
            //DevExpress.XtraScheduler.Localization.SchedulerLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSchedulerLocalizationCHS();
            //DevExpress.XtraScheduler.Localization.SchedulerExtensionsLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSchedulerExtensionsLocalizationCHS();
            //DevExpress.XtraSpellChecker.Localization.SpellCheckerLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSpellCheckerLocalizationCHS();
            //DevExpress.XtraTreeList.Localization.TreeListLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraTreeListLocalizationCHS();
            //DevExpress.XtraVerticalGrid.Localization.VGridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraVerticalGridLocalizationCHS();
            //DevExpress.XtraWizard.Localization.WizardLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraWizardLocalizationCHS();
        }
        #endregion

        private void gridControl1_Click(object sender, EventArgs e)
        {
           

            //��ʾ����ϸ����
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                //�õ���ϸ������
                DataTable dtlDetail = RemoveBillManage.GetRemoveBillDetailData(guid);
                this.gridControl2.DataSource = dtlDetail;
                gridMaterialGuid.Visible = false;
                gridMaterialId.Visible = false;
            
            }
        }
    }
}