using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using GUI.Labs;

namespace GUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Lear_TabPages();
            
        }


        void Lear_TabPages()
        {
            TabControlTable.TabPages.Remove(tpGioiThieu);
            TabControlTable.TabPages.Remove(tpGa);
            TabControlTable.TabPages.Remove(tpNhanVien);
            TabControlTable.TabPages.Remove(tpKhoThucAn);
            TabControlTable.TabPages.Remove(tpKhu);
            TabControlTable.TabPages.Remove(tpLoaiGa);
           
        }
        void load_DataGa()
        {
            List<Ga_DTO> Ga = Ga_BUS.LayGa();
            dgvGa.DataSource = Ga;

            lbl_id_Ga.DataBindings.Clear();
            lbl_id_Ga.DataBindings.Add("Text", dgvGa.DataSource, "Id");
            txtTenLoaiGa_Ga.DataBindings.Clear();
            txtTenLoaiGa_Ga.DataBindings.Add("Text", dgvGa.DataSource, "Tenloaiga");
            txtTenGa_Ga.DataBindings.Clear();
            txtTenGa_Ga.DataBindings.Add("Text", dgvGa.DataSource, "Tenga");
            txtTrongMai_Ga.DataBindings.Clear();
            txtTrongMai_Ga.DataBindings.Add("Text", dgvGa.DataSource, "Trongmai");
            txtGiongGa_Ga.DataBindings.Clear();
            txtGiongGa_Ga.DataBindings.Add("Text", dgvGa.DataSource, "Giongga");

        }

        void load_DataKho()
        {
            List<KhoThucAn_DTO> Kho = KhoThucAn_BUS.LayKhoThucAn();
            dgvKho.DataSource = Kho;
            lbl_ID_Kho.DataBindings.Clear();
            lbl_ID_Kho.DataBindings.Add("Text", dgvKho.DataSource, "Id");
            txtTenThucAn_Kho.DataBindings.Clear();
            txtTenThucAn_Kho.DataBindings.Add("Text", dgvKho.DataSource, "Tenthucan");
            txtSoLuongCon_Kho.DataBindings.Clear();
            txtSoLuongCon_Kho.DataBindings.Add("Text", dgvKho.DataSource, "Soluongcon");
        }
        void load_DataKhu()
        {
            List<Khu_DTO> Khu = Khu_BUS.LayKhu();
            dgvKhu.DataSource = Khu;

            List<Ga_DTO> lstga = Ga_BUS.LayGa();
            cbtenga_Khu.DataSource = lstga;
            cbtenga_Khu.DisplayMember = "Tenga";
            cbtenga_Khu.ValueMember = "id";

            List<NhanVien_DTO> lstnhanvien = NhanVien_BUS.LayNhanVien();
            cbNhanVien_Khu.DataSource = lstnhanvien;
            cbNhanVien_Khu.DisplayMember = "Tennhanvien";
            cbNhanVien_Khu.ValueMember = "id";


            List<KhoThucAn_DTO> lstkho = KhoThucAn_BUS.LayKhoThucAn();
            cbKhoThucAn_Khu.DataSource = lstkho;
            cbKhoThucAn_Khu.DisplayMember = "Tenthucan";
            cbKhoThucAn_Khu.ValueMember = "id";

            lblID_Khu.DataBindings.Clear();
            lblID_Khu.DataBindings.Add("Text", dgvKhu.DataSource, "Id");
            txtTenKhu_Khu.DataBindings.Clear();
            txtTenKhu_Khu.DataBindings.Add("Text", dgvKhu.DataSource, "Tenkhu");
           
            txtTrongMai_Khu.DataBindings.Clear();
            txtTrongMai_Khu.DataBindings.Add("Text", dgvKhu.DataSource, "Trongmai");
                
        }
        void load_DataLoaiGa()
        {
            List<LoaiGa_DTO> LoaiGa = LoaiGa_BUS.LayLoaiGa();
            dgvLoaiGa.DataSource = LoaiGa;
            lblID_Loai.DataBindings.Clear();
            lblID_Loai.DataBindings.Add("Text", dgvLoaiGa.DataSource, "Id");
            txtTenLoai_Loai.DataBindings.Clear();
            txtTenLoai_Loai.DataBindings.Add("Text", dgvLoaiGa.DataSource, "Tenloaiga");
        }
        void load_DataNhanVien()
        {
            List<NhanVien_DTO> NhanVien = NhanVien_BUS.LayNhanVien();
            dgvNhanVien.DataSource = NhanVien;
            lblID_NV.DataBindings.Clear();
            lblID_NV.DataBindings.Add("Text", dgvNhanVien.DataSource, "Id");
            txtTenNV_NV.DataBindings.Clear();
            txtTenNV_NV.DataBindings.Add("Text", dgvNhanVien.DataSource, "Tennhanvien");
            txtDiaChi_NV.DataBindings.Clear();
            txtDiaChi_NV.DataBindings.Add("Text", dgvNhanVien.DataSource, "Diachi");
            txtDienThoai_NV.DataBindings.Clear();
            txtDienThoai_NV.DataBindings.Add("Text", dgvNhanVien.DataSource, "Dienthoai");            
            txtTenDangNhap_NV.DataBindings.Clear();
            txtTenDangNhap_NV.DataBindings.Add("Text", dgvNhanVien.DataSource, "Tendangnhap");
            txtMK_NV.DataBindings.Clear();
            txtMK_NV.DataBindings.Add("Text", dgvNhanVien.DataSource, "Matkhau");
            txtQuyen_NV.DataBindings.Clear();
            txtQuyen_NV.DataBindings.Add("Text", dgvNhanVien.DataSource, "Quyen");

        }
       

        private void btnThem_Loai_Click(object sender, EventArgs e)
        {
          if(txtTenLoai_Loai.Text=="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ!");
                return;
            }    
            if(LoaiGa_BUS.ThemLoaiGa(txtTenLoai_Loai.Text))
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
            load_DataLoaiGa();
        }

        private void btnSua_Loai_Click(object sender, EventArgs e)
        {
            if (LoaiGa_BUS.SuaLoaiGa(txtTenLoai_Loai.Text,int.Parse(lblID_Loai.Text)))
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
            load_DataLoaiGa();
        }

        private void btnXoa_Loai_Click(object sender, EventArgs e)
        {
            if (LoaiGa_BUS.XoaLoaiGa( int.Parse(lblID_Loai.Text)))
            {
                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
            load_DataLoaiGa();
        }

        private void btnThem_Khu_Click(object sender, EventArgs e)
        {
            
            if (Khu_BUS.ThemKhu(txtTenKhu_Khu.Text,int.Parse(cbtenga_Khu.SelectedValue.ToString()),int.Parse(cbNhanVien_Khu.SelectedValue.ToString()),int.Parse(cbKhoThucAn_Khu.SelectedValue.ToString())))
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
            load_DataKhu();
        }
        private void btnSua_Khu_Click(object sender, EventArgs e)
        {
            if (Khu_BUS.SuaKhu(int.Parse(lblID_Khu.Text), txtTenKhu_Khu.Text, int.Parse(cbtenga_Khu.SelectedValue.ToString()), int.Parse(cbNhanVien_Khu.SelectedValue.ToString()), int.Parse(cbKhoThucAn_Khu.SelectedValue.ToString())))
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
            load_DataKhu();
        }
        private void btnXoa_Khu_Click(object sender, EventArgs e)
        {
            if (Khu_BUS.XoaKhu(int.Parse(lblID_Khu.Text)))
            {
                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
            load_DataKhu();
        }

        private void btnThem_Kho_Click(object sender, EventArgs e)
        {
            if (txtTenThucAn_Kho.Text == "" || txtSoLuongCon_Kho.Text=="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ!");
                return;
            }
            if (KhoThucAn_BUS.ThemKhoThucAn(txtTenThucAn_Kho.Text,int.Parse(txtSoLuongCon_Kho.Text )))
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
            load_DataKho();
        }

        private void btnSua_Kho_Click(object sender, EventArgs e)
        {
            if (KhoThucAn_BUS.SuaKhoThucAn(txtTenThucAn_Kho.Text, int.Parse(txtSoLuongCon_Kho.Text)))
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
            load_DataKho();
        }

        private void btnXoa_Kho_Click(object sender, EventArgs e)
        {
            if (KhoThucAn_BUS.XoaKhoThucAn(int.Parse(lbl_ID_Kho.Text)))
            {
                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
            load_DataKho();
        }   

        private void btnThem_NV_Click_1(object sender, EventArgs e)
        {
            if (txtTenNV_NV.Text == "" || txtDiaChi_NV.Text == "" || txtDienThoai_NV.Text == "" || txtTenDangNhap_NV.Text == "" || txtMK_NV.Text == "" || txtQuyen_NV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ!");
                return;
            }
            if (NhanVien_BUS.ThemNhanVien(txtTenNV_NV.Text, txtDiaChi_NV.Text, txtDienThoai_NV.Text, txtTenDangNhap_NV.Text,SHA1.ComputeHash(txtMK_NV.Text),int.Parse(txtQuyen_NV.Text)))
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
            load_DataNhanVien();
        }

        private void btnSua_NV_Click(object sender, EventArgs e)
        {
            if (NhanVien_BUS.SuaNhanVien(txtTenNV_NV.Text, txtDiaChi_NV.Text, txtDienThoai_NV.Text, txtTenDangNhap_NV.Text,SHA1.ComputeHash(txtMK_NV.Text),int.Parse(txtQuyen_NV.Text),int.Parse(lblID_NV.Text)))
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
            load_DataNhanVien();
        }

        private void btnXoa_NV_Click(object sender, EventArgs e)
        {
            if (NhanVien_BUS.XoaNhanVien(int.Parse(lblID_NV.Text)))
            {
                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
            load_DataNhanVien();
        }

        private void btnThem_Ga_Click(object sender, EventArgs e)
        {
            if (Ga_BUS.ThemGa(txtTenGa_Ga.Text,txtTrongMai_Ga.Text,txtGiongGa_Ga.Text,LoaiGa_BUS.LayIDtuTenLoaiGa(txtTenLoaiGa_Ga.Text)))
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
            load_DataGa();
        }

        private void btnSua_Ga_Click(object sender, EventArgs e)
        {
            if (Ga_BUS.SuaGa(txtTenGa_Ga.Text, txtTrongMai_Ga.Text, txtGiongGa_Ga.Text, LoaiGa_BUS.LayIDtuTenLoaiGa(txtTenLoaiGa_Ga.Text),int.Parse(lbl_id_Ga.Text)))
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
            load_DataGa();
        }

        private void btnXoa_Ga_Click(object sender, EventArgs e)
        {
            if (Ga_BUS.XoaGa(int.Parse(lbl_id_Ga.Text)))
            {
                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
            load_DataGa();
        }
        public bool bDangNhap;
        Formlogin login;
        private void HienThiMenu()
        {
            i_DangNhap.Enabled = !bDangNhap;
            i_DangXuat.Enabled = bDangNhap;
            i_Thoat.Enabled = bDangNhap;
        }
        private void i_DangNhap_Click(object sender, EventArgs e)
        {
            login = new Formlogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                if (login_BUS.Login(login.txtUserName.Text,SHA1.ComputeHash(login.txtPassWord.Text)) == true)
                {
                    bDangNhap = true;

                    i_NguoiDung.Enabled = true;
                    MessageBox.Show("Đăng nhập thành công");
                    if (login_BUS.Quyen(login.txtUserName.Text,SHA1.ComputeHash(login.txtPassWord.Text)))
                    {
                        i_NguoiDung.Text = login_BUS.LayTenTaiKhoan(login.txtUserName.Text);
                        i_DuLieu.Visible = true;
                        iNhanVien.Visible = true;
                        iGa.Visible = true;
                        iKhoThucAn.Visible = true;
                        iKhu.Visible = true;
                        iLoaiGa.Visible = true;
                        i_NguoiDung.Visible = true;
                    }
                    else
                    {
                        i_DuLieu.Visible = false;
                        i_NguoiDung.Text = login_BUS.LayTenTaiKhoan(login.txtUserName.Text);
                        iNhanVien.Visible = false;
                        iGa.Visible = true;
                        iKhoThucAn.Visible = true;
                        iKhu.Visible = true;
                        iLoaiGa.Visible = true;
                        i_NguoiDung.Visible = true;

                    }
                }
                else
                {
                    bDangNhap = false;
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                    i_DangNhap_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                login.ShowDialog();
            }
          
            HienThiMenu();
        }

        private void iGioiThieu_Click(object sender, EventArgs e)
        {
            Lear_TabPages();
            if (!TabControlTable.Controls.Contains(tpGioiThieu))
                TabControlTable.Controls.Add(tpGioiThieu);
        }

        private void iGa_Click(object sender, EventArgs e)
        {
            Lear_TabPages();
            if (!TabControlTable.Controls.Contains(tpGa))
                TabControlTable.Controls.Add(tpGa);
            load_DataGa();
        }

        private void iKhoThucAn_Click(object sender, EventArgs e)
        {
            Lear_TabPages();
            if (!TabControlTable.Controls.Contains(tpKhoThucAn))
                TabControlTable.Controls.Add(tpKhoThucAn);
            load_DataKho();
        }

        private void iKhu_Click(object sender, EventArgs e)
        {
            Lear_TabPages();
            if (!TabControlTable.Controls.Contains(tpKhu))
                TabControlTable.Controls.Add(tpKhu);
            load_DataKhu();
        }

        private void iLoaiGa_Click(object sender, EventArgs e)
        {
            Lear_TabPages();
            if (!TabControlTable.Controls.Contains(tpLoaiGa))
                TabControlTable.Controls.Add(tpLoaiGa);
            load_DataLoaiGa();
        }

        private void iNhanVien_Click(object sender, EventArgs e)
        {
            Lear_TabPages();
            if (!TabControlTable.Controls.Contains(tpNhanVien))
                TabControlTable.Controls.Add(tpNhanVien);
            load_DataNhanVien();
        }

        private void i_DangXuat_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (!f.IsDisposed)
                    f.Close();
            }
            i_NguoiDung.Text = "Chưa đăng nhập";
            bDangNhap = false;
            HienThiMenu();
            i_DuLieu.Visible = false;
            iNhanVien.Visible = false;
            iGa.Visible = false;
            iKhoThucAn.Visible = false;
            iKhu.Visible = false;
            iLoaiGa.Visible = false;    
        }

        private void i_SaoLuu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saoluuFolder = new FolderBrowserDialog();
            saoluuFolder.Description = "Chọn thư mục lưu trữ";
            if (saoluuFolder.ShowDialog() == DialogResult.OK)
            {
                string sDuongDan = saoluuFolder.SelectedPath;
                if (CSDL_BUS.SaoLuu(sDuongDan) == true)
                    MessageBox.Show("Đã sao lưu dữ liệu vào " + sDuongDan);
                else
                    MessageBox.Show("Thao tác không thành công");
            }
        }

        private void i_PhucHoi_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog phuchoiFolder = new FolderBrowserDialog();
            phuchoiFolder.Description = "Chọn thư mục phục hồi";
            if (phuchoiFolder.ShowDialog() == DialogResult.OK)
            {
                string sDuongDan = phuchoiFolder.SelectedPath;
                if (CSDL_BUS.PhucHoi(sDuongDan) == true)
                    MessageBox.Show("Đã phục hồi dữ liệu vào " + sDuongDan);
                else
                    MessageBox.Show("Thao tác không thành công");
            }
        }

        private void btnInDanhSach_Ga_Click(object sender, EventArgs e)
        {

        }
    }
}




