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
    public class KhoThucAn_DAO
    {
        static SqlConnection connection;
        public static List<KhoThucAn_DTO> LayKhoThucAn()
        {
            string TruyVan = string.Format("select *from khothucan");
            connection = Dataprovider.MoKetNoi();
            DataTable dt = Dataprovider.TruyVanLayDuLieu(TruyVan, connection);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<KhoThucAn_DTO> lstKhoThucAn = new List<KhoThucAn_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhoThucAn_DTO Kho = new KhoThucAn_DTO();
                Kho.Id = int.Parse(dt.Rows[i]["id"].ToString());
                Kho.Tenthucan = dt.Rows[i]["Tenthucan"].ToString();
                Kho.Soluongcon = dt.Rows[i]["Soluongcon"].ToString();
                lstKhoThucAn.Add(Kho);
            }
            return lstKhoThucAn;
        }
        public static bool ThemKhoThucAn(string tenthucan,int soluongcon)
        {
            string query = string.Format("insert into khothucan values(N'{0}',N'{1}')", tenthucan, soluongcon);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }
        public static bool SuaKhoThucAn(string tenthucan, int soluongcon)
        {
            string query = string.Format("update khothucan set tenthucan = N'{0}', soluongcon = N'{1}",tenthucan,soluongcon);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }
        public static bool XoaKhoThucAn(int id)
        {
            string query = string.Format("delete from khothucan where id = {0}", id);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }
        public static int LayIDKho(string tenkhu)
        {
            string TruyVan = string.Format("select o.id from khu k, ga g, nhanvien n, khothucan o where k.id_ga = g.id and k.id_nhanvien = n.id and k.id_khothucan = o.id and  tenkhu = N'{0}'", tenkhu);
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
