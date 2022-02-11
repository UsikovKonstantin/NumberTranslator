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

        private void Accuracy_TextChanged(object sender, EventArgs e)
        {
            At_Change();
        }
        /// <summary>
        /// Функция выполянющая действия
        /// </summary>
        void At_Change()
        {
            Data_Label.Text = "";
            Number_Base_Q.Text = "";
            bool hit_num = false, hit_P = false, hit_Q = false, hit_acc = false; // Эти переменные нужны чтобы в вывод не попадало конфликтующих, неверных и других противоречащих утверждний
            // Введено ли что либо в поле текста?
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
            if (Accuracy.Text == "")
            {
                Data_Label.Text += "Введите количество знаков после запятой. \n";
                hit_acc = true;
            }
            // Первый уровень неверности числа
            for (int i = 0; i < Number_Base_P.Text.Length; i++)
            {
                if ((!(Char.IsNumber(Number_Base_P.Text[i])
                    || (Number_Base_P.Text[i] >= 'A' && Number_Base_P.Text[i] <= 'Z')
                    || (Number_Base_P.Text[i] >= 'a' && Number_Base_P.Text[i] <= 'z')
                    || Number_Base_P.Text[i] == '.' || Number_Base_P.Text[i] == ','))
                    && !hit_num)
                {
                    Data_Label.Text += "Неверный ввод числа по основанию P. \n";
                    hit_num = true;
                    break;
                }
            }
            if (!hit_num && (Number_Base_P.Text[0] == '.' || Number_Base_P.Text[0] == ','
                || Number_Base_P.Text[Number_Base_P.Text.Length - 1] == '.'
                || Number_Base_P.Text[Number_Base_P.Text.Length - 1] == ','))
            {
                Data_Label.Text += "Неверный ввод числа по основанию P. \n";
                hit_num = true;
            }
            // Корректность оснований
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
            try
            {
                int.Parse(Accuracy.Text);
            }
            catch (Exception)
            {
                if (!hit_acc)
                {
                    Data_Label.Text += "Неверное количество знаков после запятой. \n";
                    hit_acc = true;
                }
            }
            // Основания должны быть в этом промежутке
            if (!hit_P && (int.Parse(Base_P.Text) <= 1 || int.Parse(Base_P.Text) > 36))
            {
                Data_Label.Text += "Основание P должно быть в промежутке от 2 до 36 включительно. \n";
                hit_P = true;
            }
            if (!hit_Q && (int.Parse(Base_Q.Text) <= 1 || int.Parse(Base_Q.Text) > 36))
            {
                Data_Label.Text += "Основание Q должно быть в промежутке от 2 до 36 включительно. \n";
                hit_Q = true;
            }
            if (!hit_acc && int.Parse(Accuracy.Text) < 0)
            {
                Data_Label.Text += "Количество знаков после запятой должно быть не отрицательным. \n";
                hit_acc = true;
            }
            // В числе должен быть только один знак пунктуации
            if (!hit_num && (Number_Base_P.Text.IndexOf(".") != Number_Base_P.Text.LastIndexOf(".") ||
                Number_Base_P.Text.IndexOf(",") != Number_Base_P.Text.LastIndexOf(",") || (
                Number_Base_P.Text.IndexOf(".") > -1 && Number_Base_P.Text.LastIndexOf(",") > -1)))
            {
                hit_num = true;
                Data_Label.Text += "В числе присутствует более чем один символ пунктуации. \n";
            }
            // Все цифры числа должны быть допустимыми в выбранной системе счисления
            if (!hit_num && !hit_P)
            {
                for (int i = 0; i < Number_Base_P.Text.Length; i++)
                {
                    if (NumberTranslator.CharToLong(Number_Base_P.Text[i]) >= int.Parse(Base_P.Text))
                    {
                        hit_num = true;
                        Data_Label.Text += $"В числе по основанию P присутствует цифра недопустимая в системе счисления {Base_P.Text}.";
                        break;
                    }
                }
            }
            // Все проверки прошли
            if (!hit_num && !hit_P && !hit_Q && !hit_acc)
            {
                // Наше число не может быть больше чем 2^63 - 1,иначе будет переполнение переменной 
                try
                {
                    Find_Q_Num();
                }
                catch (Exception)
                {
                    Data_Label.Text += "Целая часть вызвала переполнение. \n";
                }
            }
        }
        void Find_Q_Num()
        {
            string[] arr = Number_Base_P.Text.Split('.', ',');
            string[] res = new string[] { "", "" };
            if (arr[0][0] == '-') // Для отрицательных чисел 
            {
                arr[0] = arr[0].Remove(0, 1);
                res[0] = NumberTranslator.From10toQInt(NumberTranslator.FromPto10Int(arr[0], int.Parse(Base_P.Text)), int.Parse(Base_Q.Text));
                res[0] = "-" + res[0];
            }
            else
            {
                res[0] = NumberTranslator.From10toQInt(NumberTranslator.FromPto10Int(arr[0], int.Parse(Base_P.Text)), int.Parse(Base_Q.Text));
            }
            if (arr.Length == 2) // Когда есть нецелая часть (дробная)
            {
                res[1] = NumberTranslator.From10toQFrac(NumberTranslator.FromPto10Frac(arr[1], int.Parse(Base_P.Text)), int.Parse(Base_Q.Text), int.Parse(Accuracy.Text));
                Number_Base_Q.Text = $"{res[0]}.{res[1]}";
                return;
            }
            Number_Base_Q.Text = $"{res[0]}";
        }
    }
}
