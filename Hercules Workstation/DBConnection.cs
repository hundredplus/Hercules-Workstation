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

        //Production -Select
        public DataTable getProduction(String prodCode)
        {
            DataTable result = new DataTable();
            try
            {
                if (mySQLConn.State != ConnectionState.Open) mySQLConn.Open();
                String sqlQuery = "SELECT code, serial_no, start_dt, end_dt, product_marking_code, table_number, process_number, status, work_type, project_code, current_loc_number " +
                    " FROM production  WHERE code = @prodCode";
                mysqlDA = new MySqlDataAdapter(sqlQuery, mySQLConn);
                mysqlDA.SelectCommand.Parameters.Add("@prodCode", MySqlDbType.VarChar).Value = prodCode;
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

        /**************************************************/
        //Station - Select
        public DataTable getStationDetail(String stationNo)
        {
            DataTable result = new DataTable();
            try
            {
                if (mySQLConn.State != ConnectionState.Open) mySQLConn.Open();
                String sqlQuery = "SELECT a.number, a.location_number, a.process_number, a.status, b.name as process_name " +
                    " FROM station a  " +
                    " JOIN process b ON a.process_number = b.number AND a.project_code = b.project_code" +
                    " WHERE a.number=@stationNo ";
                mysqlDA = new MySqlDataAdapter(sqlQuery, mySQLConn);
                mysqlDA.SelectCommand.Parameters.Add("@stationNo", MySqlDbType.VarChar).Value = stationNo;
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

        //Station - Select
        public DataTable getStationByNumber(String stationNo)
        {
            DataTable result = new DataTable();
            try
            {
                if (mySQLConn.State != ConnectionState.Open) mySQLConn.Open();
                String sqlQuery = "SELECT number, location_number, process_number, status FROM station  " +
                    " WHERE number=@stationNo ";
                mysqlDA = new MySqlDataAdapter(sqlQuery, mySQLConn);
                mysqlDA.SelectCommand.Parameters.Add("@stationNo", MySqlDbType.VarChar).Value = stationNo;
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

        //Project -Select by status
        public DataTable getAllProjectByStatus(int status)
        {
            DataTable result = new DataTable();
            try
            {
                if (mySQLConn.State != ConnectionState.Open) mySQLConn.Open();

                String sqlQuery = "SELECT code, name, client, description, start_dt, end_dt, status, create_by, create_dt " +
                    " FROM project " +
                    " WHERE status=@status ORDER BY create_dt";
                mysqlDA = new MySqlDataAdapter(sqlQuery, mySQLConn);
                mysqlDA.SelectCommand.Parameters.Add("@status", MySqlDbType.Int32).Value = status;
                mysqlDA.Fill(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (mySQLConn != null) mySQLConn.Close();
            }

            return result;
        }

        //Process - Select
        public DataTable getProcessByProjectCodeAndStation(String projectCode, String stationNo)
        {
            DataTable result = new DataTable();
            try
            {
                if (mySQLConn.State != ConnectionState.Open) mySQLConn.Open();
                String sqlQuery = "SELECT a.name, a.number " +
                    " FROM process a " +
                    " JOIN station b ON a.number = b.process_number AND a.project_code = b.project_code " +
                    " WHERE b.number=@stationNo AND a.project_code=@projectCode ";
                mysqlDA = new MySqlDataAdapter(sqlQuery, mySQLConn);
                mysqlDA.SelectCommand.Parameters.Add("@stationNo", MySqlDbType.VarChar).Value = stationNo;
                mysqlDA.SelectCommand.Parameters.Add("@projectCode", MySqlDbType.VarChar).Value = projectCode;
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

