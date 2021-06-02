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
    public class LoaiGa_DAO
    {
        static SqlConnection connection;
        public static List<LoaiGa_DTO> LayloaiGa()
        {
            string TruyVan = string.Format("select *from LoaiGa");
            connection = Dataprovider.MoKetNoi();
            DataTable dt = Dataprovider.TruyVanLayDuLieu(TruyVan, connection);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<LoaiGa_DTO> lstLoaiGa = new List<LoaiGa_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoaiGa_DTO LoaiGa = new LoaiGa_DTO();
                LoaiGa.Id = int.Parse(dt.Rows[i]["id"].ToString());
                LoaiGa.Tenloaiga = dt.Rows[i]["Tenloaiga"].ToString();
                lstLoaiGa.Add(LoaiGa);
            }
            return lstLoaiGa;
        }
        public static bool ThemLoaiGa(string tenloaiga)
        {
            string query = string.Format("insert into loaiga values(N'{0}')", tenloaiga);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }
        public static bool SuaLoaiGa(string tenloaiga, int id)
        {
            string query = string.Format("update loaiga set tenloaiga = N'{0}' where id = {1}", tenloaiga, id);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }
        public static bool XoaLoaiGa(int id)
        {
            string query = string.Format("delete from loaiga where id = {0}", id);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }
        public static int LayIDtuTenLoaiGa(string tenloaiga)
        {
            string TruyVan = string.Format("select id from LoaiGa where tenloaiga=N'{0}'", tenloaiga);
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
