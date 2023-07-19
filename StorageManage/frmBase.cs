using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StorageManage
{
    /// <summary>
    /// ���ര�ڣ��ṩ�����ķ���
    /// </summary>
    public partial class frmBase : Form
    {
       
        public frmBase()
        {
            InitializeComponent();
        }


        /// <summary>
        /// ����������ѡ�񴰿ڣ��������ʾ����ƥ�������
        /// </summary>
        public void SelectDataGrid(DataGridView dgvobj,System.Windows.Forms.TextBox txtobj,int objtype,string sqlstr)
        {
            //dgvobj.Top = txtobj.Top + txtobj.Height + 5;
            //dgvobj.Left = txtobj.Left;

            //System.Data.DataTable dtl = new System.Data.DataTable();

            ////��Թ�����λ�Ĳ�ͬ��ѡ��ͬ�е����ݿ�
            //switch (objtype)
            //{ 
            //    case 1://Ա��
            //        EmployeeManage empmanage = new EmployeeManage();
            //        dtl = empmanage.GetEmployeeInfo(sqlstr);
            //        dgvobj.DataSource = dtl;
            //        break;
            //    case 2://����ͺţ�Ʒ����
            //        ProductModelManage productmanage = new ProductModelManage();
            //        dtl = productmanage.GetProductModelInfo(sqlstr);
            //        dgvobj.DataSource = dtl;
            //        break;
            //    case 3://������
            //        WorkGroupManage wgm = new WorkGroupManage();
            //        dtl = wgm.GetWorkGroupInfo(sqlstr);
            //        dgvobj.DataSource = dtl;
            //        break;
            
            //}
        }

        /// <summary>
        /// ��ʾ������Ϣ
        /// </summary>
        /// <param name="strmessage"></param>
        public void ShowAlertMessage(string strmessage)
        {
            MessageBox.Show(strmessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// ��ʾ��ʾ��Ϣ
        /// </summary>
        /// <param name="strmessage"></param>
        public void ShowMessage(string strmessage)
        {
            MessageBox.Show(strmessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ��ʾ������ʾ��Ϣ
        /// </summary>
        /// <param name="strmessage"></param>
        public void ShowErrorMessage(string strmessage)
        {
            MessageBox.Show(strmessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //�õ���ǰ���ʼ����·�
        public string GetCurrentSalaryMonth()
        {
           // BagWorkDataManage bagmanage = new BagWorkDataManage();
            //�õ���ǰ���ʼ����·�
          //  return bagmanage.GetCurrentSalaryMonth();
            return "";
        }


        /// <summary>
        /// �������б��ͨ�÷���
        /// </summary>
        ///public void cboDataBind(ComboBox obj, int flag)
        ///{
            //CommonManage commonmanage = new CommonManage();

            //switch (flag)
            //{ 
            //    case 1:  //������λ
            //        System.Data.DataTable dtl = commonmanage.GetWorkStation();
            //        for (int i = 0; i < dtl.Rows.Count; i++)
            //        {
            //            obj.Items.Add(dtl.Rows[i]["WorkStation"].ToString());
            //        }
            //        break;

            
            //}
           
          
        ///}



        /// <summary>
        /// ����������������
        /// </summary>
        public void DataGridViewColumnNoOrder(DataGridView datagridobj)
        {
            for (int i = 0; i < datagridobj.Columns.Count; i++)
            {
                datagridobj.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            
            }
        }
    }
}