using hidohieu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hidohieu.Models.Process
{
    public class ProductProcess
    {
        //Khởi tạo biến dữ liệu : db
        PCDbContext db = null;

        //constructor :  khởi tạo đối tượng
        public ProductProcess()
        {
            db = new PCDbContext();
        }

        /// <summary>
        /// lấy cuốn mới nhất theo ngày cập nhật
        /// </summary>
        /// <param name="count">int</param>
        /// <returns>List</returns>
        public List<SanPham> NewDateProduct(int count)
        {
            return db.SanPhams.OrderByDescending(x => x.NgayCapNhat).Take(count).ToList();
        }

        /// <summary>
        /// lọc sách theo chủ đề
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>List</returns>
        public List<SanPham> ThemeProduct(int id)
        {
            return db.SanPhams.Where(x => x.MaLoai == id).ToList();
        }

        /// <summary>
        /// Lấy sách chọn lọc
        /// </summary>
        /// <param name="count">int</param>
        /// <returns>List</returns>
        public List<SanPham> TakeProduct(int count)
        {
            return db.SanPhams.OrderBy(x => x.NgayCapNhat).Take(count).ToList();
        }

        /// <summary>
        /// Xem tất cả cuốn sách
        /// </summary>
        /// <returns>List</returns>
        public List<SanPham> ShowAllProduct()
        {
            return db.SanPhams.OrderBy(x => x.MaSanPham).ToList();
        }

    }
}