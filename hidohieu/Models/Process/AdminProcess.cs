using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hidohieu.Models;

namespace hidohieu.Models.Process
{
    public class AdminProcess
    {
        //Tầng xử lý dữ liệu

        PCDbContext db = null;

        //constructor
        public AdminProcess()
        {
            db = new PCDbContext();
        }

        /// <summary>
        /// Hàm đăng nhập
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="password">string</param>
        /// <returns>int</returns>
        public int Login(string username, string password)
        {
            var result = db.Admins.SingleOrDefault(x => x.TaiKhoan == username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.MatKhau == password)
                {
                    
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        //Get ID : lấy mã

        #region lấy mã

        /// <summary>
        /// hàm lấy mã admin
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Admin</returns>
        public Admin GetIdAdmin(int id)
        {
            return db.Admins.Find(id);
        }

        /// <summary>
        /// hàm lấy mã sách
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>SanPham</returns>
        public SanPham GetIdProduct(int id)
        {
            return db.SanPhams.Find(id);
        }

        /// <summary>
        /// hàm lấy mã thể loại
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>LoaiSanPham</returns>
        public LoaiSanPham GetIdCategory(int id)
        {
            return db.LoaiSanPhams.Find(id);
        }

        /// <summary>
        /// hàm lấy mã tác giả
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>NhaSanXuat</returns>
        public NhaSanXuat GetIdAuthor(int id)
        {
            return db.NhaSanXuats.Find(id);
        }

        /// <summary>
        /// hàm lấy mã nhà xuất bản
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>NhaCungCap</returns>
        public NhaCungCap GetIdPublish(int id)
        {
            return db.NhaCungCaps.Find(id);
        }

        /// <summary>
        /// Hàm lấy mã khách hàng tham quan
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>KhachHang</returns>
        public KhachHang GetIdCustomer(int id)
        {
            return db.KhachHangs.Find(id);
        }

        /// <summary>
        /// hàm lấy mã đơn đặt hàng
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>DonDatHang</returns>
        public DonDatHang GetIdOrder(int id)
        {
            return db.DonDatHangs.Find(id);
        }

        /// <summary>
        /// hàm lấy mã liên hệ
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>LienHe</returns>
        public LienHe GetIdContact(int id)
        {
            return db.LienHes.Find(id);
        }

        #endregion

        //Category : loại sản phẩm

        #region thể loại

        /// <summary>
        /// hàm xuất danh sách thể loại
        /// </summary>
        /// <returns>List</returns>
        public List<LoaiSanPham> ListAllCategory()
        {
            return db.LoaiSanPhams.OrderBy(x => x.MaLoai).ToList();
        }

        /// <summary>
        /// hàm thêm thểm loại
        /// </summary>
        /// <param name="entity">LoaiSanPham</param>
        /// <returns>int</returns>
        public int InsertCategory(LoaiSanPham entity)
        {
            db.LoaiSanPhams.Add(entity);
            db.SaveChanges();
            return entity.MaLoai;
        }

        /// <summary>
        /// hàm cập nhật thể loại
        /// </summary>
        /// <param name="entity">LoaiSanPham</param>
        /// <returns>int</returns>
        public int UpdateCategory(LoaiSanPham entity)
        {
            try
            {
                var tl = db.LoaiSanPhams.Find(entity.MaLoai);
                tl.TenLoai = entity.TenLoai;
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// hàm xóa thể loại
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        public bool DeleteCategory(int id)
        {
            try
            {
                var tl = db.LoaiSanPhams.Find(id);
                db.LoaiSanPhams.Remove(tl);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        //Author : nhà sản xuất

        #region tác giả

        /// <summary>
        /// hàm xuất danh sách tác giả
        /// </summary>
        /// <returns>List</returns>
        public List<NhaSanXuat> ListAllAuthor()
        {
            return db.NhaSanXuats.OrderBy(x => x.MaNSX).ToList();
        }

        /// <summary>
        /// hàm thêm tác giả
        /// </summary>
        /// <param name="entity">NhaSanXuat</param>
        /// <returns></returns>
        public int InsertAuthor(NhaSanXuat entity)
        {
            db.NhaSanXuats.Add(entity);
            db.SaveChanges();
            return entity.MaNSX;
        }

        /// <summary>
        /// hàm cập nhật tác giả
        /// </summary>
        /// <param name="entity">NhaSanXuat</param>
        /// <returns>int</returns>
        public int UpdateAuthor(NhaSanXuat entity)
        {
            try
            {
                var tg = db.NhaSanXuats.Find(entity.MaNSX);
                tg.TenNSX = entity.TenNSX;
                tg.DiaChi = entity.DiaChi;
                tg.SoDienThoai = entity.SoDienThoai;
                tg.Email = entity.Email;
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// hàm xóa tác giả
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>int</returns>
        public bool DeleteAuthor(int id)
        {
            try
            {
                var tg = db.NhaSanXuats.Find(id);
                db.NhaSanXuats.Remove(tg);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion


        //Publish : nhà cung cấp

        #region nhà xuất bản

        /// <summary>
        /// hàm xuất danh sách nhà xuất bản
        /// </summary>
        /// <returns>List</returns>
        public List<NhaCungCap> ListAllPublish()
        {
            return db.NhaCungCaps.OrderBy(x => x.MaNCC).ToList();
        }

        /// <summary>
        /// hàm thêm nhà xuất bản
        /// </summary>
        /// <param name="entity">NhaCungCap</param>
        /// <returns>int</returns>
        public int InsertPublish(NhaCungCap entity)
        {
            db.NhaCungCaps.Add(entity);
            db.SaveChanges();
            return entity.MaNCC;
        }

        /// <summary>
        /// hàm cập nhật nhà xuất bản
        /// </summary>
        /// <param name="entity">NhaCungCap</param>
        /// <returns>int</returns>
        public int UpdatePublish(NhaCungCap entity)
        {
            try
            {
                var nxb = db.NhaCungCaps.Find(entity.MaNCC);
                nxb.TenNCC = entity.TenNCC;
                nxb.DiaChi = entity.DiaChi;
                nxb.DienThoai = entity.DienThoai;
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// hàm xóa nhà xuất bản
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        public bool DeletePublish(int id)
        {
            try
            {
                var nxb = db.NhaCungCaps.Find(id);
                db.NhaCungCaps.Remove(nxb);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion


        //Products : sản phẩm

        #region sản phẩm

        /// <summary>
        /// hàm xuất danh sách Sách
        /// </summary>
        /// <returns>List</returns>
        public List<SanPham> ListAllProduct()
        {
            return db.SanPhams.OrderBy(x => x.MaSanPham).ToList();
        }

        /// <summary>
        /// hàm thêm sách
        /// </summary>
        /// <param name="entity">SanPham</param>
        /// <returns>int</returns>
        public int InsertProduct(SanPham entity)
        {
            db.SanPhams.Add(entity);
            db.SaveChanges();
            return entity.MaSanPham;
        }

        /// <summary>
        /// hàm cập nhật sách
        /// </summary>
        /// <param name="entity">Sách</param>
        /// <returns>int</returns>
        public int UpdateProduct(SanPham entity)
        {
            try
            {
                var SanPham = db.SanPhams.Find(entity.MaSanPham);
                SanPham.MaLoai = entity.MaLoai;
                SanPham.MaNCC = entity.MaNCC;
                SanPham.MaNSX = entity.MaNSX;
                SanPham.TenSanPham = entity.TenSanPham;
                SanPham.GiaBan = entity.GiaBan;
                SanPham.Mota = entity.Mota;
                SanPham.AnhSanPham = entity.AnhSanPham;
                SanPham.NgayCapNhat = entity.NgayCapNhat;
                SanPham.SoLuongTon = entity.SoLuongTon;
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// hàm xóa 1 cuốn sách
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        public bool DeleteProduct(int id)
        {
            try
            {
                var SanPham = db.SanPhams.Find(id);
                db.SanPhams.Remove(SanPham);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        //Liên hệ từ khách hàng

        #region phản hồi khách hàng

        /// <summary>
        /// hàm lấy danh sách những phản hồi từ khách hàng
        /// </summary>
        /// <returns>List</returns>
        public List<LienHe> ShowListContact()
        {
            return db.LienHes.OrderBy(x => x.MaLH).ToList();
        }

        /// <summary>
        /// hàm xóa thông tin phản hồi khách hàng
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        public bool deleteContact(int id)
        {
            try
            {
                var contact = db.LienHes.Find(id);
                db.LienHes.Remove(contact);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        //Quản lý người dùng

        /// <summary>
        /// hàm xuất danh sách người dùng
        /// </summary>
        /// <returns>List</returns>
        public List<KhachHang> ListUser()
        {
            return db.KhachHangs.OrderBy(x => x.MaKH).ToList();
        }

        /// <summary>
        /// hàm xóa người dùng
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        public bool DeleteUser(int id)
        {
            try
            {
                var user = db.KhachHangs.Find(id);
                db.KhachHangs.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}