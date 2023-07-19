using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StorageManageLibrary;
using System.Web.UI.WebControls;
using Bruce.Jin.DAO;
using System.Xml;

namespace StorageManage
{
    /// <summary>
    /// ϵͳ��½
    /// </summary>
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        private void login()
        {
            if (cboUserID.Text.Trim() == "")
            {
                MessageBox.Show("��ѡ���û���!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("�������û�����!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            LoginUserManage lum = new LoginUserManage();
            if (lum.CheckUserPassword(((ListItem)cboUserID.SelectedItem).Value, txtPassword.Text))
            {
                SysParams.UserID = ((ListItem)cboUserID.SelectedItem).Value;
                SysParams.UserName = ((ListItem)cboUserID.SelectedItem).Text;
             
                //�����ε�½���û�������Ŀ���ƴ�����
                 WriteLoginUnitXML();
                //this.DialogResult = DialogResult.OK;
                this.Visible = false;

                frmStorageMain frmStorageMain = new frmStorageMain();
                frmStorageMain.ShowDialog();

            }
            else
            {
                MessageBox.Show("��������û��˺Ż��û������д���,������!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                login();
            }
        }


        /// <summary>
        /// �������б���ͨ�÷���
        /// </summary>
        public void cboDataBind(ComboBox obj)
        {
            LoginUserManage lum = new LoginUserManage();
            DataTable dtl = lum.GetLoginUserInfo();
            ListItem item;
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                item = new ListItem();
                item.Text = dtl.Rows[i]["USERNAME"].ToString();
                item.Value = dtl.Rows[i]["USERID"].ToString();
                obj.Items.Add(item);
            }

        }

        [Obsolete]
        private void frmLogin_Load(object sender, EventArgs e)
        {
            //��ʼ�����ݿ������ַ���
            CommonDataConfig.ConnectionDefaultStr = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"].ToString();
           
            //��������Ŀ��������
            cboDataBind(cboUserID);

            //���ϴε�½���û�����Ŀ���Ƽ��س���
            GetLoginUnitXML();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
         
            login();
        }

        /// <summary>
        /// ȡ����½�û�������Ŀ����
        /// </summary>
        private void GetLoginUnitXML()
        {
            string fileName = Application.StartupPath + @"\HistoryLogin.xml";
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(fileName);
            XmlNode rootNode = myXmlDocument.DocumentElement;
            //�û��ϴε�½�˺�
            string username = rootNode.ChildNodes[0].ChildNodes[0].Attributes["value"].Value;


            for (int i = 0; i < cboUserID.Items.Count; i++)
            {
                if (((ListItem)cboUserID.Items[i]).Text == username)
                {
                    cboUserID.SelectedIndex = i;
                    break;
                }
            }
        }

        /// <summary>
        /// ����½�û�����Ŀ���ƴ���xml��
        /// </summary>
        private void WriteLoginUnitXML()
        {

            string fileName = Application.StartupPath + @"\HistoryLogin.xml";

            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(fileName);
            XmlNode rootNode = myXmlDocument.DocumentElement;
            //�û��ϴε�½�û���
            rootNode.ChildNodes[0].ChildNodes[0].Attributes["value"].Value = cboUserID.Text;
        
            myXmlDocument.Save(Application.StartupPath + @"\HistoryLogin.xml");
        }

        private void lnkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePassword frmcp = new frmChangePassword();
            frmcp.USERID = ((ListItem)cboUserID.SelectedItem).Value;
            frmcp.USERName = ((ListItem)cboUserID.SelectedItem).Text;
            frmcp.ShowDialog();
        }


    }
}