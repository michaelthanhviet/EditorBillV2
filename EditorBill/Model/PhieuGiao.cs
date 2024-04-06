using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorBill.Model
{
    public class PhieuGiao
    {
        public string SoPhieu { get; set; }
        public List<IXLRow> HangBan { get; set; }
        public IXLRow Tong { get; set; }
        public double TienKM { get; set; }
        public double TongTienThanhToan { get; set; }
        public string TienBangChu { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public PhieuGiao()
        {
            HangBan = new List<IXLRow>();
        }

        /// <summary>
        /// update lại toàn bộ thông tin Phiếu giao
        /// </summary>
        public void Refresh()
        {
            double TongThanhTien = 0;
            double TongThanhToan = 0;
            double TongKM = 0;

            foreach (var row in HangBan)
            {
                double Thung = double.Parse(row.Cell("G").Value.ToString());
                double Le = double.Parse(row.Cell("H").Value.ToString());
                double GiaThung = double.Parse(row.Cell("I").Value.ToString());
                double GiaLe = double.Parse(row.Cell("J").Value.ToString());
                double KM = 0;
                if (!string.IsNullOrEmpty(row.Cell("L").Value.ToString().Trim()))
                    KM = double.Parse(row.Cell("L").Value.ToString().Replace("%", ""));

                double ThanhTien = Thung * GiaThung + Le * GiaLe;
                double TienKM = (ThanhTien * KM) / 100;
                double ThanhToan = ThanhTien - TienKM;

                // set cột tổng
                row.Cell("K").SetValue(ThanhTien);
                row.Cell("M").SetValue(TienKM);
                row.Cell("N").SetValue(ThanhToan);

                TongThanhTien += ThanhTien;
                TongKM += TienKM;
                TongThanhToan += ThanhToan;
            }
            // set dòng tổng cộng
            Tong.Cell("K").SetValue(TongThanhTien);
            Tong.Cell("M").SetValue(TongKM);
            Tong.Cell("N").SetValue(TongThanhToan);

            TongTienThanhToan = TongThanhToan - TienKM;

            TienBangChu = NumberToText(String.Format("{0:#,##}", TongTienThanhToan));
        }

        /// <summary>
        /// Kiểm tra mã hàng có tồn tại trong phiếu giao
        /// </summary>
        /// <param name="mahang">mã hàng</param>
        /// <returns>true : có; false : không</returns>
        public bool CheckMaHang(string mahang)
        {
            foreach (var row in HangBan)
            {
                if (mahang.Equals(row.Cell("B").Value.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// Cập nhật lại giá thùng và giá lẻ sau khi chỉnh sửa trên danh sách theo mã hàng
        /// </summary>
        /// <param name="mahang">mã hàng</param>
        /// <param name="giathung">giá thùng</param>
        /// <param name="giale">giá lẻ</param>
        public void CapNhatGia(string mahang, string giathung, string giale)
        {
            foreach (var row in HangBan)
            {
                if (mahang.Equals(row.Cell("B").Value.ToString()))
                {
                    row.Cell("I").SetValue(double.Parse(giathung));
                    row.Cell("J").SetValue(double.Parse(giale));
                }
            }
        }

        /// <summary>
        /// Lưu giá trị vào sheet
        /// </summary>
        /// <param name="worksheet"></param>
        public void CapNhatToWorkSheet(IXLWorksheet worksheet)
        {
            // Lưu danh sách đơn hàng
            foreach (var item in HangBan)
            {
                worksheet.Cell(item.RowNumber(), "I").SetValue(item.Cell("I").Value).Style.NumberFormat.Format = "#,##0";
                worksheet.Cell(item.RowNumber(), "J").SetValue(item.Cell("J").Value).Style.NumberFormat.Format = "#,##0";
                worksheet.Cell(item.RowNumber(), "K").SetValue(item.Cell("K").Value).Style.NumberFormat.Format = "#,##0";
                worksheet.Cell(item.RowNumber(), "M").SetValue(item.Cell("M").Value).Style.NumberFormat.Format = "#,##0";
                worksheet.Cell(item.RowNumber(), "N").SetValue(item.Cell("N").Value).Style.NumberFormat.Format = "#,##0";
            }
            // Lưu dòng tổng cộng hàng hóa
            worksheet.Cell(Tong.RowNumber(), "K").SetValue(Tong.Cell("K").Value).Style.NumberFormat.Format = "#,##0";
            worksheet.Cell(Tong.RowNumber(), "N").SetValue(Tong.Cell("N").Value).Style.NumberFormat.Format = "#,##0";
            // Lưu dòng tổng tiền
            worksheet.Cell(Tong.RowNumber() + 2, "C").SetValue(TienBangChu);
            worksheet.Cell(Tong.RowNumber() + 2, "N").SetValue(TongTienThanhToan).Style.NumberFormat.Format = "#,##0";
        }
        
        /// 
        /// Chuyển phần nguyên của số thành chữ
        /// 
        /// Số double cần chuyển thành chữ
        /// Chuỗi kết quả chuyển từ số
        private string NumberToText(string inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.Replace(",", "");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }

            int ones, tens, hundreds;
            int positionDigit = sNumber.Length;   // last -> first
            string result = " ";

            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;
                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            string str1 = result.Substring(0, 1);
            string str2 = result.Substring(1);
            str1 = str1.ToUpper();
            return str1 + str2 + (suffix ? " đồng" : "");
        }
        
    }
}
