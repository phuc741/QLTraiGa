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
    public class NhanVien_DAO
    {
        static SqlConnection connection;
        public static List<NhanVien_DTO> LayNhanVien()
        {
            string TruyVan = string.Format("select *from nhanvien");
            connection = Dataprovider.MoKetNoi();
            DataTable dt = Dataprovider.TruyVanLayDuLieu(TruyVan, connection);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<NhanVien_DTO> lstNhanVien = new List<NhanVien_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVien_DTO NhanVien = new NhanVien_DTO();
                NhanVien.Id = int.Parse(dt.Rows[i]["id"].ToString());
                NhanVien.Tennhanvien = dt.Rows[i]["Tennhanvien"].ToString();
                NhanVien.Diachi = dt.Rows[i]["Diachi"].ToString();
                NhanVien.Dienthoai = dt.Rows[i]["Dienthoai"].ToString();
                NhanVien.Tendangnhap = dt.Rows[i]["Tendangnhap"].ToString();
                NhanVien.Matkhau = dt.Rows[i]["Matkhau"].ToString();    
                if (int.Parse(dt.Rows[i]["Quyen"].ToString()) == 1)
                    NhanVien.Quyen = "Quản lý";
                else
                    NhanVien.Quyen = "Nhân viên";

                lstNhanVien.Add(NhanVien);
            }
            return lstNhanVien;
        }
        public static bool ThemNhanVien(string tennhanvien,string diachi,string dienthoai,string tendangnhap,string matkhau,int quyen)
        {
            string query = string.Format("insert into nhanvien values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',{5})", tennhanvien,diachi,dienthoai,tendangnhap,matkhau,quyen);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }
        public static bool SuaNhanVien(string tennhanvien, string diachi, string dienthoai, string tendangnhap, string matkhau, int quyen,int id)
        {
            string query = string.Format("update nhanvien set tennhanvien = N'{0}', diachi = N'{1}', dienthoai = N'{2}', tendangnhap = N'{3}', matkhau = N'{4}', quyen = {5} where id = {6}", tennhanvien, diachi, dienthoai, tendangnhap, matkhau, quyen,id);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }
        public static bool XoaNhanVien(int id)
        {
            string query = string.Format("delete from nhanvien where id = {0}", id);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }
        public static int LayIDNV( string tenkhu)
        {
            string TruyVan = string.Format("select n.id from khu k, ga g, nhanvien n, khothucan o where k.id_ga = g.id and k.id_nhanvien = n.id and k.id_khothucan = o.id and  tenkhu = N'{0}'", tenkhu);
            connection = Dataprovider.MoKetNoi();
            DataTable dt = Dataprovider.TruyVanLayDuLieu(TruyVan, connection);
            if (dt.Rows.Count == 0)
            {
                return -1;
            }
            return int.Parse(dt.Rows[0]["id"].ToString());
        }
    }
}
