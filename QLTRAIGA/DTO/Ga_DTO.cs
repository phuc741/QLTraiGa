using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Ga_DTO
    {
        private int id;      
        private string tenloaiga;
        private string tenga;
        private string trongmai;
        private string giongga;
        private int soluong;
        public int Id { get => id; set => id = value; }
        public string Tenloaiga { get => tenloaiga; set => tenloaiga = value; }
        public string Tenga { get => tenga; set => tenga = value; }
        public string Trongmai { get => trongmai; set => trongmai = value; }
        public string Giongga { get => giongga; set => giongga = value; }
        public int Soluong { get => soluong; set => soluong = value; }
    }
}
