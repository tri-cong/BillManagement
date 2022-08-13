using System.Data;
using BillLibrary.BillObject;
using Microsoft.Data.SqlClient;

namespace BillLibrary.Data
{
    public class DBContext : BaseDAL
    {
        private static DBContext instance = null;
        private static readonly object instanceLock = new object();
        private DBContext() { }
        public static DBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new DBContext();
                    }
                    return instance;
                }
            }
        }
        //--
        public IEnumerable<KhachHang> GetKhachHangList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "SELECT * FROM KhachHang";
            var KH = new List<KhachHang>();
            try
            {
                dataReader = billData.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    KH.Add(new KhachHang
                    {
                        MaKh = dataReader.GetInt32(0),
                        HoTenKh = dataReader.GetString(1),
                        DiaChiKh = dataReader.GetString(2),
                        QuocTich = dataReader.GetString(3),
                        DoiTuongKh = dataReader.GetString(4),
                        SoLuongTieuThu = dataReader.GetInt32(5),
                        DonGia = dataReader.GetDecimal(6),
                        DinhMucTieuThu = dataReader.GetInt32(7)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return KH;
        }
        //--
        public KhachHang GetKhachHangByID(int MaKh)
        {
            KhachHang khachhang = null;
            IDataReader dataReader = null;
            string SQLSelect = "SELECT * FROM KhachHang WHERE MaKh = @MaKh";
            try
            {
                var param = billData.CreateParameter("@MaKh", 4, MaKh, DbType.Int32);
                dataReader = billData.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    khachhang = new KhachHang
                    {
                        MaKh = dataReader.GetInt32(0),
                        HoTenKh = dataReader.GetString(1),
                        DiaChiKh = dataReader.GetString(2),
                        QuocTich = dataReader.GetString(3),
                        DoiTuongKh = dataReader.GetString(4),
                        SoLuongTieuThu = dataReader.GetInt32(5),
                        DonGia = dataReader.GetDecimal(6),
                        DinhMucTieuThu = dataReader.GetInt32(7)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return khachhang;
        }
        //--
        public void AddNew(KhachHang khachHang)
        {
            try
            {
                KhachHang pro = GetKhachHangByID(khachHang.MaKh);
                if (pro == null)
                {
                    string SQLInsert = "INSERT KhachHang VALUES(@MaKh,@HoTenKh,@DiaChiKh,@QuocTich,@DoiTuongKh,@SoLuongTieuThu,@DonGia,@DinhMucTieuThu)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(billData.CreateParameter("@MaKh", 4, khachHang.MaKh, DbType.Int32));
                    parameters.Add(billData.CreateParameter("@HoTenKh", 50, khachHang.HoTenKh, DbType.String));
                    parameters.Add(billData.CreateParameter("@DiaChiKh", 50, khachHang.DiaChiKh, DbType.String));
                    parameters.Add(billData.CreateParameter("@QuocTich", 50, khachHang.QuocTich, DbType.String));
                    parameters.Add(billData.CreateParameter("@DoiTuongKh", 50, khachHang.DoiTuongKh, DbType.String));
                    parameters.Add(billData.CreateParameter("@SoLuongTieuThu", 4, khachHang.SoLuongTieuThu, DbType.Int32));
                    parameters.Add(billData.CreateParameter("@DonGia", 50, khachHang.DonGia, DbType.Decimal));
                    parameters.Add(billData.CreateParameter("@DinhMucTieuThu", 4, khachHang.DinhMucTieuThu, DbType.Int32));
                    billData.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("Khách hàng đã tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        //--
        public void Update(KhachHang khachHang)
        {
            try
            {
                KhachHang c = GetKhachHangByID(khachHang.MaKh);
                if (c != null)
                {
                    string SQLUpdate = "UPDATE KhachHang SET HoTenKh = @HoTenKh,DiaChiKh = @DiaChiKh,QuocTich = @QuocTich,DoiTuongKh = @DoiTuongKh,SoLuongTieuThu = @SoLuongTieuThu,DonGia = @DonGia,DinhMucTieuThu = @DinhMucTieuThu WHERE MaKh = @MaKh";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(billData.CreateParameter("@MaKh", 4, khachHang.MaKh, DbType.Int32));
                    parameters.Add(billData.CreateParameter("@HoTenKh", 50, khachHang.HoTenKh, DbType.String));
                    parameters.Add(billData.CreateParameter("@DiaChiKh", 50, khachHang.DiaChiKh, DbType.String));
                    parameters.Add(billData.CreateParameter("@QuocTich", 50, khachHang.QuocTich, DbType.String));
                    parameters.Add(billData.CreateParameter("@DoiTuongKh", 50, khachHang.DoiTuongKh, DbType.String));
                    parameters.Add(billData.CreateParameter("@SoLuongTieuThu", 4, khachHang.SoLuongTieuThu, DbType.Int32));
                    parameters.Add(billData.CreateParameter("@DonGia", 50, khachHang.DonGia, DbType.Decimal));
                    parameters.Add(billData.CreateParameter("@DinhMucTieuThu", 4, khachHang.DinhMucTieuThu, DbType.Int32));
                    billData.Update(SQLUpdate, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("Error.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        //--
        public void Remove(int MaKh)
        {
            try
            {
                KhachHang khachHang = GetKhachHangByID(MaKh);
                if (khachHang != null)
                {
                    string SQLDelete = "DELETE KhachHang WHERE MaKh = @MaKh";
                    var param = billData.CreateParameter("@MaKh", 4, MaKh, DbType.Int32);
                    billData.Delete(SQLDelete, CommandType.Text, param);
                }
                else
                {
                    throw new Exception("Error.");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
