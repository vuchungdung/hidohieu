using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hidohieu.Models;

namespace hidohieu.Models.Process
{
    public class HomeProcess
    {
        //Khởi tạo biến dữ liệu : db
        PCDbContext db = null;

        //constructor :  khởi tạo đối tượng
        public HomeProcess()
        {
            db = new PCDbContext();
        }

        /// <summary>
        /// hàm xuất danh sách thể loại
        /// </summary>
        /// <returns></returns>
        public List<LoaiSanPham> ListCategory()
        {
            return db.LoaiSanPhams.OrderBy(x => x.MaLoai).ToList();
        }

        /// <summary>
        /// hàm lưu phản hồi từ khách hàng vào db
        /// </summary>
        /// <param name="entity">LienHe</param>
        /// <returns>int</returns>
        public int InsertContact(LienHe entity)
        {
            db.LienHes.Add(entity);
            db.SaveChanges();

            return entity.MaLH;
        }

        /// <summary>
        /// hàm tìm kiếm tên sách
        /// </summary>
        /// <param name="key">string</param>
        /// <returns>List</returns>
        public List<SanPham> Search(string key)
        {
            return db.SanPhams.Where(x => x.TenSanPham.Contains(key)).OrderBy(x=>x.TenSanPham).ToList();
        }

    }
}