using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models.VỉewModel
{
    public class Customer
    {
        //Key
        public int IDCus { get; set; }   
        public string NameCus { get; set; }
        public string PhoneCus { get; set; }
        public string EmailCus { get; set; }
        public string PassCus { get; set; }
        public string ConfirmPassCus { get; set; }
        public Nullable<System.DateTime> DateOfBirthCus { get; set; }
        public string AddressCus { get; set; }
        public string CityCus { get; set; }

        //Lấy thông tin từ bản OrderPro
        public int ID { get; set; }
        public Nullable<System.DateTime> DateOrder { get; set; }
        public string AddressDeliverry { get; set; }

    }
}