    using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Dataprovider
    {
        public static SqlConnection MoKetNoi()
        {
            string s = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLTRAIGA;Integrated Security=True";
            SqlConnection KetNoi = new SqlConnection(s);
            KetNoi.Open();
            return KetNoi;
        }
        public static DataTable TruyVanLayDuLieu(string TruyVan, SqlConnection ketnoi)
        {
            SqlDataAdapter da = new SqlDataAdapter(TruyVan, ketnoi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static bool TruyVanKhongLayDuLieu(string truyvan, SqlConnection ketnoi)
        {
            try
            {
                SqlCommand cm = new SqlCommand(truyvan, ketnoi);
                cm.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
