using System.Configuration;

namespace Bruce.Jin.DAO
{
	/// <summary>
	/// ���ߣ���־��(Bruce Jin)
	/// ���ã��������ݿ�Ĭ�������ַ����������ࡣ
	/// ���ڣ�2005-04-24
	/// </summary>
	public class CommonDataConfig
	{
        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>
        //public static string ConnectionDefaultStr = "server=grd4-bruce-jin;database=readsystem;uid=sa;pwd=liuandliu";
        [System.Obsolete]
        public static string ConnectionDefaultStr = ConfigurationSettings.AppSettings["ConnStr"];

        /// <summary>
        /// CommonDataConfig
        /// </summary>
        [System.Obsolete]
        public CommonDataConfig()
		{
			try
			{
				ConnectionDefaultStr = ConfigurationSettings.AppSettings["ConnStr"];
//				if (ConnectionDefaultStr != null)
//				{
//					byte[] data = Convert.FromBase64String(ConnectionDefaultStr);
//					ConnectionDefaultStr = ASCIIEncoding.ASCII.GetString(data);
//				}
//				byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(this.textBox1.Text); 
//				string str = Convert.ToBase64String(data);
			}
			catch
			{
				ConnectionDefaultStr = null;
			}
		}
	}
}