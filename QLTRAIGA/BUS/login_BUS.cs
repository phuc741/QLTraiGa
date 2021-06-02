using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class login_BUS
    {
        public static List<login_DTO> LayLogin()
        {
            return login_DAO.LayLogin();
        }
        public static bool Login(string tendangnhap, string password)
        {
            return login_DAO.Login(tendangnhap, password);
        }
        public static bool Quyen(string tendangnhap, string password) // phanquyen
        {
            return login_DAO.Quyen(tendangnhap, password);
        }
        public static int LayQuyenTruyCapTaiKhoan(string tendangnhap)
        {
            return login_DAO.LayQuyenTruyCapTaiKhoan(tendangnhap);
        }
        public static string LayTenTaiKhoan(string username)
        {
            return login_DAO.LayTenTaiKhoan(username);
        }
    }
}