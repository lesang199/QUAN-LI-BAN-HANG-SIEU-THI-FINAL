using QuanLyBanHangSieuThi.Entity;
using QuanLyBanHangSieuThi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.DAL
{
    public class CustomerDAL
    {
        // Đường dẫn tới file JSON
        private string _dataFile = Path.Combine(Global.DATA_PATH, nameof(Customer) + ".json");

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };

        // Phương thức nạp danh sách Customer từ file JSON
        public List<Customer> Load()
        {
            if (File.Exists(_dataFile))
            {
                try
                {
                    // Đọc file JSON và nạp dữ liệu
                    string jsonString = File.ReadAllText(_dataFile);
                    return JsonSerializer.Deserialize<List<Customer>>(jsonString, options);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Có lỗi xảy ra khi nạp dữ liệu: {ex.Message}");
                }
            }

            return new List<Customer>(); // Trả về danh sách trống nếu không có file
        }

        // Phương thức lưu danh sách Customer vào file JSON
        public void Save(List<Customer> Customers)
        {
            try
            {
                // Đảm bảo thư mục tồn tại
                if (!Directory.Exists(Global.DATA_PATH))
                {
                    Directory.CreateDirectory(Global.DATA_PATH);
                }

                // Tuần tự hóa danh sách thành JSON
                var jsonString = JsonSerializer.Serialize(Customers, options);

                // Ghi chuỗi JSON vào file
                File.WriteAllText(_dataFile, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Có lỗi xảy ra khi lưu dữ liệu: {ex.Message}");
            }
        }
    }
}
