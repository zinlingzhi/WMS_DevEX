using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StorageManageLibrary;

namespace StorageManage
{
    /// <summary>
    /// �����շ�����
    /// </summary>
    public partial class frmInOutDeptDetail : frmBase
    {
        BillManage BillManage = new BillManage();
        public frmInOutDeptDetail()
        {
            InitializeComponent();
            IniControl_CN();
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            BeginDate.Text = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
            endDate.Text = DateTime.Now.ToShortDateString();

            //�󶨲���
            DeptManage DeptManage = new DeptManage();
            DataTable dtl = DeptManage.GetDeptData();
            if (dtl.Rows.Count > 0)
            {
                for (int i = 0; i < dtl.Rows.Count; i++)
                {
                    cboDept.Items.Add(dtl.Rows[i]["��������"].ToString());
                }

                cboDept.SelectedIndex = 0;
            }

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString().Trim();
                string flag = ((DataRowView)(gridView1.GetFocusedRow())).Row[23].ToString().Trim();


                frmBillAdd frmBillAdd = new frmBillAdd();
                frmBillAdd.SendFlag = 1;//�Ӳ����շ���ϸ���н���(�Ǳ��������ڱ���ʱ��ˢ�¸�����)
                frmBillAdd.BillEdit(guid, flag,this);
            }
        }

    

        private void btnQty_Click(object sender, EventArgs e)
        {
            //��ѯ
            string strSQL = " where 1=1 ";

            if (rdoALL.Checked == true)
            {  
                 
            }
            else  if (rdoIn.Checked == true)
            {
                strSQL = strSQL + " and flag='I'";
            }
            else if (rdoOut.Checked == true)
            {
                strSQL = strSQL + " and flag='E'";
            }

            if (BeginDate.Text != "")
            {
                strSQL = strSQL + " and BillDate>='" + BeginDate.Text.Replace("'", "''") + " 00:00:00'"; 
            }

            if (endDate.Text  != "")
            {
                strSQL = strSQL + " and BillDate<='" + endDate.Text.Replace("'", "''") + " 23:59:59'";
            }

            if (cboDept.Text != "")
            {
                strSQL = strSQL + " and DeptGuid like '" + cboDept.Text.Replace("'", "''") + "%'";
            }


            DataTable dtl = BillManage.GetInOutDepotDetailData(strSQL);
            this.gridControl1.DataSource = dtl;

           
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel�ļ�|*.XLS|�����ļ�|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string filename = saveFileDialog1.FileName;
                gridView1.ExportToXls(filename);

                this.ShowMessage("�����ɹ�");
            }
        }

        //����
        private void button1_Click(object sender, EventArgs e)
        {
            BeginDate.Text = "";
            endDate.Text = "";
            cboDept.Text = "";
         
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

        private void tsbExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel�ļ�|*.XLS|�����ļ�|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string filename = saveFileDialog1.FileName;
                gridView1.ExportToXls(filename);

                this.ShowMessage("�����ɹ�");
            }
        }

        private void exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}