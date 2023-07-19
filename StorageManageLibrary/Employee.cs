using System;
using System.Collections.Generic;
using System.Text;
using Bruce.Jin.DAO;

namespace StorageManageLibrary
{
    public class Employee
    {
    	#region Model
		private string _empguid;
		private string _empid;
		private string _empname;
		private string _sex;
		private string _telephone;
		private string _address;
		private string _cardid;
		private string _dept;
		/// <summary>
		/// Ψһ��
		/// </summary>
		public string EmpGuid
		{
			set{ _empguid=value;}
			get{return _empguid;}
		}
		/// <summary>
		/// Ա�����
		/// </summary>
		public string EmpID
		{
			set{ _empid=value;}
			get{return _empid;}
		}
		/// <summary>
		/// Ա������
		/// </summary>
		public string EmpName
		{
			set{ _empname=value;}
			get{return _empname;}
		}
		/// <summary>
		/// �Ա�
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
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
		/// ��ϵ��ַ
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// ����֤��
		/// </summary>
		public string CardID
		{
			set{ _cardid=value;}
			get{return _cardid;}
		}
		/// <summary>
		/// ���ڲ���
		/// </summary>
		public string Dept
		{
			set{ _dept=value;}
			get{return _dept;}
		}
		#endregion Model


		#region  ��Ա����

		


		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Employee](");
			strSql.Append("EmpGuid,EmpID,EmpName,Sex,Telephone,Address,CardID,Dept");
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append("'"+EmpGuid+"',");
			strSql.Append("'"+EmpID+"',");
			strSql.Append("'"+EmpName+"',");
			strSql.Append("'"+Sex+"',");
			strSql.Append("'"+Telephone+"',");
			strSql.Append("'"+Address+"',");
			strSql.Append("'"+CardID+"',");
			strSql.Append("'"+Dept+"'");
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
			strSql.Append("update Employee set ");
			strSql.Append("EmpID='"+EmpID+"',");
			strSql.Append("EmpName='"+EmpName+"',");
			strSql.Append("Sex='"+Sex+"',");
			strSql.Append("Telephone='"+Telephone+"',");
			strSql.Append("Address='"+Address+"',");
			strSql.Append("CardID='"+CardID+"',");
			strSql.Append("Dept='"+Dept+"'");
			strSql.Append(" where EmpGuid='"+EmpGuid+"' ");
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

