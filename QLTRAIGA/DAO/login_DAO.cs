using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
   public class login_DAO
    {
        static SqlConnection connection;
        public static List<login_DTO> LayLogin()
        {
            string TruyVan = string.Format("select tendangnhap,matkhau,quyen from nhanvien");
            connection = Dataprovider.MoKetNoi();
            DataTable dt = Dataprovider.TruyVanLayDuLieu(TruyVan, connection);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<login_DTO> lstlg = new List<login_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                login_DTO lg = new login_DTO();
                lg.Tendangnhap = dt.Rows[i]["Tendangnhap"].ToString();
                lg.Matkhau = dt.Rows[i]["Matkhau"].ToString();
                lg.Quyen = int.Parse(dt.Rows[i]["Quyen"].ToString());
                lstlg.Add(lg);
            }
            return lstlg;
        }
        public static bool Login(string tendangnhap, string password)  //hàm login
        {
            string query = "select * from nhanvien where tendangnhap=N'" + tendangnhap + "' and matkhau =N'" + password + "'";
            connection = Dataprovider.MoKetNoi();
            DataTable dt = Dataprovider.TruyVanLayDuLieu(query, connection);
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            else
                return true;
        }
        public static bool Quyen(string tendangnhap, string password) // phanquyen
        {
            string query = "select * from nhanvien where tendangnhap=N'" + tendangnhap + "' and matkhau=N'" + password + "'and quyen =1";
            connection = Dataprovider.MoKetNoi();
            DataTable dt = Dataprovider.TruyVanLayDuLieu(query, connection);
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            else
                return true;
        }
        public static int LayQuyenTruyCapTaiKhoan(string tendangnhap)
        {
            string TruyVan = string.Format("select quyen from nhanvien where tendangnhap = N'{0}'", tendangnhap);
            connection = Dataprovider.MoKetNoi();
            DataTable dt = Dataprovider.TruyVanLayDuLieu(TruyVan, connection);
            if (dt.Rows.Count == 0)
            {
                return -1;
            }
            return int.Parse(dt.Rows[0]["quyen"].ToString());
        }
        public static string LayTenTaiKhoan(string username)
        {

            string TruyVan = "select * from nhanvien where tendangnhap = N'" + username + "'";
            connection = Dataprovider.MoKetNoi();
            DataTable dt = Dataprovider.TruyVanLayDuLieu(TruyVan, connection);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            return dt.Rows[0]["tennhanvien"].ToString();
        }
    }
}
