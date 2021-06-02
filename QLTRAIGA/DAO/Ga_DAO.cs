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
    public class Ga_DAO
    {
        static SqlConnection connection;
        public static List<Ga_DTO> LayGa()
        {
            string TruyVan = string.Format("select g.id,g.tenga,g.trongmai,g.giongga,g.soluong ,l.tenloaiga from ga g, LoaiGa l where g.id_loaiga = l.id");
            connection = Dataprovider.MoKetNoi();
            DataTable dt = Dataprovider.TruyVanLayDuLieu(TruyVan, connection);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Ga_DTO> lstga = new List<Ga_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Ga_DTO ga = new Ga_DTO();
                ga.Id = int.Parse(dt.Rows[i]["id"].ToString());            
                ga.Tenloaiga = dt.Rows[i]["Tenloaiga"].ToString();
                ga.Tenga = dt.Rows[i]["Tenga"].ToString();
                ga.Trongmai = dt.Rows[i]["Trongmai"].ToString();
                ga.Giongga = dt.Rows[i]["Giongga"].ToString();
                ga.Soluong = int.Parse(dt.Rows[i]["Soluong"].ToString());
                lstga.Add(ga);
            }
            return lstga;
        }
        public static bool ThemGa(string tenga, string trongmai,string giongga,int id_loaiga)
        {
            string query = string.Format("insert into ga values(N'{0}',N'{1}',N'{2}',{3})", tenga,trongmai,giongga,id_loaiga);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }
        public static bool SuaGa(string tenga, string trongmai, string giongga, int id_loaiga,int id)
        {
            string query = string.Format("update ga set tenga = N'{0}', trongmai = N'{1}', giongga = N'{2}', id_loaiga = {3} where id = {4}", tenga, trongmai, giongga, id_loaiga,id);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }
        public static bool XoaGa(int id)
        {
            string query = string.Format("delete from ga where id = {0}", id);
            connection = Dataprovider.MoKetNoi();
            bool a = Dataprovider.TruyVanKhongLayDuLieu(query, connection);
            return a;
        }
        public static int LayIDGa(string tenga,string tenkhu)
        {
            string TruyVan = string.Format("select g.id from khu k, ga g, nhanvien n, khothucan o where k.id_ga = g.id and k.id_nhanvien = n.id and k.id_khothucan = o.id and tenga = N'{0}' and tenkhu = N'{1}'", tenga,tenkhu);
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
