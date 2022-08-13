using BillLibrary.BillObject;
using BillLibrary.Repository;

namespace BillWinApp
{
    public partial class frmKhachHangDetails : Form
    {
        public frmKhachHangDetails()
        {
            InitializeComponent();
        }
        //--
        public IKHRepository KHRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public KhachHang KhachHangInfo { get; set; }
        private void frmKhachHangDetails_Load(object sender, EventArgs e)
        {
            cboDoiTuongKh.SelectedIndex = 0;
            txtMaKh.Enabled = !InsertOrUpdate;
            if(InsertOrUpdate == true)
            {
                txtMaKh.Text = KhachHangInfo.MaKh.ToString();
                txtHoTenKh.Text = KhachHangInfo.HoTenKh;
                txtDiaChiKh.Text = KhachHangInfo.DiaChiKh;
                txtQuocTich.Text = KhachHangInfo.QuocTich;
                cboDoiTuongKh.Text = KhachHangInfo.DoiTuongKh.Trim();
                txtSoLuongTieuThu.Text = KhachHangInfo.SoLuongTieuThu.ToString();
                txtDonGia.Text = KhachHangInfo.DonGia.ToString();
                txtDinhMucTieuThu.Text = KhachHangInfo.DinhMucTieuThu.ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var khachhang = new KhachHang
                {
                    MaKh = int.Parse(txtMaKh.Text),
                    HoTenKh = txtHoTenKh.Text,
                    DiaChiKh = txtDiaChiKh.Text,
                    QuocTich = txtQuocTich.Text,
                    DoiTuongKh = cboDoiTuongKh.Text,
                    SoLuongTieuThu = int.Parse(txtSoLuongTieuThu.Text),
                    DonGia = decimal.Parse(txtDonGia.Text),
                    DinhMucTieuThu = int.Parse(txtDinhMucTieuThu.Text)
                };
                if(InsertOrUpdate == false)
                {
                    KHRepository.InsertKH(khachhang);
                }
                else
                {
                    KHRepository.UpdateKH(khachhang);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,InsertOrUpdate==false?"Add a new khach hang": "Update khach hang");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void txtSoLuongTieuThu_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
