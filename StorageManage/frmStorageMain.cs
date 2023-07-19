using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bruce.Jin.DAO;
using StorageManageLibrary;
using System.Diagnostics;
namespace StorageManage
{
    public partial class frmStorageMain : frmBase
    {
        UserRightManage UserRightManage = new UserRightManage();
        /// <summary>
        /// �ֿ����ϵͳ������
        /// </summary>
        public frmStorageMain()
        {
            InitializeComponent();
        }

        private void frmStorageMain_Load(object sender, EventArgs e)
        {

            //��ʼ�����ݿ������ַ���
            CommonDataConfig.ConnectionDefaultStr = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"].ToString();

            tsbUserID.Text = "  ��ǰ��½�ˣ�" + SysParams.UserName;

            //��ҵ����
            tsbCompanyName.Text = "��ҵ����:" + System.Configuration.ConfigurationSettings.AppSettings["CompanyName"].ToString(); ;
        }


        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "kh") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return; 
            }
            frmDept frmDept = new frmDept();
            frmDept.Show(this);
        }

        //����
        private void ItemStorageClass_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
            frmStorageClass fsc = new frmStorageClass();
            fsc.Show(this);
        }

        //��Ʒ
        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "hp") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmMaterial fm = new frmMaterial();
            fm.Show(this);
        }


        private void itemDepot_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ck") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmDepot frmDepot = new frmDepot();
            frmDepot.Show(this);

            
        }

        //��Ӧ�̹���
        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "gys") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmSupplier frmSupplier = new frmSupplier();
            frmSupplier.Show(this);
        }

        //�ͻ�����
        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "kh") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmClient frmClient = new frmClient();
             frmClient.Show(this);
        }

        //Ա������
        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "yg") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmEmployee frmEmployee = new frmEmployee();
            frmEmployee.Show(this);
        }

        private void BaseItem1_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "hp") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmMaterial fm = new frmMaterial();
            fm.Show(this);
        }

        private void BaseItem2_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ck") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmDepot frmDepot = new frmDepot();
            frmDepot.Show(this);
        }

        private void BaseItem3_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "kh") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmClient frmClient = new frmClient();
            frmClient.Show(this);
        }

        private void BaseItem4_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "gys") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmSupplier frmSupplier = new frmSupplier();
            frmSupplier.Show(this);
        }

        private void BaseItem5_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "yg") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmEmployee frmEmployee = new frmEmployee();
            frmEmployee.Show(this);
        }

        private void BaseItem6_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "bm") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmDept frmDept = new frmDept();
            frmDept.Show(this);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ȷ���˳���ϵͳ��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //��ⵥ
        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdgl") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmBill frmBill = new frmBill();
            frmBill.Show(this);
        }

        //���ⵥ
        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ckdgl") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmBillE frmBillE = new frmBillE();
            frmBillE.Show(this);
        }

        private void frmStorageMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //��ⵥ
        private void tsbI_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdgl") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmBill frmBill = new frmBill();
            frmBill.Show(this);
        }

        //���ⵥ
        private void tsbE_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ckdgl") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmBillE frmBillE = new frmBillE();
            frmBillE.Show(this);
        }

        //������
        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "dbdgl") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmRemoveBill frmRemoveBill = new frmRemoveBill();
            frmRemoveBill.Show(this);
        }

        //������
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "dbdgl") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmRemoveBill frmRemoveBill = new frmRemoveBill();
            frmRemoveBill.Show(this);
        }

        //��ⵥ��ϸ����ѯ
        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdmxb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmInDepotDetail frmInDepotDetail = new frmInDepotDetail();
            frmInDepotDetail.Show(this);
        }

        //���ⵥ��ϸ����ѯ
        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            if (UserRightManage.IsOperateRight(SysParams.UserID, "ckdmxb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmOutDepotDetail frmOutDepotDetail = new frmOutDepotDetail();
            frmOutDepotDetail.Show(this);
        }

        //�����ܱ�
        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdhzb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmInDepotDetailSum frmInDepotDetailSum = new frmInDepotDetailSum();
            frmInDepotDetailSum.Show(this);
        }

        //������ܱ�
        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ckdhzb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmOutDepotDetailSum frmOutDepotDetailSum = new frmOutDepotDetailSum();
            frmOutDepotDetailSum.Show(this);
        }
        //�����ܱ�
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdhzb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmInDepotDetailSum frmInDepotDetailSum = new frmInDepotDetailSum();
            frmInDepotDetailSum.Show(this);
        }
        //������ܱ�
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdhzb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmOutDepotDetailSum frmOutDepotDetailSum = new frmOutDepotDetailSum();
            frmOutDepotDetailSum.Show(this);
        }

        //����ѯ
        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "cccx") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmDepotMaterialSum frmDepotMaterialSum = new frmDepotMaterialSum();
            frmDepotMaterialSum.Show(this);
        }

        //�̵㵥
        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "kcpd") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmCheckBill frmCheckBill = new frmCheckBill();
            frmCheckBill.Show(this);
        }

        //�շ�����ܱ�
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "sfchzb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmDepotMaterialInOutSum frmDepotMaterialInOutSum = new frmDepotMaterialInOutSum();
            frmDepotMaterialInOutSum.Show(this);
        }

        //����ѯ
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "cccx") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmDepotMaterialSum frmDepotMaterialSum = new frmDepotMaterialSum();
            frmDepotMaterialSum.Show(this);
        }

        //�շ����ͻ��ܱ�
        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "sflxhzb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmDepotMaterialTypeInOutSum frmDepotMaterialTypeInOutSum = new frmDepotMaterialTypeInOutSum();
            frmDepotMaterialTypeInOutSum.Show(this);
        }

        //�ֿ��շ���ϸ��
        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "cksfmxb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmInOutDepotDetail frmInOutDepotDetail = new frmInOutDepotDetail();
            frmInOutDepotDetail.Show(this);
        }

        //�����շ���ϸ��
        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "bmsfmxb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmInOutDeptDetail frmInOutDeptDetail = new frmInOutDeptDetail();
            frmInOutDeptDetail.Show(this);
        }
        //�����ϸ��
        private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "chmxz") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmDepotMaterialDetailQry frmDepotMaterialDetailQry = new frmDepotMaterialDetailQry();
            frmDepotMaterialDetailQry.Show(this);
        }

        //�û�����
        private void tsbUserManage_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "yhgl") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmLoginUser frmLoginUser = new frmLoginUser();
            frmLoginUser.Show(this);
            
        }

        private void tsblkd_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdgl") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmBill frmBill = new frmBill();
            frmBill.Show(this);
        }
        private void tsblkdmx_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdmxb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmInDepotDetail frmInDepotDetail = new frmInDepotDetail();
            frmInDepotDetail.Show(this);
        }

        private void tsblkhzb_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdhzb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmInDepotDetailSum frmInDepotDetailSum = new frmInDepotDetailSum();
            frmInDepotDetailSum.Show(this);
        }

        private void tsbckdgl_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ckdgl") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmBillE frmBillE = new frmBillE();
            frmBillE.Show(this);
        }

        private void tsbckdmx_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ckdmxb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmOutDepotDetail frmOutDepotDetail = new frmOutDepotDetail();
            frmOutDepotDetail.Show(this);
        }

        private void tsbckhzb_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ckdhzb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmOutDepotDetailSum frmOutDepotDetailSum = new frmOutDepotDetailSum();
            frmOutDepotDetailSum.Show(this);
        }

        private void tsbdbd_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "dbdgl") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmRemoveBill frmRemoveBill = new frmRemoveBill();
            frmRemoveBill.Show(this);
        }

        private void tsbqxgl_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "qxgl") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmUserRight frmUserRight = new frmUserRight();
            frmUserRight.Show(this);
        }

        private void ע��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("ȷ��Ҫע��ϵͳ?", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                try
                {

                    Application.Exit();

                    Process p = new Process();
                    p.StartInfo.FileName = Application.StartupPath + @"\StorageManage.exe";
                    p.StartInfo.Arguments = "/StorageManage";
                    p.Start();
                }
                catch (Exception ee)
                {
                    throw ee;
                }

            }
        }

        private void tsbcccx_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "cccx") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmDepotMaterialSum frmDepotMaterialSum = new frmDepotMaterialSum();
            frmDepotMaterialSum.Show(this);
        }

        private void tsbcksfmxb_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "cksfmxb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmInOutDepotDetail frmInOutDepotDetail = new frmInOutDepotDetail();
            frmInOutDepotDetail.Show(this);
        }

        private void tsbbmsfmxb_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "bmsfmxb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmInOutDeptDetail frmInOutDeptDetail = new frmInOutDeptDetail();
            frmInOutDeptDetail.Show(this);
        }

        private void tsbsfchzb_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "sfchzb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmDepotMaterialInOutSum frmDepotMaterialInOutSum = new frmDepotMaterialInOutSum();
            frmDepotMaterialInOutSum.Show(this);
        }

        private void tsbsflxhzb_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "sflxhzb") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmDepotMaterialTypeInOutSum frmDepotMaterialTypeInOutSum = new frmDepotMaterialTypeInOutSum();
            frmDepotMaterialTypeInOutSum.Show(this);
        }

        private void tsbchmxz_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "chmxz") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmDepotMaterialDetailQry frmDepotMaterialDetailQry = new frmDepotMaterialDetailQry();
            frmDepotMaterialDetailQry.Show(this);
        }

        private void tsbkcpd_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "kcpd") == false)
            {
                this.ShowAlertMessage("�Բ�����û�иù��ܵĲ���Ȩ�ޣ��������Ա��ϵ��");
                return;
            }
            frmCheckBill frmCheckBill = new frmCheckBill();
            frmCheckBill.Show(this);
        }

        //���ֿ���ܱ�
        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            frmAllDepotSumQry frmAllDepotSumQry = new frmAllDepotSumQry();
            frmAllDepotSumQry.Show(this);
        }

     
    }
}