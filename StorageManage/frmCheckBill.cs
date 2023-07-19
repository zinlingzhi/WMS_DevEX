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
    public partial class frmCheckBill : frmBase
    {
        CheckBillManage CheckBillManage = new CheckBillManage();
        public static frmCheckBill frmcheckbill;
        public frmCheckBill()
        {
            InitializeComponent();
            frmcheckbill = this;
            IniControl_CN();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserRightManage urm = new UserRightManage();
            if (urm.IsOperateRight(SysParams.UserID, "kcpdxz") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }

            frmCheckBillAdd frmCheckBillAdd = new frmCheckBillAdd();
            frmCheckBillAdd.BillAdd(this);
        }

        public void LoadBill()
        {
            string strsql = " where  BillDate>='" + BeginDate.Text + " 00:00:00'" + " and BillDate<='" + endDate.Text + " 23:59:59'";
            DataTable dtl = CheckBillManage.GetCheckBillData_CN(strsql);
            this.gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;
            gridView1.Columns[6].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns[6].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns[8].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns[8].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
           
        }

        private void frmCheckBill_Load(object sender, EventArgs e)
        {
            BeginDate.Text = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
            endDate.Text = DateTime.Now.ToShortDateString();

            LoadBill();

            //�󶨵����ֿ�
            DepotManage DepotManage = new DepotManage();
            DataTable dtl = DepotManage.GetDepotData();
            cboDepot.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboDepot.Items.Add(dtl.Rows[i]["�ֿ�����"].ToString());
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

                frmCheckBillAdd frmCheckBillAdd = new frmCheckBillAdd();
                frmCheckBillAdd.BillEdit(guid,this);
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmCheckBillAdd frmCheckBillAdd = new frmCheckBillAdd();
                frmCheckBillAdd.BillEdit(guid,this);
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
                        CheckBillManage.DeleteCheckBill(dr[0].ToString());

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

            if (cboDepot.Text != "")
            {
                strSQL = strSQL + " and Depot like '" + cboDepot.Text.Replace("'", "''") + "%'";
            }

         
            if (txtBillID.Text != "")
            {
                strSQL = strSQL + " and BillID like '" + txtBillID.Text.Replace("'", "''") + "%'";
            }

            if (cboHandlePerson.Text != "")
            {
                strSQL = strSQL + " and HandlePerson like '" + cboHandlePerson.Text.Replace("'", "''") + "%'";
            }

            if (txtRemark.Text != "")
            {
                strSQL = strSQL + " and Remark like '" + txtRemark.Text.Replace("'", "''") + "%'";
            }


            DataTable dtl = CheckBillManage.GetCheckBillData_CN(strSQL);
            this.gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;
            gridView1.Columns[6].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns[6].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns[8].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns[8].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }

        #region �ؼ�����
        /// <summary>
        /// ���ؼ�����
        /// </summary>
        private void IniControl_CN()
        {

            #region szm:ע��
            //DevExpress.XtraBars.Localization.BarLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraBarsLocalizationCHS();
            ////DevExpress.XtraCharts.Localization.ChartLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraChartsLocalizationCHS();
            //DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraEditorsLocalizationCHS();
            //DevExpress.XtraGrid.Localization.GridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraGridLocalizationCHS();
            //DevExpress.XtraLayout.Localization.LayoutLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraLayoutLocalizationCHS();
            //DevExpress.XtraNavBar.NavBarLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraNavBarLocalizationCHS(); 
            #endregion
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
    }
}