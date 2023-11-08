using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models.VỉewModel
{
    public class OrderPro
    {
        public int ID { get; set; } //Khóa chính
        public Nullable<System.DateTime> DateOrder { get; set; }
        public Nullable<int> IDCus { get; set; }
        public string AddressDeliverry { get; set; }
        //Thông tin từ bản Customer
        public string NameCus { get; set; }
        public string PhoneCus { get; set; }
        public string EmailCus { get; set; }
        public string PassCus { get; set; }
        public string ConfirmPassCus { get; set; }
        public Nullable<System.DateTime> DateOfBirthCus { get; set; }
        public string AddressCus { get; set; }
        public string CityCus { get; set; }
        //Thông tin từ bản OrderDetail
        public Nullable<int> IDProduct { get; set; }
        public Nullable<int> IDOrder { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> UnitPrice { get; set; }
    }
}