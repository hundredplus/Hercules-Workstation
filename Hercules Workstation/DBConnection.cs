using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hercules_Workstation
{
    class DBConnection
    {
        public MySqlConnection mySQLConn = null;
        MySqlDataAdapter mysqlDA = null;
        MySqlTransaction mysqlTran = null;
        String mySQLString = "SERVER=localhost;DATABASE=excelagv;UID=root;PASSWORD=abcd1234;";

        public DBConnection()
        {
            mySQLConn = new MySqlConnection(mySQLString);
        }

        ~DBConnection()
        {
            if (mySQLConn != null) mySQLConn.Close();
        }

        public MySqlConnection getConnection()
        {
            return mySQLConn;
        }

        public MySqlDataAdapter getDataAdapter()
        {
            return mysqlDA;
        }

        /***************************************************************************************/
        //Production - Update status
        public void updateProduction(String productCode, int new_status)
        {
            String sqlQuery = "UPDATE production SET status = @new_status WHERE code = @code";
            try
            {
                if (mySQLConn.State != ConnectionState.Open) mySQLConn.Open();
                mysqlTran = mySQLConn.BeginTransaction();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = mySQLConn;
                cmd.Transaction = mysqlTran;

                cmd.CommandText = sqlQuery;
                cmd.Parameters.AddWithValue("@new_status", new_status);
                cmd.Parameters.AddWithValue("@code", productCode);
                cmd.ExecuteNonQuery();
                mysqlTran.Commit();
            }
            catch (Exception ex)
            {
                mysqlTran.Rollback();
            }
            finally
            {
                if (mySQLConn != null) mySQLConn.Close();
            }

        }

        /***********************************************/
        //work_station_view
        public DataTable getWorkstationView(int locationNo)
        {
            DataTable result = new DataTable();
            try
            {
                if (mySQLConn.State != ConnectionState.Open) mySQLConn.Open();
                String sqlQuery = "SELECT production_code " +
                    " FROM work_station_view  WHERE location_number = @locationNo ";
                mysqlDA = new MySqlDataAdapter(sqlQuery, mySQLConn);
                mysqlDA.SelectCommand.Parameters.Add("@locationNo", MySqlDbType.Int32).Value = locationNo;
                mysqlDA.Fill(result);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (mySQLConn != null) mySQLConn.Close();
            }

            return result;
        }

    }

}

