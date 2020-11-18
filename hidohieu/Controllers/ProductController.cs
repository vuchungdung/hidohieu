using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hidohieu.Models;
using hidohieu.Models.Process;
using PagedList;
using PagedList.Mvc;

namespace hidohieu.Controllers
{
    public class ProductController : Controller
    {
        PCDbContext db = new PCDbContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Product/TopDateProduct : hiển thị ra 6 cuốn sách mới cập nhật theo ngày cập nhật
        //Parital View : TopDateProduct
        public ActionResult TopDateProduct()
        {
            var result = new ProductProcess().NewDateProduct(6);
            return PartialView(result);
        }

        //GET : /Product/Details/:id : hiển thị chi tiết thông tin sách
        public ActionResult Details(int id)
        {
            var result = new AdminProcess().GetIdProduct(id);

            return View(result);
        }

        //GET : /Product/Favorite : hiển thị ra 3 cuốn sách bán chạy theo ngày cập nhật (silde trên cùng)
        //Parital View : FavoriteProduct
        public ActionResult FavoriteProduct()
        {
            var result = new ProductProcess().NewDateProduct(3);

            return PartialView(result);
        }

        //GET : /Product/DidYouSee : hiển thị ra 3 cuốn sách giảm dần theo ngày
        //Parital View : DidYouSee
        public ActionResult DidYouSee()
        {
            var result = new ProductProcess().TakeProduct(3);

            return PartialView(result);
        }

        //GET : /Product/All : hiển thị tất cả sách trong db
        public ActionResult ShowAllProduct(int? page)
        {
            //tạo biến số sản phẩm trên trang
            int pageSize = 10;

            //tạo biến số trang
            int pageNumber = (page ?? 1);

            var result = new ProductProcess().ShowAllProduct().ToPagedList(pageNumber, pageSize);

            return View(result);
        }

    }
}