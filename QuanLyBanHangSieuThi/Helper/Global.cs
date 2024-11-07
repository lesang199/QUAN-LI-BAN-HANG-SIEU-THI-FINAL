using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Helper
{
    public static class Global
    {
        // Thuộc tính lấy đường dẫn của thư mục đang chạy chương trình
        public static string DATA_PATH { get { 
                return Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "DATA");
            }
        }
    }
}
