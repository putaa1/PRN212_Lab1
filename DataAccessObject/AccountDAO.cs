using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class AccountDAO : BaseDAL
    {
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        private AccountDAO() { }
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }
        //-----------------------------
        public AccountMember GetAccountMember(string accountId)
        {
            SqlDataReader dataReader = null;
            string SQL = "Select * from AccountMember where MemberID = @MemberID";
            AccountMember account = null;
            try
            {
                var param = StockDataProvider.CreateParameter("@MemberID", 20, accountId, DbType.String);
                dataReader = StockDataProvider.GetDataReader(SQL, CommandType.Text, param);
                if (dataReader.Read())
                {
                    account = new AccountMember()
                    {
                        MemberId = dataReader.GetString("MemberID"),
                        MemberPassword = dataReader.GetString("MemberPassword"),
                        FullName = dataReader.GetString("FullName"),
                        EmailAddress = dataReader.GetString("EmailAddress"),
                        MemberRole = dataReader.GetInt32("MemberRole")
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return account;
        }
    }
}
