using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiGa_DTO
    {
        private int id;
        private string tenloaiga;

        public int Id { get => id; set => id = value; }
        public string Tenloaiga { get => tenloaiga; set => tenloaiga = value; }
    }
}
