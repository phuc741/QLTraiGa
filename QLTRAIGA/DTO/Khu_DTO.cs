using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Khu_DTO
    {
        private int id;
        private string tenkhu;
        private string tenga;
        private string trongmai;
        private string tennhanvien;

        public int Id { get => id; set => id = value; }
        public string Tenkhu { get => tenkhu; set => tenkhu = value; }
        public string Tenga { get => tenga; set => tenga = value; }
        public string Trongmai { get => trongmai; set => trongmai = value; }
        public string Tennhanvien { get => tennhanvien; set => tennhanvien = value; }
    }
}
