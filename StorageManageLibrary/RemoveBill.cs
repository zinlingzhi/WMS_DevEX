using System;
using System.Collections.Generic;
using System.Text;
using Bruce.Jin.DAO;
using System.Data;

namespace StorageManageLibrary
{
    /// <summary>
    /// ������ʵ��
    /// </summary>
    public class RemoveBill
    {
        #region Model
        private string _removebillguid;
        private string _checkperson;
        private DateTime? _checkdate;
        private string _remark;
        private DateTime? _billdate;
        private string _depotout;
        private string _depotin;
        private string _handleperson;
        private string _billid;
        private string _billautoid;
        private string _createperson;
        private DateTime? _createdate;
        /// <summary>
        /// 
        /// </summary>
        public string RemoveBillGuid
        {
            set { _removebillguid = value; }
            get { return _removebillguid; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public string CheckPerson
        {
            set { _checkperson = value; }
            get { return _checkperson; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public DateTime? CheckDate
        {
            set { _checkdate = value; }
            get { return _checkdate; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime? BillDate
        {
            set { _billdate = value; }
            get { return _billdate; }
        }
        /// <summary>
        /// �����ֿ�
        /// </summary>
        public string DepotOut
        {
            set { _depotout = value; }
            get { return _depotout; }
        }
        /// <summary>
        /// ����ֿ�
        /// </summary>
        public string DepotIn
        {
            set { _depotin = value; }
            get { return _depotin; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string HandlePerson
        {
            set { _handleperson = value; }
            get { return _handleperson; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string BillID
        {
            set { _billid = value; }
            get { return _billid; }
        }
        /// <summary>
        /// ���ݱ��
        /// </summary>
        public string BillAutoID
        {
            set { _billautoid = value; }
            get { return _billautoid; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string CreatePerson
        {
            set { _createperson = value; }
            get { return _createperson; }
        }
        /// <summary>
        /// �Ƶ�����
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model

    }
}
