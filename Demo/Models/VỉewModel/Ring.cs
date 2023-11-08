using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models.VỉewModel
{
    public class Ring
    {
        //Key
        public int RingID { get; set; }
        public string Brand { get; set; }
        public string Material { get; set; }
        public string JewelryType { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Collection { get; set; }
        public Nullable<int> GoldCarat { get; set; }
        public string GemType { get; set; }
        public string Gender { get; set; }
        public string MaterialColor { get; set; }
        public string ImagePro { get; set; }
        //Lấy thông tin từ bảng Category
        public int Id { get; set; }
        public string NameCate { get; set; }
        //Lấy thông tin từ bản OrderDetail
        public int ID { get; set; } 
        public Nullable<int> IDOrder { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> UnitPrice { get; set; }
    }
}