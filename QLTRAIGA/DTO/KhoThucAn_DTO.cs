using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhoThucAn_DTO
    {
        private int id;
        private string tenthucan;
        private string soluongcon;

        public int Id { get => id; set => id = value; }
        public string Tenthucan { get => tenthucan; set => tenthucan = value; }
        public string Soluongcon { get => soluongcon; set => soluongcon = value; }
    }
}
