using BillLibrary.BillObject;
using BillLibrary.Repository;

namespace BillWinApp
{
    public partial class frmKhachKhangManagement : Form
    {
        IKHRepository kHRepository = new KHRepository();
        BindingSource source;
        public frmKhachKhangManagement()
        {
            InitializeComponent();
        }

        private void frmKhachKhangManagement_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            dgvKhachHangList.CellDoubleClick += DgvKhachHangList_CellDoubleClick;
        }
        private void DgvKhachHangList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmKhachHangDetails frmKhachHangDetails = new frmKhachHangDetails
            {
                Text = "Update Khach Hang",
                InsertOrUpdate = true,
                KhachHangInfo = GetKhachHangObject(),
                KHRepository = kHRepository
            };
            if(frmKhachHangDetails.ShowDialog() == DialogResult.OK)
            {
                LoadKhachHangList();
                source.Position = source.Count - 1;
            }
        }
        //--
        private void ClearText()
        {
            txtMaKh.Text = string.Empty;
            txtHoTenKh.Text = string.Empty;
            txtDiaChiKh.Text = string.Empty;
            txtQuocTich.Text = string.Empty;
            txtDoiTuongKh.Text = string.Empty;
            txtSoLuongTieuThu.Text = string.Empty;
            txtDonGia.Text = string.Empty;
            txtDinhMucTieuThu.Text = string.Empty;
        }
        //--
        private KhachHang GetKhachHangObject()
        {
            KhachHang khachHang = null;
            try
            {
                khachHang = new KhachHang
                {
                    MaKh = int.Parse(txtMaKh.Text),
                    HoTenKh = txtHoTenKh.Text,
                    DiaChiKh = txtDiaChiKh.Text,
                    QuocTich = txtQuocTich.Text,
                    DoiTuongKh = txtDoiTuongKh.Text,
                    SoLuongTieuThu = int.Parse(txtSoLuongTieuThu.Text),
                    DonGia = decimal.Parse(txtDonGia.Text),
                    DinhMucTieuThu = int.Parse(txtDinhMucTieuThu.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Get Khach Hang");
            }
            return khachHang;
        }
        //--
        public void LoadKhachHangList()
        {
            var khachHangs = kHRepository.GetKhachHang();
            try
            {
                source = new BindingSource();
                source.DataSource = khachHangs;

                txtMaKh.DataBindings.Clear();
                txtHoTenKh.DataBindings.Clear();
                txtDiaChiKh.DataBindings.Clear();
                txtQuocTich.DataBindings.Clear();
                txtDoiTuongKh.DataBindings.Clear();
                txtSoLuongTieuThu.DataBindings.Clear();
                txtDonGia.DataBindings.Clear();
                txtDinhMucTieuThu.DataBindings.Clear();

                txtMaKh.DataBindings.Add("Text", source, "MaKh");
                txtHoTenKh.DataBindings.Add("Text", source, "HoTenKh");
                txtDiaChiKh.DataBindings.Add("Text", source, "DiaChiKh");
                txtQuocTich.DataBindings.Add("Text", source, "QuocTich");
                txtDoiTuongKh.DataBindings.Add("Text", source, "DoiTuongKh");
                txtSoLuongTieuThu.DataBindings.Add("Text", source, "SoLuongTieuThu");
                txtDonGia.DataBindings.Add("Text", source, "DonGia");
                txtDinhMucTieuThu.DataBindings.Add("Text", source, "DinhMucTieuThu");

                dgvKhachHangList.DataSource = null;
                dgvKhachHangList.DataSource = source;
                if(khachHangs.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Load khach hang list");
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadKhachHangList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmKhachHangDetails frmKhachHangDetails = new frmKhachHangDetails
            {
                Text = "Add khach hang",
                InsertOrUpdate = false,
                KHRepository = kHRepository
            };
            if(frmKhachHangDetails.ShowDialog() == DialogResult.OK)
            {
                LoadKhachHangList();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var khachHang = GetKhachHangObject();
                kHRepository.DeleteKH(khachHang.MaKh);
                LoadKhachHangList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete khach hang");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
