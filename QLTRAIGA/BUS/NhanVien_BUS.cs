using DTO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVien_BUS
    {
        public static List<NhanVien_DTO> LayNhanVien()
        {
            return NhanVien_DAO.LayNhanVien();
        }
        public static bool ThemNhanVien(string tennhanvien, string diachi, string dienthoai, string tendangnhap, string matkhau, int quyen)
        {
            return NhanVien_DAO.ThemNhanVien(tennhanvien, diachi, dienthoai, tendangnhap, matkhau, quyen);
        }
        public static bool SuaNhanVien(string tennhanvien, string diachi, string dienthoai, string tendangnhap, string matkhau, int quyen, int id)
        {
            return NhanVien_DAO.SuaNhanVien(tennhanvien, diachi, dienthoai, tendangnhap, matkhau, quyen, id);
        }
        public static bool XoaNhanVien(int id)
        {
            return NhanVien_DAO.XoaNhanVien(id);
        }
        public static int LayIDNV(string tenkhu)
        {
            return NhanVien_DAO.LayIDNV(tenkhu);    
        } 
     }
}
