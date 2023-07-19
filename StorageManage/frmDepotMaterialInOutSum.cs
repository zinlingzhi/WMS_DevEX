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
    /// �շ�����ܱ�
    /// </summary>
    public partial class frmDepotMaterialInOutSum : frmBase
    {
        BillManage BillManage = new BillManage();
        DataTable dtl = new DataTable();
        public static frmDepotMaterialInOutSum frmdepotmaterialInOutSum;
        
        public frmDepotMaterialInOutSum()
        {
            InitializeComponent();
            IniControl_CN();
            frmdepotmaterialInOutSum = this;
        }

      
     
        private void frmBill_Load(object sender, EventArgs e)
        {
            BeginDate.Text = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
            endDate.Text = DateTime.Now.ToShortDateString();

            //�󶨲ֿ�
            DepotManage DepotManage = new DepotManage();
            DataTable dtl = DepotManage.GetDepotData();
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboDepot.Items.Add(dtl.Rows[i]["�ֿ�����"].ToString());
            }
            cboDepot.SelectedIndex = 0;
            //cboDepot.Text = "�ֿ�";

            txtClassID.Tag = "";
            txtClassID.Text = "";

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        public void GetClass(string ClassID,string ClassName)
        {
            txtClassID.Text = ClassName;
            txtClassID.Tag = ClassID;
        }

    
        //����ѯ
        private void btnQty_Click(object sender, EventArgs e)
        {
            if (cboDepot.Text == "")
            {
                this.ShowAlertMessage("��ѡ��ֿ�!");
                return;
            }

            if (BeginDate.Text == "")
            {
                this.ShowAlertMessage("��ѡ��ʼ����!");
                return;
            }

            if (endDate.Text == "")
            {
                this.ShowAlertMessage("��ѡ���ֹ����!");
                return;
            }

            dtl = BillManage.sp_GetDepotClassDetailSum(BeginDate.Text, endDate.Text, cboDepot.Text,
                                       txtBarNo.Text, txtMaterialId.Text, txtMaterialName.Text,txtSpec.Text,txtClassID.Tag.ToString());
            this.gridControl1.DataSource = dtl;
         
           
        
           
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel�ļ�|*.XLS|�����ļ�|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string filename = saveFileDialog1.FileName;
                bandedGridView1.ExportToXls(filename);

                this.ShowMessage("�����ɹ�");
            }
        }

        //����
        private void button1_Click(object sender, EventArgs e)
        {
          
            BeginDate.Text = "";
            endDate.Text = "";
            cboDepot.Text = "";
            txtMaterialId.Text = "";
            txtBarNo.Text = "";
            txtMaterialName.Text = "";
            txtClassID.Tag = "";
            txtClassID.Text = "";
         

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

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            string strDate = BeginDate.Text + "��" + endDate.Text;
            string strDepot = cboDepot.Text;
            string strBarNo = txtBarNo.Text;
            string strMaterialName = txtMaterialName.Text;
            string strMaterialID = txtMaterialId.Text;
            string strSpec = txtSpec.Text;
            string strProducttype = txtClassID.Text;

            //��ӡ�շ�����ܱ�
            XtraReportDepotMaterialInOutSum xrm =
                 new XtraReportDepotMaterialInOutSum(dtl, strDate, strDepot, "", strBarNo, strMaterialName, strSpec, strProducttype);
            xrm.ShowPreview();
        }

        private void tsbExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel�ļ�|*.XLS|�����ļ�|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string filename = saveFileDialog1.FileName;
                bandedGridView1.ExportToXls(filename);

                this.ShowMessage("�����ɹ�");
            }
        }

      

        private void exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //ѡ���Ʒ����
        private void btnSelect_Click(object sender, EventArgs e)
        {
            frmSelectType frmSelectType = new frmSelectType();
            frmSelectType.InValue = 1;//���շ�����ܽ���
            frmSelectType.ShowDialog();
        }
    }
}