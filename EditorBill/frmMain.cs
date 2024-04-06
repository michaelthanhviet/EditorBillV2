using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Runtime.InteropServices;
using System.Diagnostics;
using ClosedXML.Excel;
using Microsoft.Office.Interop.Excel;
using EditorBill.Model;

namespace EditorBill
{
    public partial class frmMain : Telerik.WinControls.UI.RadForm
    {
        private List<PhieuGiao> DanhSachPhieuGiao = new List<PhieuGiao>();

        XLWorkbook workbook = new XLWorkbook();

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Chọn file input và load dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            // mở dialog chọn file
            OpenFileDialog file = new OpenFileDialog();
            // Nếu có chọn file
            if (file.ShowDialog() == DialogResult.OK) //if there is a file chosen by the user
            {
                // Lấy tên file
                string fileName = file.FileName;
                // Lấy loại file
                string fileExt = Path.GetExtension(fileName);
                // Kiểm tra xem có phải file excel
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    // chuyển đổi từ xls sang xlsx
                    if (fileExt.CompareTo(".xls") == 0)
                    {
                        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook workbookTest = excelApp.Workbooks.Open(fileName, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                        fileName = fileName + "x";
                        // save as XLSX
                        workbookTest.SaveAs(fileName, XlFileFormat.xlOpenXMLWorkbook);
                        // close the workbook and the Excel application
                        workbookTest.Close();
                        excelApp.Quit();
                        GetExcelProcess(excelApp).Kill();
                    }
                    try
                    {
                        // Hiển thị file lên màn hình
                        lblFileName.Text = fileName;

                        // Read file
                        workbook = new XLWorkbook(fileName);
                        // Lấy sheet đầu tiên
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        // Tìm danh sách hàng bán
                        IXLCells searchCells = worksheet.Search("1. Hàng bán");
                        // Nếu tìm có data
                        if (searchCells != null)
                        {
                            // Tạo danh sách mã hàng
                            List<string> MaHangCheck = new List<string>();
                            // Duyệt danh sách search
                            foreach (var cell in searchCells)
                            {
                                // Lấy tất cả các dòng
                                IXLRow searchRow = cell.WorksheetRow();
                                // Lấy index dòng
                                int rowIdx = searchRow.RowNumber();
                                // Tạo Phiếu Giao
                                PhieuGiao phieugiao = new PhieuGiao();
                                // setting số phiếu
                                phieugiao.SoPhieu = worksheet.Cell(rowIdx - 4, "N").Value.ToString();
                                // Di chuyển tới danh sách hàng
                                IXLRow nextRow = searchRow.RowBelow().RowBelow();
                                // Lặp danh sách hàng
                                while (!nextRow.IsEmpty())
                                {
                                    // Kiểm tra mã hàng khác rỗng
                                    if (!nextRow.Cell("B").Value.IsBlank)
                                    {
                                        // Thêm hàng bán vào phiếu giao
                                        phieugiao.HangBan.Add(nextRow);
                                        // Lấy mã hàng
                                        string MaHang = nextRow.Cell("B").Value.ToString();
                                        // Kiểm tra mã hàng đã được thêm vào danh sách
                                        if (!MaHangCheck.Contains(MaHang))
                                        {
                                            // Thêm vào danh sách hàng để check
                                            MaHangCheck.Add(MaHang);
                                            // Thêm vào danh sách hiển thị
                                            GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(rgvProduct.MasterView);
                                            rowInfo.Cells["ID"].Value = MaHang;
                                            rowInfo.Cells["Description"].Value = nextRow.Cell("C").Value.ToString();
                                            rowInfo.Cells["Price1"].Value = FormatCurrency(nextRow.Cell("I").Value.ToString());
                                            rowInfo.Cells["Price2"].Value = FormatCurrency(nextRow.Cell("J").Value.ToString());
                                            rgvProduct.Rows.Add(rowInfo);
                                        }
                                    } 
                                    else
                                    {
                                        // Lấy dòng tổng cộng
                                        phieugiao.Tong = nextRow;
                                        // Lấy dòng tiền khuyến mãi
                                        if (!worksheet.Cell(nextRow.RowNumber() + 1, "N").Value.IsBlank)
                                        {
                                            phieugiao.TienKM = double.Parse(worksheet.Cell(nextRow.RowNumber() + 1, "N").Value.ToString().Replace(",", ""));
                                        }
                                        // Lấy tổng thanh toán
                                        phieugiao.TongTienThanhToan = double.Parse(worksheet.Cell(nextRow.RowNumber() + 2, "N").Value.ToString().Replace(",", ""));
                                        // Lấy tiền bằng chữ
                                        phieugiao.TienBangChu = worksheet.Cell(nextRow.RowNumber() + 2, "C").Value.ToString();
                                        break;
                                    }
                                    // Move to the row below
                                    nextRow = nextRow.RowBelow();
                                }
                                // Thêm vào danh sách phiếu giao
                                DanhSachPhieuGiao.Add(phieugiao);
                            }
                            // Duyệt Phiếu giao để thêm vào danh sách hiển thị phiếu giao
                            foreach (var item in DanhSachPhieuGiao)
                            {
                                GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(rgvSoPhieu.MasterView);
                                rowInfo.Cells["SoPhieu"].Value = item.SoPhieu;
                                rgvSoPhieu.Rows.Add(rowInfo);
                            }
                        }
                        // Active chức năng
                        btnClear.Enabled = true;
                        btnUpdateAll.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        lblFileName.Text = "";
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Hãy chọn loại file là .xls hoặc .xlsx !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Lấy processID
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpdwProcessId"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);

        /// <summary>
        /// Lấy process của Application Excel
        /// </summary>
        /// <param name="excelApp"></param>
        /// <returns></returns>
        Process GetExcelProcess(Microsoft.Office.Interop.Excel.Application excelApp)
        {
            int id;
            GetWindowThreadProcessId(excelApp.Hwnd, out id);
            return Process.GetProcessById(id);
        }

        /// <summary>
        /// Định dạng tiền từ chuỗi
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string FormatCurrency(string value)
        {
            try
            {
                return String.Format("{0:#,##}", Double.Parse(value)); ;
            }
            catch
            {
                return "";
            }
            
        }

        /// <summary>
        /// Định dạng tiền từ số
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string FormatCurrency(double value)
        {
            try
            {
                return String.Format("{0:#,##}", value);
            }
            catch
            {
                return "";
            }

        }

        /// <summary>
        /// override void OnLoad
        /// Gán các event cho cell on ragridview
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            // edit row event
            rgvProduct.CellValidating += new CellValidatingEventHandler(GridProduct_CellValidating);
            rgvProduct.CellValueChanged += new GridViewCellEventHandler(GridProduct_CellValueChanged);
            rgvProduct.SelectionChanged += new EventHandler(GridProduct_SelectionChanged);
            // base gridview
            base.OnLoad(e);
        }

        /// <summary>
        /// Validate khi chỉnh sửa giá tiền
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridProduct_CellValidating(object sender, CellValidatingEventArgs e)
        {
            if (e.Column == null || e.Column.Name == "ID")
                return;
            try
            {
                string value = e.Value.ToString();
            }
            catch
            {
                MessageBox.Show("Không được trống (Có thể nhập \"0\" nếu không có) !", "Thông báo", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }
            string ColName = e.Column.Name;

            if ("Price1".Equals(ColName) || "Price2".Equals(ColName))
            {
                try
                {
                    double.Parse(e.Value.ToString().Replace(",", ""));
                }
                catch
                {
                    MessageBox.Show("Nhập không đúng kiểu dữ liệu. Hãy nhập số tự nhiên!", "Thông báo", MessageBoxButtons.OK);
                    e.Cancel = true;
                    return;
                }
            }
        }

        /// <summary>
        /// format lại định dạng tiền sau khi chỉnh sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridProduct_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            rgvProduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:#,##}", double.Parse(e.Value.ToString().Replace(",", "")));

        }
        /// <summary>
        /// Event chọn dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridProduct_SelectionChanged(object sender, EventArgs e) 
        {
            // khởi tạo data
            List<string> data = new List<string>();
            // Lấy dòng đã chọn
            var SelectedRows = rgvProduct.SelectedRows;
            // duyệt danh sách dòng
            foreach(var row in SelectedRows)
            {
                // Lấy mã hàng
                string Mahang = row.Cells["ID"].Value.ToString();
                // Tìm và thêm vào data
                data.AddRange(TimSoPhieuTheoMaHang(Mahang));
            }

            // Xóa danh sách phiếu hiện tại
            rgvSoPhieu.Rows.Clear();
            // duyệt kết quả tìm được
            foreach (var item in data)
            {
                // Tạo mới dòng
                GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(rgvSoPhieu.MasterView);
                // setting value cho cột số phiếu
                rowInfo.Cells["SoPhieu"].Value = item;
                // thêm vào danh sách
                rgvSoPhieu.Rows.Add(rowInfo);
            }

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
        
        /// <summary>
        /// Xóa toàn bộ data đã input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblFileName.Text = "";
            rgvProduct.Rows.Clear();
            rgvSoPhieu.Rows.Clear();
            btnClear.Enabled = false;
            btnUpdateAll.Enabled = false;
            DanhSachPhieuGiao = new List<PhieuGiao>();
            workbook.Dispose();
        }

        /// <summary>
        /// Tìm số phiếu theo mã hàng
        /// </summary>
        /// <param name="mahang"></param>
        /// <returns></returns>
        private List<string> TimSoPhieuTheoMaHang(string mahang)
        {
            List<string> data = new List<string>();

            foreach (var item in DanhSachPhieuGiao)
            {
                if (item.CheckMaHang(mahang))
                {
                    data.Add(item.SoPhieu);
                }
            }
            return data;
        }

        /// <summary>
        /// Tìm phiếu giao theo mã hàng
        /// </summary>
        /// <param name="mahang"></param>
        /// <returns></returns>
        private void CapNhatPhieuGiaoTheoMaHang(IXLWorksheet worksheet, string mahang, string giathung, string giale)
        {
            // duyệt danh sách phiếu giao
            foreach (var item in DanhSachPhieuGiao)
            {
                // Cập nhật giá
                item.CapNhatGia(mahang, giathung.Replace(",", ""), giale.Replace(",", ""));
                // update lại toàn bộ phiếu
                item.Refresh();
                //update vào dòng của file excell;
                item.CapNhatToWorkSheet(worksheet);
            }
        }

        /// <summary>
        /// Cập nhật toàn bộ vào file input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateAll_Click(object sender, EventArgs e)
        {
            // Lấy sheet
            IXLWorksheet worksheet = workbook.Worksheet(1);
            // xác nhận update
            string message = "Bạn có muốn thực hiện cập nhật tất cả " + rgvSoPhieu.Rows.Count + " phiếu giao?";
            if (MessageBox.Show(message, "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            // duyệt các dòng được chọn
            foreach (var item in rgvProduct.Rows)
            {
                // Lấy mã hàng
                string mahang = item.Cells["ID"].Value.ToString();
                // Lấy giá thùng
                string giathung = item.Cells["Price1"].Value.ToString().Replace(",", "");
                // Lấy giá lẻ
                string giale = item.Cells["Price2"].Value.ToString().Replace(",", "");
                // Cập nhận phiếu giao có chứa mã hàng
                CapNhatPhieuGiaoTheoMaHang(worksheet, mahang, giathung, giale);
            }
            // Lưu workbook
            workbook.Save();
            // Thông báo hoàn tất
            MessageBox.Show("Cập nhật thành công " + rgvSoPhieu.Rows.Count + " phiếu giao.");

        }
    }
}
