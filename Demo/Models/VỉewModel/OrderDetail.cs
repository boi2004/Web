using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models.VỉewModel
{
    public class OrderDetail
    {
        //Khóa 
        public int ID { get; set; } 
        public Nullable<int> IDProduct { get; set; }
        public Nullable<int> IDOrder { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> UnitPrice { get; set; }

        //Lấy thông tin từ bảng Ring
      
        public string Brand { get; set; }
        public string Material { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Collection { get; set; }
        public Nullable<int> GoldCarat { get; set; }
        public string GemType { get; set; }
        public string Gender { get; set; }
        public string MaterialColor { get; set; }
        public string ImagePro { get; set; }

        //Lấy thông tin từ bảng OrderPro
        public Nullable<System.DateTime> DateOrder { get; set; }
        public Nullable<int> IDCus { get; set; }
        public string AddressDeliverry { get; set; }
    }
}