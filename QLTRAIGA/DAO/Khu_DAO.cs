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
    public class Khu_DAO
    {
        static SqlConnection connection;
        public static List<Khu_DTO> LayKhu()
        {
            string TruyVan = string.Format("select k.id, k.tenkhu,tenga,trongmai,tennhanvien from khu k, ga g, nhanvien n, khothucan o where k.id_ga = g.id and k.id_nhanvien = n.id and k.id_khothucan = o.id");
            connection = Dataprovider.MoKetNoi();
            DataTable dt = Dataprovider.TruyVanLayDuLieu(TruyVan, connection);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Khu_DTO> lstkhu = new List<Khu_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Khu_DTO khu = new Khu_DTO();
                khu.Id = int.Parse(dt.Rows[i]["id"].ToString());
                khu.Tenkhu = dt.Rows[i]["Tenkhu"].ToString();
                khu.Tenga = dt.Rows[i]["Tenga"].ToString();
                khu.Tenga = dt.Rows[i]["Tenga"].ToString();
                khu.Trongmai = dt.Rows[i]["Trongmai"].ToString();
                khu.Tennhanvien = dt.Rows[i]["Tennhanvien"].ToString();

                lstkhu.Add(khu);
            }
            return lstkhu;
        }
        public static bool ThemKhu(string tenkhu,int id_ga,int id_nhanvien,int id_khothucan)
        {
            string query = string.Format("insert into khu values (N'{0}',{1},{2},{3})", tenkhu, id_ga, id_nhanvien, id_khothucan);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }
        public static bool SuaKhu(int id,string tenkhu, int id_ga, int id_nhanvien, int id_khothucan)
        {
            string query = string.Format("update khu set tenkhu = N'{1}', id_ga = {2}, id_nhanvien = {3}, id_khothucan = {4} where id = {0}",id, tenkhu, id_ga, id_nhanvien, id_khothucan);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }
        public static bool XoaKhu(int id)
        {
            string query = string.Format("delete from loaiga where id = {0}", id);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }

    }
}
