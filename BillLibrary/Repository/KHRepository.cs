using BillLibrary.BillObject;
using BillLibrary.Data;

namespace BillLibrary.Repository
{
    public class KHRepository : IKHRepository
    {
        public KhachHang GetKhachHangByID(int MaKh) => DBContext.Instance.GetKhachHangByID(MaKh);
        public IEnumerable<KhachHang> GetKhachHang() => DBContext.Instance.GetKhachHangList();
        public void InsertKH(KhachHang khachhang) => DBContext.Instance.AddNew(khachhang);
        public void DeleteKH(int MaKh) => DBContext.Instance.Remove(MaKh);
        public void UpdateKH(KhachHang khachhang) => DBContext.Instance.Update(khachhang);
    }
}
