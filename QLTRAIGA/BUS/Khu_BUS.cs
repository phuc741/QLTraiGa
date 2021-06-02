using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Khu_BUS
    {
        public static List<Khu_DTO> LayKhu()
        {
            return Khu_DAO.LayKhu();
        }
        public static bool ThemKhu(string tenkhu, int id_ga, int id_nhanvien, int id_khothucan)
        {
            return Khu_DAO.ThemKhu(tenkhu, id_ga, id_nhanvien, id_khothucan);
        }
        public static bool SuaKhu(int id, string tenkhu, int id_ga, int id_nhanvien, int id_khothucan)
        {
            return Khu_DAO.SuaKhu(id, tenkhu, id_ga, id_nhanvien, id_khothucan);
        }
        public static bool XoaKhu(int id)
        {
            return Khu_DAO.XoaKhu(id);
        }
    }
}
