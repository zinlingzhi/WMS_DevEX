using System;
using System.Collections.Generic;
using System.Text;
using Bruce.Jin.DAO;
using System.Data;

namespace StorageManageLibrary
{
    /// <summary>
    /// �̵㵥
    /// </summary>
    public class CheckBillDetail
    {

        #region Model
        private string _checkbilldetailguid;
        private decimal _deficientqty;
        private decimal _total;
        private string _remark;
        private string _checkbillguid;
        private string _materialguid;
        private string _materialid;
        private string _materialname;
        private string _barno;
        private string _spec;
        private string _unit;
        private decimal _price;
        private decimal _surplusqty;
        /// <summary>
        /// 
        /// </summary>
        public string CheckBillDetailGuid
        {
            set { _checkbilldetailguid = value; }
            get { return _checkbilldetailguid; }
        }
        /// <summary>
        /// �̿�����
        /// </summary>
        public decimal DeficientQty
        {
            set { _deficientqty = value; }
            get { return _deficientqty; }
        }
        /// <summary>
        /// ���
        /// </summary>
        public decimal Total
        {
            set { _total = value; }
            get { return _total; }
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
        /// ���ݱ�ͷGuid
        /// </summary>
        public string CheckBillGuid
        {
            set { _checkbillguid = value; }
            get { return _checkbillguid; }
        }
        /// <summary>
        /// ��Ʒguid
        /// </summary>
        public string MaterialGuid
        {
            set { _materialguid = value; }
            get { return _materialguid; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string MaterialID
        {
            set { _materialid = value; }
            get { return _materialid; }
        }
        /// <summary>
        /// Ʒ��
        /// </summary>
        public string MaterialName
        {
            set { _materialname = value; }
            get { return _materialname; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string BarNo
        {
            set { _barno = value; }
            get { return _barno; }
        }
        /// <summary>
        /// ���
        /// </summary>
        public string Spec
        {
            set { _spec = value; }
            get { return _spec; }
        }
        /// <summary>
        /// ��λ
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// ��ӯ����
        /// </summary>
        public decimal SurplusQty
        {
            set { _surplusqty = value; }
            get { return _surplusqty; }
        }
        #endregion Model
    }
}
