//using System.Data.SqlClient;
//using System.Data.OleDb;
using System;
using System.Data;

namespace Bruce.Jin.DAO
{
	/// <summary>
	/// ���ߣ���־��(Bruce Jin)
	/// ���ã������ݿ�ͨ�ò����Ľӿڡ�
	/// ���ڣ�2005-04-24
	/// </summary>
	public interface CommonInterface
	{
		/// <summary>
		/// ��ʼһ������
		/// </summary>
		/// <example>ʾ����
		///	<code>
		///	using Bruce.Jin.DAO;
		///	
		///	//����ʹ��Ĭ���������ӵ�SQL���ݷ��ʽӿ�
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	
		///	//��ʼһ������
		///	pComm.BeginTrans();
		///	
		///	//
		///	//����һЩ���ݷ��ʲ����Ĵ���
		///	//
		///	
		///	//�ύ���ε�����
		///	pComm.CommitTrans();
		///	
		///	//�ر����ݿ�����
		///	pComm.Close();
		///	</code>
		/// </example>
		void BeginTrans();

		/// <summary>
		/// �ύһ������
		/// </summary>
		/// <example>ʾ����
		///	<code>
		///	using Bruce.Jin.DAO;
		///	
		///	//����ʹ��Ĭ���������ӵ�SQL���ݷ��ʽӿ�
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	
		///	//��ʼһ������
		///	pComm.BeginTrans();
		///	
		///	//
		///	//����һЩ���ݷ��ʲ����Ĵ���
		///	//
		///	
		///	//�ύ���ε�����
		///	pComm.CommitTrans();
		///	
		///	//�ر����ݿ�����
		///	pComm.Close();
		///	</code>
		/// </example>
		void CommitTrans();

		/// <summary>
		/// �ع�һ������
		/// </summary>
		/// <example>ʾ����
		///	<code>
		///	using Bruce.Jin.DAO;
		///	
		///	//����ʹ��Ĭ���������ӵ�SQL���ݷ��ʽӿ�
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	
		///	//��ʼһ������
		///	pComm.BeginTrans();
		///	
		///	try
		///	{
		///			//
		///			//����һЩ���ݷ��ʲ����Ĵ���
		///			//
		///	
		///			//�ύ���ε�����
		///			pComm.CommitTrans();
		///			
		///			//�ر����ݿ�����
		///			pComm.Close();
		///	}
		///	catch(Exception ex)
		///	{
		///			//
		///			//�Լ��Ĵ���
		///			//
		///			
		///			//�ع��˴����ݲ���
		///			pComm.RollbackTrans();
		///			
		///			//�ر����ݿ�����
		///			pComm.Close();
		///	}
		///		
		///	</code>
		/// </example>
		void RollbackTrans();

		/// <summary>
		/// ִ��SQL���
		/// </summary>
		/// <param name="sql">SQL���</param>
		/// <example>ʾ����
		///	<code>
		///	using Bruce.Jin.DAO;
		///	
		///	//����ʹ��Ĭ���������ӵ�SQL���ݷ��ʽӿ�
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	
		///	//��ʼһ������
		///	pComm.BeginTrans();
		///	
		///	//����һЩ���ݷ��ʲ����Ĵ���
		///	string pSql="";
		///	
		///	pSql="select * from YourTable";
		///	
		///	//ִ�д˴����ݲ���
		///	pComm.Execute(pSql);
		///	
		///	//�ύ���ε�����
		///	pComm.CommitTrans();
		///	//�ر����ݿ�����
		///	pComm.Close();
		///	</code>
		/// </example>		
		void Execute(String sql);


		/// <summary>
		/// ִ��SQL��䣬��䵽ָ����DataTable�У�����DataSet
		/// </summary>
		/// <param name="QueryString">SQL���</param>
		/// <param name="strTable">DataTable������</param>
		/// <returns>DataSet���ݼ���</returns>
		DataSet ExeForDst(String QueryString, String strTable);

		/// <summary>
		/// ִ��һ��SQL��䣬����DataSet�����
		/// </summary>
		/// <param name="QueryString">SQL���</param>
		/// <returns>DataSet�����</returns>
		/// <example>ʾ����
		///	<code>
		///	using Bruce.Jin.DAO;
		///	
		///	//����ʹ��Ĭ���������ӵ�SQL���ݷ��ʽӿ�
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	
		///	//��ʼһ������
		///	pComm.BeginTrans();
		///	
		///	string pSql="";
		///	DataSet pDst=new DataSet();
		///	
		///	//����һЩ���ݷ��ʲ����Ĵ���
		///	pSql="select * from YourTable";
		///	
		///	//ִ�д˴����ݲ���
		///	pDst=pComm.ExeForDst(pSql);
		///	
		///	//�ύ���ε�����
		///	pComm.CommitTrans();
		///	//�ر����ݿ�����
		///	pComm.Close();
		///	</code>
		/// </example>		
		DataSet ExeForDst(String QueryString);

