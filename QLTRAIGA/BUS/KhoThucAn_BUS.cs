using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhoThucAn_BUS
    {
        public static List<KhoThucAn_DTO> LayKhoThucAn()
        {
            return KhoThucAn_DAO.LayKhoThucAn();
        }
        public static bool ThemKhoThucAn(string tenthucan, int soluongcon)
        {
            return KhoThucAn_DAO.ThemKhoThucAn(tenthucan, soluongcon);
        }
        public static bool SuaKhoThucAn(string tenthucan, int soluongcon)
        {
            return KhoThucAn_DAO.SuaKhoThucAn(tenthucan, soluongcon);
        }
        public static bool XoaKhoThucAn(int id)
        {
            return KhoThucAn_DAO.XoaKhoThucAn(id);
        }
        public static int LayIDKho(string tenkhu)
        {
            return KhoThucAn_DAO.LayIDKho(tenkhu);
        }
    }
}
