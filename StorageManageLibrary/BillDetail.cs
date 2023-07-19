using System;
using System.Collections.Generic;
using System.Text;

namespace StorageManageLibrary
{
    public class BillDetail
    {

        #region Model
        private string _billdetailguid;
        private string _remark;
        private string _billguid;
        private string _materialguid;
        private string _materialid;
        private string _materialname;
        private string _barno;
        private string _spec;
        private string _unit;
        private decimal _price;
        private decimal _qty;
        private decimal _total;
        /// <summary>
        /// 
        /// </summary>
        public string BillDetailGuid
        {
            set { _billdetailguid = value; }
            get { return _billdetailguid; }
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
        public string BillGuid
        {
            set { _billguid = value; }
            get { return _billguid; }
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
        /// ����
        /// </summary>
        public decimal Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// ���
        /// </summary>
        public decimal Total
        {
            set { _total = value; }
            get { return _total; }
        }
        #endregion Model

    }
}