		/// <summary>
		/// ִ��SQL��䣬����DataTable
		/// </summary>
		/// <param name="QueryString">SQL���</param>
		/// <param name="TableName">DataTable������</param>
		/// <returns>DataTable�Ľ����</returns>
		/// <example>ʾ����
		///	<code>
		///	using Bruce.Jin.DAO;
		///	
		///	//����ʹ��Ĭ���������ӵ�SQL���ݷ��ʽӿ�
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	
		///	//��ʼһ������
		///	pComm.BeginTrans();
		///	
		///	string pSql="";
		///	DataTable pDst=new DataTable();
		///	
		///	//����һЩ���ݷ��ʲ����Ĵ���
		///	pSql="select * from YourTable";
		///	
		///	//ִ�д˴����ݲ���
		///	pDst=pComm.ExeForDtl(pSql,"UserInfo");
		///	
		///	//�ύ���ε�����
		///	pComm.CommitTrans();
		///	//�ر����ݿ�����
		///	pComm.Close();
		///	</code>
		/// </example>			
		DataTable ExeForDtl(String QueryString, String TableName);

		/// <summary>
		/// ִ��SQL��䣬����Ĭ��DataTable
		/// </summary>
		/// <param name="QueryString">SQL���</param>
		/// <returns>DataTable�����</returns>
		/// <example>ʾ����
		///	<code>
		///	using Bruce.Jin.DAO;
		///	
		///	//����ʹ��Ĭ���������ӵ�SQL���ݷ��ʽӿ�
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	
		///	//��ʼһ������
		///	pComm.BeginTrans();
		///	
		///	string pSql="";
		///	DataTable pDst=new DataTable();
		///	
		///	//����һЩ���ݷ��ʲ����Ĵ���
		///	pSql="select * from YourTable";
		///	
		///	//ִ�д˴����ݲ���
		///	pDst=pComm.ExeForDtl(pSql);
		///	
		///	//�ύ���ε�����
		///	pComm.CommitTrans();
		///	
		///	//�ر����ݿ�����
		///	pComm.Close();
		///	</code>
		/// </example>	
		DataTable ExeForDtl(String QueryString);

		/// <summary>
		/// ִ��SQL��䣬����IDataReader�ӿ�
		/// </summary>
		/// <param name="QueryString">SQL���</param>
		/// <returns>IDataReader�ӿ�</returns>
		IDataReader ExeForDtr(String QueryString);

		/// <summary>
		/// ����IDbCommand�ӿ�
		/// </summary>
		/// <returns>IDbCommand�ӿ�</returns>
		IDbCommand GetCommand();

		/// <summary>
		/// �����ݿ�����
		/// </summary>
		void Open();

		/// <summary>
		/// �ر����ݿ�����
		/// </summary>
		void Close();

		/// <summary>
		/// ����ִ�д��в�����SQL��䣨���Ǵ洢���̣�
		/// </summary>
		/// <param name="SQLText">���в�����SQL���</param>
		/// <param name="Parameters">���ݵĲ����б�</param>
		/// <param name="ParametersValue">ͬ�����б���Ӧ�Ĳ���ֵ�б�</param>
		void ExecuteNonQuery(string SQLText, string[] Parameters, string[] ParametersValue);

		/// <summary>
		/// ִ�ж�sql���
		/// </summary>
		int ExecuteSqls(string[] strSQLs);

		/// <summary>
		/// ִ��һ��SQL��䣬����DataSet�����
		/// </summary>
		/// <param name="QueryString">SQL���</param>
		/// <param name="pDS">ָ��DataSet</param>
		/// <param name="pTableName">pTableName</param>
		/// <returns>DataSet�����</returns>
		DataSet ExeForFillDst(String QueryString,DataSet pDS,String pTableName);

		/// <summary>
		/// ִ�д洢����
		/// </summary>
		/// <param name="StoredProcedureName">�洢���̵�����</param>
		/// <param name="Parameters">���ݵĲ����б�</param>
		/// <param name="ParametersValue">ͬ�����б���Ӧ�Ĳ���ֵ�б�</param>
		/// <param name="ParametersType">ͬ�����б���Ӧ�Ĳ��������б�</param>
		void ExecuteSP(string StoredProcedureName, string[] Parameters, string[] ParametersValue, string[] ParametersType);

		/// <summary>
		/// ִ�д洢���̷���bool
		/// </summary>
		/// <param name="StoredProcedureName">�洢������</param>
		/// <param name="ParametersNames">���������</param>
		/// <param name="ParametersValue">�������ֵ</param>
		/// <returns>bool</returns>
		bool ExecuteSP(string StoredProcedureName, string[] ParametersNames, object[] ParametersValue);

		/// <summary>
		/// ִ�д洢���̷���DataTable
		/// </summary>
		/// <param name="StoredProcedureName">�洢������</param>
		/// <param name="ParametersNames">���������</param>
		/// <param name="ParametersValue">�������ֵ</param>
		/// <returns>DataTable</returns>
		DataTable ExecuteSPForDtl(string StoredProcedureName, string[] ParametersNames, object[] ParametersValue);

        ///<summary>
        /// ִ�д洢����,�õ������DataSet
        /// </summary>
        /// <param name="sqname">�洢��������</param>
        /// <param name="array">����������ֵ������</param>
        /// <returns>����True��False</returns>
        DataSet ExcuteSp(string sqname, string[,] array);


		/// <summary>
		/// ִ��sql��䷵�ص�һ�е�һ�е�ֵ
		/// </summary>
		object ExecuteScalar(String QueryString);

		/// <summary>
		/// getDataAdapter
		/// </summary>
		IDataAdapter getDataAdapter(string sql);

		/// <summary>
		/// getCommandBuilder
		/// </summary>
		ICommandBuilder getCommandBuilder();

	}
}