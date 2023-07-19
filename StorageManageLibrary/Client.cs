using System;
using System.Collections.Generic;
using System.Text;
using Bruce.Jin.DAO;
using System.Data;


namespace StorageManageLibrary
{
    /// <summary>
    /// ��Ӧ��
    /// </summary>
    public class Client
    {
   	#region Model
		private string _guid;
		private string _name;
		private string _simpname;
		private string _linkman;
		private string _telephone;
		private string _fax;
		private string _address;
		private string _zip;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public string Guid
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// ��Ӧ������
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// ���
		/// </summary>
		public string SimpName
		{
			set{ _simpname=value;}
			get{return _simpname;}
		}
		/// <summary>
		/// ��ϵ��
		/// </summary>
		public string LinkMan
		{
			set{ _linkman=value;}
			get{return _linkman;}
		}
		/// <summary>
		/// ��ϵ�绰
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// ��ϵ��ַ
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// �ʱ�
		/// </summary>
		public string Zip
		{
			set{ _zip=value;}
			get{return _zip;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model


		#region  ��Ա����
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Client](");
			strSql.Append("Guid,Name,SimpName,LinkMan,Telephone,Fax,Address,Zip,Remark");
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append("'"+Guid+"',");
			strSql.Append("'"+Name+"',");
			strSql.Append("'"+SimpName+"',");
			strSql.Append("'"+LinkMan+"',");
			strSql.Append("'"+Telephone+"',");
			strSql.Append("'"+Fax+"',");
			strSql.Append("'"+Address+"',");
			strSql.Append("'"+Zip+"',");
			strSql.Append("'"+Remark+"'");
			strSql.Append(")");
			 CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);

            try
            {
                pComm.Execute(strSql.ToString());//ִ��Sql����޷���ֵ
                pComm.Close();
                return true;
            }
            catch (System.Exception e)
            {
                pComm.Close();
                throw e;
            }		
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Client set ");
			strSql.Append("Name='"+Name+"',");
			strSql.Append("SimpName='"+SimpName+"',");
			strSql.Append("LinkMan='"+LinkMan+"',");
			strSql.Append("Telephone='"+Telephone+"',");
			strSql.Append("Fax='"+Fax+"',");
			strSql.Append("Address='"+Address+"',");
			strSql.Append("Zip='"+Zip+"',");
			strSql.Append("Remark='"+Remark+"'");
			strSql.Append(" where Guid='"+Guid+"' ");
			 CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);

            try
            {
                pComm.Execute(strSql.ToString());//ִ��Sql����޷���ֵ
                pComm.Close();
                return true;
            }
            catch (System.Exception e)
            {
                pComm.Close();
                throw e;
            }		
		}
		#endregion  ��Ա����
	}
}

