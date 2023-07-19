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
    /// ����ѡ��
    /// </summary>
    public partial class frmBasicDataAdd : Form
    {
        BasicDataManage BasicDataManage = new BasicDataManage();
        public frmBasicDataAdd()
        {
            InitializeComponent();
        }

       

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

            loaddata();
        }

        private void loaddata()
        {
            //(1-��λ 2-��� 3:��װ 4:�Ƽ۷�)
            int flag = 0;
            switch (cboSelect.Text.Trim())
            {
                case "��λ":
                    flag = 1;
                    break;
                case "���":
                    flag = 2;
                    break;
                case "��װ":
                    flag = 3;
                    break;
                case "�Ƽ۷�":
                    flag = 4;
                    break;
            }

            //�󶨲ֿ�
            DataTable dtl = BasicDataManage.GetBasicData2(flag);
            this.gridSelect.DataSource = dtl;
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            int flag = 0;
            switch (cboSelect.Text.Trim())
            {
                case "��λ":
                    flag = 1;
                    break;
                case "���":
                    flag = 2;
                    break;
                case "��װ":
                    flag = 3;
                    break;
                case "�Ƽ۷�":
                    flag = 4;
                    break;
            }

            BasicData BasicData = new BasicData();
            BasicData.UnitName = txtValue.Text;
            BasicData.flag = flag;

            BasicDataManage.Save(BasicData);

            loaddata();

           
        }

        private void tsBtnDel_Click(object sender, EventArgs e)
        {

            if (gridVProGroup.RowCount > 0)
            {
                int flag = 0;
                switch (cboSelect.Text.Trim())
                {
                    case "��λ":
                        flag = 1;
                        break;
                    case "���":
                        flag = 2;
                        break;
                    case "��װ":
                        flag = 3;
                        break;
                    case "�Ƽ۷�":
                        flag = 4;
                        break;
                }
                DialogResult dr = MessageBox.Show("ȷ��Ҫɾ����ѡ��ļ�¼��", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    string unitid = ((DataRowView)(gridVProGroup.GetFocusedRow())).Row[0].ToString();


                    BasicDataManage.DeleteBasicData(unitid);

                    loaddata();
                }

            }
        }
    }
}