using System;

namespace Bruce.Jin.DAO
{
	/// <summary>
	/// ���ߣ���־��(Bruce Jin)
	/// ���ã���������ö�١�
	/// ���ڣ�2005-04-24
	/// </summary>
	public enum CommonData
	{
		/// <summary>
		/// ��SQL Server��ʽ
		/// </summary>
		sql = 1,
		/// <summary>
		/// ��OLEDB��ʽ
		/// </summary>
		oledb = 2,
		/// <summary>
		/// ��oracle��ʽ
		/// </summary>
		Oracle = 3,
	} ;

	/// <summary>
	/// ���ߣ���־��(Bruce Jin)
	/// ���ã� ���ݿ���ʹ����ࡣ
	/// ���ڣ�2005-04-24
	/// </summary>
	public class CommonFactory
	{
		/// <summary>
		/// ����һ�����ݷ��ʽӿ�
		/// </summary>
		/// <param name="CommonData_Parameter">���ݷ�������</param>
		/// <returns>CommonInterface�ӿ�</returns>
		/// <example>ʾ����
		///	<code>
		///	using Bruce.Jin.DAO;
		///	����ʹ��Ĭ���������ӵ�SQL���ݷ��ʽӿ�
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql);
		///	</code>
		/// </example>
		public static CommonInterface CreateInstance(CommonData CommonData_Parameter)
		{
			switch ((int) CommonData_Parameter)
			{
				case 1:
					return new CommonSql();
				case 2:
					return new CommonOle();
				case 3:
					return new CommonOracle();
				default:
					return new CommonSql();
			}
		}

		/// <summary>
		/// ����һ�����ݷ��ʽӿ�
		/// </summary>
		/// <param name="CommonData_Parameter">���ݷ�������</param>
		/// <param name="connstr">���ݿ�����Ӵ�</param>
		/// <returns>CommonInterface�ӿ�</returns>
		/// <example>ʾ����
		///	<code>
		///	using Bruce.Jin.DAO;	
		///	string pConnectionString="";	
		///	ConnectionDefaultStr = "server=grd4-bruce-jin;database=readsystem;uid=sa;pwd=liuandliu";
		///	����ʹ��Ĭ���������ӵ�SQL���ݷ��ʽӿ�
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	</code>
		/// </example>
		public static CommonInterface CreateInstance(CommonData CommonData_Parameter, String connstr)
		{
			switch ((int) CommonData_Parameter)
			{
				case 1:
					return new CommonSql(connstr);
				case 2:
					return new CommonOle(connstr);
				case 3:
					return new CommonOracle(connstr);
				default:
					return new CommonSql(connstr);
			}
		}

	}
}