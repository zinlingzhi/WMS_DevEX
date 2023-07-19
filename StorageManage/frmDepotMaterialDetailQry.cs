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
    /// �����ϸ��
    /// </summary>
    public partial class frmDepotMaterialDetailQry : frmBase
    {
        BillManage BillManage = new BillManage();
        MaterialManage MaterialManage = new MaterialManage();
        public frmDepotMaterialDetailQry()
        {
            InitializeComponent();
            IniControl_CN();
        }

      

        private void frmBill_Load(object sender, EventArgs e)
        {
          

            //�󶨲ֿ�
            DepotManage DepotManage = new DepotManage();
            DataTable dtl = DepotManage.GetDepotData();
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboDepot.Items.Add(dtl.Rows[i]["�ֿ�����"].ToString());
            }

            cboDepot.SelectedIndex = 0;
            //cboDepot.Text = "�ֿ�";
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (bandedGridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(bandedGridView1.GetFocusedRow())).Row[0].ToString().Trim();
                string flag = ((DataRowView)(bandedGridView1.GetFocusedRow())).Row[3].ToString().Trim();

                switch (flag)
                {
                    case "I":  //���
                        frmBillAdd frmBillAdd = new frmBillAdd();
                        frmBillAdd.SendFlag = 1;
                        frmBillAdd.BillEdit(guid, "I",this);
                        break;
                    case "E": //����
                        frmBillAdd frmBillAdd2 = new frmBillAdd();
                        frmBillAdd2.SendFlag = 1;
                        frmBillAdd2.BillEdit(guid, "E",this);
                        break;
                    case "RI"://������
                        frmRemoveBillAdd frmRemoveBillAdd = new frmRemoveBillAdd();
                        frmRemoveBillAdd.SendFlag = 1;
                        frmRemoveBillAdd.BillEdit(guid,this);
                        break;
                    case "RE"://������
                        frmRemoveBillAdd frmRemoveBillAdd2 = new frmRemoveBillAdd();
                        frmRemoveBillAdd2.SendFlag = 1;
                        frmRemoveBillAdd2.BillEdit(guid,this);
                        break;
                    case "SI"://��ӯ
                        frmCheckBillAdd frmCheckBillAdd = new frmCheckBillAdd();
                        frmCheckBillAdd.SendFlag = 1;
                        frmCheckBillAdd.BillEdit(guid,this);
                        break;
                    case "SE"://�̿�
                        frmCheckBillAdd frmCheckBillAdd2 = new frmCheckBillAdd();
                        frmCheckBillAdd2.SendFlag = 1;
                        frmCheckBillAdd2.BillEdit(guid,this);
                        break;

                }
            }
          
        }

    
        //����ѯ
        private void btnQty_Click(object sender, EventArgs e)
        {
            if (cboDepot.Text == "")
            {
                this.ShowAlertMessage("��ѡ��ֿ�!");
                return;
            }
            if (txtMaterialGuid.Text.Trim() == "")
            {
                this.ShowAlertMessage("��ѡ���Ʒ!");
                return;
            }

            DataTable dtl = BillManage.sp_GetDepotMaterialDetailSum(cboDepot.Text,txtMaterialGuid.Text);
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