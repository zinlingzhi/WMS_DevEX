using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using Bruce.Jin.DAO;
using System.Data;

namespace StorageManageLibrary
{
    /// <summary>
    /// ��½�û�����������
    /// </summary>
    public class LoginUserManage 
    {

        ///<summary>
        /// ��������
        /// </summary>
        /// <param name="pObj">��Ϣ��ʵ����</param>
        /// <returns>���ر���ɹ�(true)��ʧ��(false)</returns>
        public bool Save(LoginUser pObj)
        {
            try
            {
                if (SaveStatus(pObj) == false)
                {
                    return pObj.Add();
                }
                else
                {

                    return pObj.Update();
                }
            }
            catch (Exception e)
            {
                throw e;

            }
        }


        ///<summary>
        /// �õ���ǰ������״̬�����޸�״̬
        /// </summary>
        /// <param name="pObj">��Ϣ��ʵ��</param>
        /// <returns>����True��False</returns>
        public bool SaveStatus(LoginUser pObj)
        {
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string pSql = "";
                pSql = "SELECT USERID  FROM   LoginUser  " +
                    "where USERID ='" + pObj.USERID + "'";
                DataTable pDT = pComm.ExeForDtl(pSql);
                pComm.Close();
                if (pDT.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }


        ///<summary>
        /// �����������ؽ����ѯ
        /// </summary>
        /// <param name="tableid">SQL��ѯ����</param>
        /// <returns>��Ų�ѯ�����DataTable</returns>
        public DataTable GetLoginUserInfo()
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataTable dtl = new DataTable();
                string StrSQL = " select  *   from LoginUser ";

                dtl = pComm.ExeForDtl(StrSQL);
                pComm.Close();
                return dtl;
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }


        ///<summary>
        /// �����������ؽ����ѯ
        /// </summary>
        /// <param name="tableid">SQL��ѯ����</param>
        /// <returns>��Ų�ѯ�����DataTable</returns>
        public DataTable GetLoginUserInfo_CN()
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataTable dtl = new DataTable();
                string StrSQL = " select  USERID �û��˺�,USERNAME �û���������,Email   from LoginUser ";

                dtl = pComm.ExeForDtl(StrSQL);
                pComm.Close();
                return dtl;
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

        /// <summary>
        /// ����û�����������ȷ��
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckUserPassword(string userid, string password)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataTable dtl = new DataTable();
                string StrSQL = " select userid,password   from LoginUser where userid='" + userid + "'";

                dtl = pComm.ExeForDtl(StrSQL);
                pComm.Close();

                //У��������ȷ��
                if (dtl.Rows.Count > 0)
                {
                    string password2 = EncryptDES(password, "ABCD1234"); //�û����������
                    if (password2 == dtl.Rows[0]["PASSWORD"].ToString())  //�û���������������ݿ�������Ƚ�
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LoginUser GetLoginUser(string USERID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append("USERID,USERNAME,EMAIL,PASSWORD ");
            strSql.Append(" from LOGINUSER ");
            strSql.Append(" where USERID='" + USERID + "'");
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);

            try
            {
                LoginUser lu = new LoginUser();
                DataSet ds = new DataSet();
                ds = pComm.ExeForDst(strSql.ToString());//ִ��Sql��䷵��DataSet
                pComm.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lu.USERID = ds.Tables[0].Rows[0]["USERID"].ToString();
                    lu.USERNAME = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                    lu.EMAIL = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                    lu.PASSWORD = ds.Tables[0].Rows[0]["PASSWORD"].ToString();
                }

                return lu;
            }
            catch (System.Exception e)
            {
                pComm.Close();
                throw e;
            }
        }

        ///<summary>
        /// �����������ؽ����ѯ
        /// </summary>
        /// <param name="tableid">SQL��ѯ����</param>
        /// <returns>��Ų�ѯ�����DataTable</returns>
        public bool ChangePassword(string userid, string oldpassword, string newpassword)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string StrSQL = " update LoginUser set PASSWORD='" + EncryptDES(newpassword, "ABCD1234")
                            + "' where USERID='" + userid + "' and PASSWORD='" + EncryptDES(oldpassword, "ABCD1234") + "'";

                pComm.Execute(StrSQL);
                pComm.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }


        ///<summary>
        /// �����������ؽ����ѯ
        /// </summary>
        /// <param name="tableid">SQL��ѯ����</param>
        /// <returns>��Ų�ѯ�����DataTable</returns>
        public bool DeleteLoginUser(string userid)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {

                string StrSQL = "delete from  LoginUser  where USERID='" + userid + "'";

                pComm.Execute(StrSQL);
                pComm.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }







        //Ĭ����Կ����
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// <summary>
        /// DES�����ַ���
        /// </summary>
        /// <param name="encryptString">�����ܵ��ַ���</param>
        /// <param name="encryptKey">������Կ,Ҫ��Ϊ8λ</param>
        /// <returns>���ܳɹ����ؼ��ܺ���ַ�����ʧ�ܷ���Դ��</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES�����ַ���
        /// </summary>
        /// <param name="decryptString">�����ܵ��ַ���</param>
        /// <param name="decryptKey">������Կ,Ҫ��Ϊ8λ,�ͼ�����Կ��ͬ</param>
        /// <returns>���ܳɹ����ؽ��ܺ���ַ�����ʧ�ܷ�Դ��</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

    }
}
