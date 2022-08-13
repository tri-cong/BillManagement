using System.Collections;
using BillLibrary.BillObject;

namespace BillLibrary.Repository
{
    public interface IKHRepository
    {
        IEnumerable<KhachHang> GetKhachHang();
        KhachHang GetKhachHangByID(int MaKh);
        void InsertKH(KhachHang khachhang);
        void DeleteKH(int MaKh);
        void UpdateKH(KhachHang khachhang);
    }
}
