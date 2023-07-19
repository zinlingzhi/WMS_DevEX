using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StorageManageLibrary;
using System.Collections;

namespace StorageManage
{
    /// <summary>
    /// ��Ʒ����������
    /// </summary>
    public partial class frmMaterial : frmBase
    {
        MaterialManage MaterialManage=new MaterialManage();
        public static frmMaterial frmmaterial;
        public frmMaterial()
        {
            InitializeComponent();

            IniControl_CN();

            frmmaterial = this;
        }

        /// <summary>
        /// ������
        /// </summary>
        public void LoadStorageClassTree()
        {
            treeView1.Nodes.Clear();

            DataTable mdt = new DataTable();
            StorageClassManage pmc = new StorageClassManage();
            mdt = pmc.GetStorageClassData();

            this.treeView1.ImageList = imageList1;
            if (mdt.Rows.Count > 0)
            {
                int MaxLayer = 10;
                ArrayList al = new ArrayList();
                for (int i = 1; i <= MaxLayer; i++)
                {

                    if (i == 1)
                    {
                        DataRow[] dr;
                        dr = mdt.Select("FatherID='0'");
                        for (int j = 0; j < dr.Length; j++)
                        {
                            TreeNode tn = new TreeNode();
                            tn.Text = dr[j]["InterName"].ToString();

                            tn.Tag = dr[j]["InterID"].ToString();

                            this.treeView1.Nodes.Add(tn);
                            al.Add(tn);

                        }
                        dr = null;
                    }
                    else
                    {
                        int upLenth = al.Count; //��¼��һ��ڵ���
                        for (int k = 0; k < upLenth; k++)
                        {
                            TreeNode tvn = (TreeNode)al[k];
                            DataRow[] dr = mdt.Select("FatherID='" + tvn.Tag.ToString() + "'");
                            for (int j = 0; j < dr.Length; j++)
                            {
                                TreeNode tn = new TreeNode();
                                tn.Text = dr[j]["InterName"].ToString();
                                tn.Tag = dr[j]["InterID"].ToString();
                                tvn.Nodes.Add(tn);
                                al.Add(tn); //���ӱ���ڵ㣬�Ա���һ�����
                            }
                            dr = null;
                        }
                        for (int k = upLenth - 1; k >= 0; k--)
                        {
                            al.RemoveAt(k); //ɾ����һ��ڵ������
                        }
                        if (al.Count == 0)
                        {
                            break;
                        }
                    }
                }
                al = null;
            }

            mdt.Dispose();
        }

        //�����Ʒ����
        public void LoadMaterial(string strsql)
        {
            DataTable dtl = MaterialManage.GetMaterialData_CN(strsql);
            gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;
        
        }

        private void frmMaterial_Load(object sender, EventArgs e)
        {
            LoadStorageClassTree();

            treeView1.ExpandAll();

            LoadMaterial("");
        }

        //����ά��
        private void tsbStorageClass_Click(object sender, EventArgs e)
        {
            frmStorageClass fsc = new frmStorageClass();
            fsc.ShowDialog();

            LoadStorageClassTree();

            treeView1.ExpandAll();
        }

        //���
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                frmMaterialAdd frmMaterialAdd = new frmMaterialAdd();
                frmMaterialAdd.MaterialAdd(treeView1.SelectedNode.Tag.ToString(), treeView1.SelectedNode.Text);
            }
            else
            {
                this.ShowAlertMessage("����ѡ���Ʒ����������!");
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //��������
            if (treeView1.SelectedNode.Text != "��Ʒ����")
            {

                this.FillMaterial(treeView1.SelectedNode.Tag.ToString());
            }
            else
            {
                this.FillMaterial("");
            }
        }

        /// <summary>
        /// ���ز�Ʒ��Ϣ
        /// </summary>
        public void FillMaterial(string classid)
        {
            gridControl1.DataSource = MaterialManage.GetMaterialDataByClassID(classid);

        }

        //�༭
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmMaterialAdd frmMaterialAdd = new frmMaterialAdd();
                frmMaterialAdd.MaterialEdit(guid);
            }

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmMaterialAdd frmMaterialAdd = new frmMaterialAdd();
                frmMaterialAdd.MaterialEdit(guid);
            }
        }

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (MessageBox.Show("ȷ��ɾ�������ݣ�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DataRowView dr = (DataRowView)(gridView1.GetFocusedRow());

                    if (MaterialManage.IsUseMaterial(dr[0].ToString()) == true)
                    {
                        this.ShowAlertMessage("��ǰ��Ʒ�Ѿ���ʹ�ã�����ɾ����");
                        return;
                    }
                    else
                    {
                        MaterialManage.DeleteMaterial(dr[0].ToString());
                    }
                   

                    string strsql = " where ClassId='" + treeView1.SelectedNode.Tag.ToString() + "'";
                    //LoadMaterial(strsql);
                    gridView1.DeleteSelectedRows();
                    // this.ShowMessage("ɾ���ɹ�!");
                }
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void txtQryValue_TextChanged(object sender, EventArgs e)
        {
            if (cboQry.Text == "������")
            {
                string strsql = " where BarNo like '" + txtQryValue.Text.Replace("'","''") + "%' ";
                DataTable dtl = MaterialManage.GetMaterialData_CN(strsql);
                gridControl1.DataSource = dtl;

                gridView1.Columns[0].Visible = false;
            }
            else if (cboQry.Text == "Ʒ��")
            {
                string strsql = " where MaterialName like '" + txtQryValue.Text.Replace("'", "''") + "%' ";
                DataTable dtl = MaterialManage.GetMaterialData_CN(strsql);
                gridControl1.DataSource = dtl;

                gridView1.Columns[0].Visible = false;

            }

            else if (cboQry.Text == "����ͺ�")
            {
                string strsql = " where Spec like '" + txtQryValue.Text.Replace("'", "''") + "%' ";
                DataTable dtl = MaterialManage.GetMaterialData_CN(strsql);
                gridControl1.DataSource = dtl;

                gridView1.Columns[0].Visible = false;

            }
        }

        private void tsbSelect_Click(object sender, EventArgs e)
        {
            frmBasicDataAdd frmBasicDataAdd = new frmBasicDataAdd();
            frmBasicDataAdd.ShowDialog();
        }

    }
}