using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiGa_BUS
    {
        public static List<LoaiGa_DTO> LayLoaiGa()
        {
            return LoaiGa_DAO.LayloaiGa();
        }
        public static bool ThemLoaiGa(string tenloaiga)
        {
            return LoaiGa_DAO.ThemLoaiGa(tenloaiga);
        }
        public static bool SuaLoaiGa(string tenloaiga, int id)
        {
            return LoaiGa_DAO.SuaLoaiGa(tenloaiga, id);
        }
        public static bool XoaLoaiGa(int id)
        {
            return LoaiGa_DAO.XoaLoaiGa(id);
        }
        public static int LayIDtuTenLoaiGa(string tenloaiga)
        {
            return LoaiGa_DAO.LayIDtuTenLoaiGa(tenloaiga);
        }
    }
}
