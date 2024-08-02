using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BookShopOnline.Areas.Admin.Data
{
    public class ChuDeVM
    {
        [DisplayName("Mã chủ đề")]
        public int MaCD { get; set; }
        [DisplayName("Tên chủ đề")]
        public string TenCD{ get; set; }
    }
}