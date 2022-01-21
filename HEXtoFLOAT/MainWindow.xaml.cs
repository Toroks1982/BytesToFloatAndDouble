using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HEXtoFLOAT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<TextBox> _listTb = new List<TextBox>();

        public MainWindow()
        {
            InitializeComponent();
            tb1.Focus();

            _listTb.Add(tb1D);
            _listTb.Add(tb2D);
            _listTb.Add(tb3D);
            _listTb.Add(tb4D);
            _listTb.Add(tb5D);
            _listTb.Add(tb6D);
            _listTb.Add(tb7D);
            _listTb.Add(tb8D);
        }

        /// <summary>
        /// Расчет HEX в FLOAT
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = "";
            if (String.IsNullOrEmpty(tb1.Text)) { tbResult.Text = "1st byte is bad"; tb1.Focus(); tb1.SelectAll(); return; }
            if (String.IsNullOrEmpty(tb2.Text)) { tbResult.Text = "2nd byte is bad"; tb2.Focus(); tb2.SelectAll(); return; }
            if (String.IsNullOrEmpty(tb3.Text)) { tbResult.Text = "3rd byte is bad"; tb3.Focus(); tb3.SelectAll(); return; }
            if (String.IsNullOrEmpty(tb4.Text)) { tbResult.Text = "4th byte is bad"; tb4.Focus(); tb4.SelectAll(); return; }
           
            try
            {
                byte[] bytes = new byte[4];
                bytes[0] = Convert.ToByte(tb1.Text, 16);
                bytes[1] = Convert.ToByte(tb2.Text, 16);
                bytes[2] = Convert.ToByte(tb3.Text, 16);
                bytes[3] = Convert.ToByte(tb4.Text, 16);

                float otvet = BitConverter.ToSingle(bytes, 0);
                tbResult.Text = otvet.ToString();
                tbResult2.Text = otvet.ToString("F4");
                tbResult.Focus();
                tbResult.SelectAll();
            }
            catch (Exception ex)
            {
                tbResult.Text = $"Error: {ex.Message}";
                tb1.Focus();
                tb1.SelectAll();
            }
        }

        private void Tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                tb2.Focus();
                tb2.SelectAll();
            }

        }

        private void Tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                tb3.Focus();
                tb3.SelectAll();
            }
        }

        private void Tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                tb4.Focus();
                tb4.SelectAll();
            }
        }

        private void Tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btCalculate.Focus();
            }
        }

        private void TbResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                tb1.Focus();
                tb1.SelectAll();
            }
        }

        private void Tb4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                if (String.IsNullOrEmpty(tb4.Text))
                {
                    tb3.Focus();
                    tb3.SelectAll();
                }
            }
        }

        private void Tb3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                if (String.IsNullOrEmpty(tb3.Text))
                {
                    tb2.Focus();
                    tb2.SelectAll();
                }
            }
        }

        private void Tb2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                if (String.IsNullOrEmpty(tb2.Text))
                {
                    tb1.Focus();
                    tb1.SelectAll();
                }
            }
        }

        private void Tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbResult.Text = "";
            tbResult2.Text = "";
            var tb = sender as TextBox;

            // проверка на кол-во символов не более 2-х
            if (tb.Text?.Length > 2)
            {
                tb.Text = tb.Text.Remove(2);
                tb.Select(tb.Text.Length, 0);
            }
            // проверка символов на допустимые
            if (tb.Text?.Length > 0)
            {
                try
                {
                    var b = Convert.ToByte(tb.Text, 16);
                }
                catch (Exception ex)
                {
                    tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                    tb.Select(tb.Text.Length, 0);
                }
            }
        }

        private void Tb1D_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                tb2D.Focus();
                tb2D.SelectAll();
            }
        }

        private void Tb2D_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                tb3D.Focus();
                tb3D.SelectAll();
            }
            
        }

       
        private void Tb3D_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                tb4D.Focus();
                tb4D.SelectAll();
            }
            else
            {
                if (e.Key == Key.Back)
                {
                    if (String.IsNullOrEmpty(tb3D.Text))
                    {
                        tb2D.Focus();
                        tb2D.SelectAll();
                    }
                }
            }
        }

              private void Tb4D_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                tb5D.Focus();
                tb5D.SelectAll();
            }
            else
            {
                if (e.Key == Key.Back)
                {
                    if (String.IsNullOrEmpty(tb4D.Text))
                    {
                        tb3D.Focus();
                        tb3D.SelectAll();
                    }
                }
            }
        }


        private void Tb5D_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {
                tb6D.Focus();
                tb6D.SelectAll();
            } else { if (e.Key == Key.Back) {
                    if (String.IsNullOrEmpty(tb5D.Text)) {
                        tb4D.Focus();
                        tb4D.SelectAll();
                    }
                }
            }
        }

        private void Tb6D_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                tb7D.Focus();
                tb7D.SelectAll();
            }
            else
            {
                if (e.Key == Key.Back)
                {
                    if (String.IsNullOrEmpty(tb6D.Text))
                    {
                        tb5D.Focus();
                        tb5D.SelectAll();
                    }
                }
            }
        }

        private void Tb7D_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                tb8D.Focus();
                tb8D.SelectAll();
            }
            else
            {
                if (e.Key == Key.Back)
                {
                    if (String.IsNullOrEmpty(tb7D.Text))
                    {
                        tb6D.Focus();
                        tb6D.SelectAll();
                    }
                }
            }
        }

        private void Tb8D_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btCalculateD.Focus();
            }
            else
            {
                if (e.Key == Key.Back)
                {
                    if (String.IsNullOrEmpty(tb8D.Text))
                    {
                        tb7D.Focus();
                        tb7D.SelectAll();
                    }
                }
            }
        }

        private void TbResultD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                tb1D.Focus();
                tb1D.SelectAll();
            }
        }

        /// <summary>
        ///  Расчет HEX в DOUBLE
        /// </summary>
        private void ButtonD_Click(object sender, RoutedEventArgs e)
        {
            tbResultD.Text = "";
            if (String.IsNullOrEmpty(tb1D.Text)) { tbResultD.Text = "1st byte is bad"; tb1D.Focus(); tb1D.SelectAll(); return; }
            if (String.IsNullOrEmpty(tb2D.Text)) { tbResultD.Text = "2nd byte is bad"; tb2D.Focus(); tb2D.SelectAll(); return; }
            if (String.IsNullOrEmpty(tb3D.Text)) { tbResultD.Text = "3rd byte is bad"; tb3D.Focus(); tb3D.SelectAll(); return; }
            if (String.IsNullOrEmpty(tb4D.Text)) { tbResultD.Text = "4th byte is bad"; tb4D.Focus(); tb4D.SelectAll(); return; }
            if (String.IsNullOrEmpty(tb5D.Text)) { tbResultD.Text = "5th byte is bad"; tb5D.Focus(); tb5D.SelectAll(); return; }
            if (String.IsNullOrEmpty(tb6D.Text)) { tbResultD.Text = "6th byte is bad"; tb6D.Focus(); tb6D.SelectAll(); return; }
            if (String.IsNullOrEmpty(tb7D.Text)) { tbResultD.Text = "7th byte is bad"; tb7D.Focus(); tb7D.SelectAll(); return; }
            if (String.IsNullOrEmpty(tb8D.Text)) { tbResultD.Text = "8th byte is bad"; tb8D.Focus(); tb8D.SelectAll(); return; }

            try
            {
                byte[] bytes = new byte[8];
                bytes[0] = Convert.ToByte(tb1D.Text, 16);
                bytes[1] = Convert.ToByte(tb2D.Text, 16);
                bytes[2] = Convert.ToByte(tb3D.Text, 16);
                bytes[3] = Convert.ToByte(tb4D.Text, 16);
                bytes[4] = Convert.ToByte(tb5D.Text, 16);
                bytes[5] = Convert.ToByte(tb6D.Text, 16);
                bytes[6] = Convert.ToByte(tb7D.Text, 16);
                bytes[7] = Convert.ToByte(tb8D.Text, 16);

                double otvet = BitConverter.ToDouble(bytes, 0);
                tbResultD.Text = otvet.ToString();
                tbResult2D.Text = otvet.ToString("F4");
                tbResultD.Focus();
                tbResultD.SelectAll();
            }
            catch (Exception ex)
            {
                tbResultD.Text = $"Error: {ex.Message}";
                tb1D.Focus();
                tb1D.SelectAll();
            }
        }

        private void TbD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                var tb = sender as TextBox;
                if (tb == null) return;
                if (String.IsNullOrEmpty(tb.Text))
                {
                    var tbPrev = _listTb[tb.TabIndex - 2];
                    switch (tb.TabIndex)
                    {
                        case 1: break;
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8: tbPrev.Focus(); tbPrev.SelectAll(); break;
                    }
                    
                }
            }
        }
    }
}
