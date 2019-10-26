using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IU_Inventory_Management
{
    class Database
    {
        static SqlConnection _con;
        static SqlCommand _cmd;
        static DataTable _dt;
        static SqlDataAdapter _da;
        public static int _idUser;
        public static string    _userName;
        public static bool _userAdmin;
        public static string getConnectionString()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader("connectionString.txt");
            string fileReader = sr.ReadLine();
            sr.Close();
            return fileReader;
        }
        public static SqlConnection getConnection()
        {
            String data = getConnectionString(); //Utilities.getData();
            _con = new SqlConnection(data);
            _con.Open();
            return _con;
        }
        public static void executeSql(string sql)
        {
            if (_con == null)
                _con = getConnection();
            _cmd = new SqlCommand(sql, _con);
            _cmd.ExecuteNonQuery();
            //_cmd.Dispose();
            //_cmd = null;
        }
        public static bool authentication(string sql)
        {
            bool authentication = false;
            if (_con == null)
                _con = getConnection();
            _cmd = new SqlCommand(sql, _con);
            SqlDataReader dr = _cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    _idUser = Convert.ToInt16(dr[0]);
                    _userName = dr[1].ToString();
                    _userAdmin = Convert.ToBoolean(dr[4]);
                }
                authentication = true;
            }
            dr.Close();
            //_cmd.Dispose();
            //_cmd = null;
            return authentication;
        }
        public static bool hashRecord(string sql)
        {
            bool hashRecord = false;
            if (_con == null)
                _con = getConnection();
            _cmd = new SqlCommand(sql, _con);
            SqlDataReader dr = _cmd.ExecuteReader();
            if (dr.HasRows)
            {
                hashRecord = true;
            }
            dr.Close();
            //_cmd.Dispose();
            //_cmd = null;
            return hashRecord;
        }
        public static void executeProce(string spName, Dictionary<string, object> param)
        {
            if (_con == null)
                _con = getConnection();
            _cmd = new SqlCommand(spName, _con);
            _cmd.CommandType = CommandType.StoredProcedure;
            foreach (string key in param.Keys)
            {
                _cmd.Parameters.AddWithValue("@" + key, param[key]);
                //_cmd.Parameters.AddWithValue("@" + key, SqlDbType.NVarChar).Value = param[key];

            }
            _cmd.ExecuteNonQuery();
            //_cmd.Dispose();
            //_cmd = null;
        }
        public static DataTable getData(string sql)
        {
            if (_con == null)
                _con = getConnection();
            _dt = new DataTable();
            _da = new SqlDataAdapter(sql, _con);
            _da.Fill(_dt);
            return _dt;
        }
    }
}
