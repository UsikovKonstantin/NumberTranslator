using ClassLibraryNumberTranslator;
using System;
using System.Windows.Forms;

namespace WindowsFormsNumberTranslator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Number_Base_P_TextChanged(object sender, EventArgs e)
        {
            At_Change();
        }

        private void Base_P_TextChanged(object sender, EventArgs e)
        {
            At_Change();
        }

        private void Base_Q_TextChanged(object sender, EventArgs e)
        {
            At_Change();
        }
        void At_Change()
        {
            Data_Label.Text = "";
            bool hit_num = false, hit_P = false, hit_Q = false;
            if (Number_Base_P.Text == "")
            {
                Data_Label.Text += "Введите число по основанию P. \n";
                hit_num = true;
            }
            if (Base_P.Text == "")
            {
                Data_Label.Text += "Введите Основание P. \n";
                hit_P = true;
            }
            if (Base_Q.Text == "")
            {
                Data_Label.Text += "Введите Основание Q. \n";
                hit_Q = true;
            }
            try
            {
                double.Parse(Number_Base_P.Text);
            }
            catch (Exception)
            {
                if (!hit_num)
                {
                    Data_Label.Text += "Неверный ввод числа по основанию P. \n";
                    hit_num = true;
                }
            }
            try
            {
                int.Parse(Base_P.Text);
            }
            catch (Exception)
            {
                if (!hit_P)
                {
                    Data_Label.Text += "Неверное основание P. \n";
                    hit_P = true;
                }
            }
            try
            {
                int.Parse(Base_Q.Text);
            }
            catch (Exception)
            {
                if (!hit_Q)
                {
                    Data_Label.Text += "Неверное основание Q. \n";
                    hit_Q = true;
                }
            }
            if (!hit_P && (int.Parse(Base_P.Text) <= 1 || int.Parse(Base_P.Text) > 10))
            {
                Data_Label.Text += "Основание P должно быть в промежутке от 2 до 10 включительно. \n";
                hit_P = true;
            }
            if (!hit_Q && (int.Parse(Base_Q.Text) <= 1 || int.Parse(Base_Q.Text) > 10))
            {
                Data_Label.Text += "Основание Q должно быть в промежутке от 2 до 10 включительно. \n";
                hit_Q = true;
            }
            if (!hit_num && (Number_Base_P.Text.IndexOf(".") != Number_Base_P.Text.LastIndexOf(".") ||
                Number_Base_P.Text.IndexOf(",") != Number_Base_P.Text.LastIndexOf(",") || (
                Number_Base_P.Text.IndexOf(".") > -1 && Number_Base_P.Text.LastIndexOf(",") > -1)))
            {
                hit_num = true;
                Data_Label.Text += "В числе присутствует более чем один символ пунктуации. \n";
            }
            if (!hit_num && !hit_P)
            {
                for (int i = 0; i < Number_Base_P.Text.Length; i++)
                {
                    if (NumberTranslator.CharToInt(Number_Base_P.Text[i]) >= int.Parse(Base_P.Text))
                    {
                        hit_num = true;
                        Data_Label.Text += $"В числе по основанию P присутствует цифра недопустимая в системе счисления {Base_P.Text}.";
                        break;
                    }
                }
            }
            if (!hit_num && !hit_P && !hit_Q)
            {
                Find_Q_Num();
            }
        }
        void Find_Q_Num()
        {
            string[] arr = Number_Base_P.Text.Split('.', ',');
            string[] res = new string[arr.Length];
            if (arr.Length == 2 && arr[1].Length>0)
            {
                res[0] = NumberTranslator.From10toQInt(NumberTranslator.FromPto10Int(arr[0], int.Parse(Base_P.Text)), int.Parse(Base_Q.Text));
                res[1] = NumberTranslator.From10toQFrac(NumberTranslator.FromPto10Frac(arr[1], int.Parse(Base_P.Text)), int.Parse(Base_Q.Text), 10);
                Number_Base_Q.Text = $"{res[0]}.{res[1]}";
            }
            else
            {
                res[0] = NumberTranslator.From10toQInt(NumberTranslator.FromPto10Int(arr[0], int.Parse(Base_P.Text)), int.Parse(Base_Q.Text));
                Number_Base_Q.Text = $"{res[0]}";
            }

        }
    }
}
