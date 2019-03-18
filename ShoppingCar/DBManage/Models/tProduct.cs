using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace DBManage.Models
{
    public class tProduct
    {
        public int fId { get; set; }

        [DisplayName("產品編號V")]
        public string fPId { get; set; }

        [DisplayName("品名V")]
        public string fName { get; set; }

        [DisplayName("單價V")]
        public Nullable<int> fPrice { get; set; }

        [DisplayName("圖示V")]
        public string fImg { get; set; }
    }
}