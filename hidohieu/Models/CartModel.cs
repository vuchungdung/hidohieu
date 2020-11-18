using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hidohieu.Models;

namespace hidohieu.Models
{
    [Serializable]
    public class CartModel
    {
        public SanPham sach { get; set; }
        public int Quantity { get; set; }
        public decimal? Total
        {
            get { return Quantity * sach.GiaBan; }
        }
    }
}