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
    /// ���ֿ���ܱ�
    /// </summary>
    public partial class frmAllDepotSumQry : frmBase
    {
        BillManage BillManage = new BillManage();
        MaterialManage MaterialManage = new MaterialManage();
        public frmAllDepotSumQry()
        {
            InitializeComponent();
            IniControl_CN();
        }

      

        private void frmBill_Load(object sender, EventArgs e)
        {
            BeginDate.Text = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
            endDate.Text = DateTime.Now.ToShortDateString();


        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

      
        //����ѯ
        private void btnQty_Click(object sender, EventArgs e)
        {

            if (txtMaterialGuid.Text.Trim() == "")
            {
                this.ShowAlertMessage("��ѡ���Ʒ!");
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

            DataTable dtl = BillManage.sp_GetAllDepotSum(txtMaterialGuid.Text,BeginDate.Text,endDate.Text);
            this.gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;
        
            for (int i = 5; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Width = 90;
                gridView1.Columns[i].MinWidth = 80;
            }

            gridView1.Columns[2].Caption = "��Ʒ����";
            gridView1.Columns[3].Caption = "������";
            gridView1.Columns[4].Caption = "���";

            gridView1.Columns[2].MinWidth = 50;
            gridView1.Columns[3].MinWidth = 50;
            gridView1.Columns[4].MinWidth =50;

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

            txtMaterialGuid.Text = "";
            txtBarNo.Text = "";
            txtMaterialName.Text = "";
            txtMaterialId.Text = "";
            txtSpec.Text = "";
        
        }


        #region �ؼ�����
        /// <summary>
        /// ���ؼ�����
        /// </summary>
        private void IniControl_CN()
        {

            #region szm������ע��
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

        //ѡ���ϼ�
        private void btnSelectMaterial_Click(object sender, EventArgs e)
        {
            frmSelectMaterial frmSelectMaterial = new frmSelectMaterial();
            frmSelectMaterial.Tag = "";
            frmSelectMaterial.ShowDialog();

            //ѡ����ϼ����
            if (frmSelectMaterial.Tag.ToString() != "")
            {
                //�õ�ѡ����ϼ�guid��Ȼ��õ�
                Material material = MaterialManage.GetMaterialByGuid(frmSelectMaterial.Tag.ToString());

                //�������
                txtMaterialGuid.Text= material.MaterialGuid;
                txtBarNo.Text = material.BarNo;
                txtMaterialName.Text = material.MaterialName;
                txtMaterialId.Text = material.MaterialId;
                txtSpec.Text = material.Spec;
               
            }
        }
    }
}