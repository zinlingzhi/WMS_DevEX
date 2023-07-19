using System.Data;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace Bruce.Jin.DAO
{
	/// <summary>
	/// ���
	/// ��ado.net�и������ݿ�������͵�CommandBuilder��һ����
	/// 
	/// </summary>
	public interface ICommandBuilder
	{
		/// <summary>
		/// ��������������
		/// </summary>
		/// <param name="da"></param>
		void SetDataAdapter(IDataAdapter da);
	}

	/// <summary>
	/// oracle
	/// </summary>
	public class OracleCmdBuilder : ICommandBuilder
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="da"></param>
		public void SetDataAdapter(IDataAdapter da)
		{
			OracleCommandBuilder cb = new OracleCommandBuilder((OracleDataAdapter) da);
		}
	}


	/// <summary>
	/// sql����������������
	/// </summary>
	public class SqlCmdBuilder : ICommandBuilder
	{
		/// <summary>
		/// ��������������
		/// </summary>
		/// <param name="da">sql����������</param>
		public void SetDataAdapter(IDataAdapter da)
		{
			SqlCommandBuilder cb = new SqlCommandBuilder((SqlDataAdapter) da);
		}
	}

	/// <summary>
	/// oledb����������������
	/// </summary>
	public class OleDbCmdBuilder : ICommandBuilder
	{
		/// <summary>
		/// ��������������
		/// </summary>
		/// <param name="da">oledb����������</param>
		public void SetDataAdapter(IDataAdapter da)
		{
			OleDbCommandBuilder cb = new OleDbCommandBuilder((OleDbDataAdapter) da);
		}
	}


}