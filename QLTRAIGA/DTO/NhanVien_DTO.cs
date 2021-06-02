using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien_DTO
    {
        private int id;
        private string tennhanvien;
        private string diachi;
        private string dienthoai;
        private string tendangnhap;
        private string matkhau;
        private string quyen;

        public int Id { get => id; set => id = value; }
        public string Tennhanvien { get => tennhanvien; set => tennhanvien = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Dienthoai { get => dienthoai; set => dienthoai = value; }
        public string Tendangnhap { get => tendangnhap; set => tendangnhap = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public string Quyen { get => quyen; set => quyen = value; }
    }
}
