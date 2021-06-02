using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DAO
{
    public class CSDL_DAO
    {
        static SqlConnection con;
        public static bool SaoLuuDuLieu(string sDuongDan)
        {
            string sTen = "\\QUANLYTRAIGA(" + DateTime.Now.Day.ToString() + "_" +
            DateTime.Now.Month.ToString() + "_" +
            DateTime.Now.Year.ToString() + "_" +
            DateTime.Now.Hour.ToString() + "_" +
            DateTime.Now.Minute.ToString() + ").bak";
            string sql = "BACKUP DATABASE QUANLYTRAIGA TO DISK = N'" + sDuongDan +
            sTen + "'";
            con = Dataprovider.MoKetNoi();
            bool kq = Dataprovider.TruyVanKhongLayDuLieu(sql, con);
            return kq;
        }
        public static bool PhucHoiDuLieu(string sDuongDan)
        {
            try
            {
                con = Dataprovider.MoKetNoi();
                SqlCommand cmd1 = new SqlCommand("ALTER DATABASE QUANLYTRAIGA SET SINGLE_USER WITH ROLLBACK IMMEDIATE ", con);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("USE MASTER RESTORE DATABASE QUANLYTRAIGA FROM DISK='" + sDuongDan + "' WITH REPLACE", con);
                cmd2.ExecuteNonQuery();
                SqlCommand cmd3 = new SqlCommand("ALTER DATABASE QUANLYTRAIGA SET MULTI_USER", con);
                cmd3.ExecuteNonQuery();
                con.Close();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
