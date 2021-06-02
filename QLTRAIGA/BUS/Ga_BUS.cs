using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Ga_BUS
    {
        public static List<Ga_DTO> LayGa()
        {
            return Ga_DAO.LayGa();
        }
        public static bool ThemGa(string tenga, string trongmai, string giongga, int id_loaiga)
        {
            return Ga_DAO.ThemGa(tenga, trongmai, giongga, id_loaiga);
        }
        public static bool SuaGa(string tenga, string trongmai, string giongga, int id_loaiga, int id)
        {
            return Ga_DAO.SuaGa(tenga, trongmai, giongga, id_loaiga, id);
        }
        public static bool XoaGa(int id)
        {
            return Ga_DAO.XoaGa(id);
        }
        public static int LayIDGa(string tenga, string tenkhu)
        {
            return Ga_DAO.LayIDGa(tenga, tenkhu);
        }
    }
}
