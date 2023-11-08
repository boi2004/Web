using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models.VỉewModel
{
    public class Category
    {
        //Key
        public int Id { get; set; }
        public string IDCate { get; set; } 
        public string NameCate { get; set; }

        //Lấy thông tin từ bảng Ring
        public int RingID { get; set; }
        public string Brand { get; set; }
        public string Material { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Collection { get; set; }
        public Nullable<int> GoldCarat { get; set; }
        public string GemType { get; set; }
        public string Gender { get; set; }
        public string MaterialColor { get; set; }
        public string ImagePro { get; set; }

    }
}