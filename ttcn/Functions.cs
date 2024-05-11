using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ttcn.Class
{
    internal class Functions
    {
            public static SqlConnection Conn;
            public static string connstring;

        //[Phương thức kết nối tới cơ sở dữ liệu]
        public static void Ketnoi()
        {
            connstring = @"Data Source=LAPTOP-59G1UB6L\LANANH;Initial Catalog=qlkho;Integrated Security=True;Encrypt=False";
            Conn = new SqlConnection();
            Conn.ConnectionString = connstring;
            Conn.Open();
            //MessageBox.Show("Ket noi thanh cong!");
        }

        //[Phương thức ngắt kết nối từ cơ sở dữ liệu]
        public static void ngatketnoi()
        {
            if (Conn.State == System.Data.ConnectionState.Open)
            {
                Conn.Close();
                Conn.Dispose();
                Conn = null;
            }
        }

        //[Phương thức truy vấn dữ liệu và trả về DataTable]
        public static DataTable GetdataToTable(string sql)
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connstring))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table;
        }

        //[Phương thức kiểm tra xem câu lệnh SQL có trả về kết quả hay không]
        public static bool Checkkey(string sql)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        //[Phương thức thực thi câu lệnh SQL không trả về kết quả]
        public static void Runsql(string sql)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //[Phương thức điền dữ liệu vào ComboBox từ cơ sở dữ liệu]
        public static void Fillcombo(string sql, ComboBox cbo, string ma, string ten)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connstring))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        cbo.DataSource = table;
                        cbo.ValueMember = ma;
                        cbo.DisplayMember = ten;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //[Phương thức truy vấn một giá trị duy nhất từ cơ sở dữ liệu]
        public static string getfilevalue(string sql)
        {
            string result = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result = reader.GetValue(0).ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        public static int GetSelectedValue(ComboBox comboBox)
        {
            int result = -1;

            if (comboBox.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(comboBox.ValueMember))
                {
                    if (int.TryParse(comboBox.SelectedValue.ToString(), out int selectedValue))
                    {
                        result = selectedValue;
                    }
                }
                else
                {
                    int selectedIndex = comboBox.SelectedIndex;
                    if (selectedIndex != -1)
                    {
                        DataRowView selectedRow = comboBox.SelectedItem as DataRowView;
                        if (selectedRow != null)
                        {
                            if (int.TryParse(selectedRow.Row[0].ToString(), out int selectedValue))
                            {
                                result = selectedValue;
                            }
                        }
                    }
                }
            }

            return result;
        }

        public static int ConvertToInt32(string value)
        {
            int result = 0;
            try
            {
                result = Convert.ToInt32(value);
            }
            catch (FormatException)
            {
                MessageBox.Show("Giá trị không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Giá trị quá lớn hoặc quá nhỏ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return result;
        }
        public static void ClearComboBoxes(params ComboBox[] comboBoxes)
            {
                foreach (ComboBox comboBox in comboBoxes)
                {
                    comboBox.SelectedIndex = -1;
                    comboBox.Text = string.Empty;
                }
            }
            public static void ClearTextBoxes(params TextBox[] textBoxes)
            {
                foreach (TextBox textBox in textBoxes)
                {
                    textBox.Clear();
                }
            }
        public static string CreateKey(string t)
        {
            string key = t;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            if (partsTime[2].Length >= 5 && partsTime[2].Substring(partsTime[2].Length - 2) == "PM")
            {
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            }
            if (partsTime[2].Length >= 5 && partsTime[2].Substring(partsTime[2].Length - 2) == "AM")
            {
                if (partsTime[0].Length == 1)
                {
                    partsTime[0] = "0" + partsTime[0];
                }
            }
            partsTime[2] = partsTime[2].Remove(2, partsTime[2].Length - 2);
            string a = String.Format("{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + a;
            if (key.Length > 15)
            {
                key = key.Substring(0, 15);
            }
            return key;
        }
        public static void RunSQL(string sql)
        {
            SqlCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SqlCommand();
            cmd.Connection = Conn; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
        }
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }
        public static string ChuyenSoSangChu(string number)
        {
            string result = "";
            string[] dv = { "", " một", " hai", " ba", " bốn", " năm", " sáu", " bảy", " tám", " chín" };
            string[] donvi = { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
            string[] dv1 = { "", " mốt", " hai", " ba", " bốn", " lăm", " sáu", " bảy", " tám", " chín" };

            int i, j, k, n, len, found, ddv, rd;

            len = number.Length;
            number += "ss";
            result = "";

            ddv = 0;
            rd = 0;

            i = 0;
            while (i < len)
            {
                //So chu so o hang dang duyet
                n = (len - i + 2) % 3 + 1;

                //Kiem tra so 0
                found = 0;
                for (j = 0; j < n; j++)
                {
                    if (number[i + j] != '0')
                    {
                        found = 1;
                        break;
                    }
                }

                //Duyet n chu so
                if (found == 1)
                {
                    rd = 1;
                    for (j = 0; j < n; j++)
                    {
                        ddv = 1;
                        switch (number[i + j])
                        {
                            case '0':
                                if (n - j == 3) result += " không";
                                if (n - j == 2)
                                {
                                    if (number[i + j + 1] != '0') result += " linh";
                                    ddv = 0;
                                }
                                break;
                            case '1':
                                if (n - j == 3) result += " một";
                                if (n - j == 2)
                                {
                                    result += " mười";
                                    ddv = 0;
                                }
                                if (n - j == 1)
                                {
                                    if (i + j == 0) k = 0;
                                    else k = i + j - 1;

                                    if (number[k] != '1' && number[k] != '0')
                                        result += " mốt";
                                    else
                                        result += dv1[1];
                                }
                                break;
                            case '5':
                                if (i + j == len - 1)
                                    result += " lăm";
                                else
                                    result += dv1[5];
                                break;
                            default:
                                int intValue;
                                if (int.TryParse(number[i + j].ToString(), out intValue))
                                {
                                    result += dv[intValue];
                                }
                                break;
                        }

                        //Them don vi nho
                        if (ddv == 1)
                            result += donvi[n - j - 1];
                    }
                }

                //Them don vi lon
                if (len - i - n > 0)
                {
                    if ((len - i - n) % 9 == 0)
                    {
                        if (rd == 1)
                            for (k = 0; k < (len - i - n) / 9; k++)
                                result += " tỷ";
                        rd = 0;
                    }
                    else
                        if (found != 0) result += donvi[((len - i - n + 1) % 9) / 3 + 1];
                }

                i += n;
            }

            if (len == 1)
            {
                int intValue;
                if (int.TryParse(number[0].ToString(), out intValue))
                {
                    if (intValue == 0 || intValue == 5) return dv[intValue];
                    else if (intValue == 1) return " một";
                    else return dv[intValue] + " mươi";
                }
            }

            return result.Trim();
        }
    }

}
