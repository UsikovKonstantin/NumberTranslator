using System;
using System.Windows.Forms;
using ClassLibraryNumberTranslator;

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

        void At_Change()
        {
            Data_Label.Text = "";
            Number_Base_Q.Text = "";
            Base_P_Error.Visible = false;
            Base_Q_Error.Visible = false;
            Number_Base_P_Error.Visible = false;
            Accuracy_Error.Visible = false;

            // Эти переменные нужны чтобы в вывод не попадало конфликтующих, неверных и других противоречащих утверждний
            bool num_Fail = false, P_Fail = false, Q_Fail = false, acc_Fail = false;

            // Введено ли что либо в поле текста?
            if (Number_Base_P.Text == "")
            {
                Data_Label.Text += "Введите исходное число. \n";
                num_Fail = true;
            }

            if (Base_P.Text == "")
            {
                Data_Label.Text += "Введите исходное основание. \n";
                P_Fail = true;
            }

            if (Base_Q.Text == "")
            {
                Data_Label.Text += "Введите основание результата. \n";
                Q_Fail = true;
            }

            if (Accuracy.Text == "")
            {
                Data_Label.Text += "Введите количество знаков после запятой. \n";
                acc_Fail = true;
            }

            // В исходном числе должен быть максимум 1 знак '-'
            if (!num_Fail && (Number_Base_P.Text.IndexOf("-") != Number_Base_P.Text.LastIndexOf("-")))
            {
                Data_Label.Text += "В исходном числе присутствует более чем один символ '-'. \n";
                Number_Base_P_Error.Visible = true;
                num_Fail = true;
            }

            // В исходном числе знак '-' может стоять только на первой позиции
            if (!num_Fail && Number_Base_P.Text.IndexOf("-") != -1 && Number_Base_P.Text.IndexOf("-") != 0)
            {
                Data_Label.Text += "В исходном числе символ '-' стоит не на первой позиции. \n";
                Number_Base_P_Error.Visible = true;
                num_Fail = true;
            }

            // В исходном числе допустимы только символы: '-', 0..9, a..z, A..Z, '.', ','
            if (!num_Fail)
            {
                for (int i = 0; i < Number_Base_P.Text.Length; i++)
                {
                    if (!(char.IsNumber(Number_Base_P.Text[i])
                        || (Number_Base_P.Text[i] >= 'A' && Number_Base_P.Text[i] <= 'Z')
                        || (Number_Base_P.Text[i] >= 'a' && Number_Base_P.Text[i] <= 'z')
                        || Number_Base_P.Text[i] == '.' || Number_Base_P.Text[i] == ','
                        || (i == 0 && Number_Base_P.Text[i] == '-')))
                    {
                        Data_Label.Text += "Неверный ввод исходного числа. Допустимые символы: '-', 0..9, a..z, A..Z, '.', ','. \n";
                        Number_Base_P_Error.Visible = true;
                        num_Fail = true;
                        break;
                    }
                }
            }

            // В исходном числе символ пунктуации не может стоять на первой или последней позиции
            if (!num_Fail && (Number_Base_P.Text[0] == '.' || Number_Base_P.Text[0] == ','
                || Number_Base_P.Text[Number_Base_P.Text.Length - 1] == '.'
                || Number_Base_P.Text[Number_Base_P.Text.Length - 1] == ','))
            {
                Data_Label.Text += "Исходное число начинается или заканчивается символом пунктуации. \n";
                Number_Base_P_Error.Visible = true;
                num_Fail = true;
            }

            // Основания и количество знаков после запятой должны приводиться к целому типу
            try
            {
                int.Parse(Base_P.Text);
            }
            catch (Exception)
            {
                if (!P_Fail)
                {
                    Data_Label.Text += "Исходное основание нельзя привести к целому типу. \n";
                    Base_P_Error.Visible = true;
                    P_Fail = true;
                }
            }

            try
            {
                int.Parse(Base_Q.Text);
            }
            catch (Exception)
            {
                if (!Q_Fail)
                {
                    Data_Label.Text += "Основание результата нельзя привести к целому типу. \n";
                    Base_Q_Error.Visible = true;
                    Q_Fail = true;
                }
            }

            try
            {
                int.Parse(Accuracy.Text);
            }
            catch (Exception)
            {
                if (!acc_Fail)
                {
                    Data_Label.Text += "Количество знаков после запятой нельзя привести к целому типу. \n";
                    Accuracy_Error.Visible = true;
                    acc_Fail = true;
                }
            }

            // Основания должны быть в промежутке от 2 до 36 включительно
            if (!P_Fail && (int.Parse(Base_P.Text) <= 1 || int.Parse(Base_P.Text) > 36))
            {
                Data_Label.Text += "Исходное основание должно быть в промежутке от 2 до 36 включительно. \n";
                Base_P_Error.Visible = true;
                P_Fail = true;
            }

            if (!Q_Fail && (int.Parse(Base_Q.Text) <= 1 || int.Parse(Base_Q.Text) > 36))
            {
                Data_Label.Text += "Основание результата должно быть в промежутке от 2 до 36 включительно. \n";
                Base_Q_Error.Visible = true;
                Q_Fail = true;
            }

            // Количество знаков после запятой должно быть не отрицательным
            if (!acc_Fail && int.Parse(Accuracy.Text) < 0)
            {
                Data_Label.Text += "Количество знаков после запятой должно быть не отрицательным. \n";
                Accuracy_Error.Visible = true;
                acc_Fail = true;
            }

            // В исходном числе должен быть только один знак пунктуации
            if (!num_Fail && (Number_Base_P.Text.IndexOf(".") != Number_Base_P.Text.LastIndexOf(".") ||
                Number_Base_P.Text.IndexOf(",") != Number_Base_P.Text.LastIndexOf(",") || (
                Number_Base_P.Text.IndexOf(".") > -1 && Number_Base_P.Text.LastIndexOf(",") > -1)))
            {
                Data_Label.Text += "В исходном числе присутствует более чем один символ пунктуации. \n";
                Number_Base_P_Error.Visible = true;
                num_Fail = true;
            }

            // Все цифры числа исходного числа должны быть допустимыми в выбранной системе счисления
            if (!num_Fail && !P_Fail)
            {
                for (int i = 0; i < Number_Base_P.Text.Length; i++)
                {
                    if (NumberTranslator.CharToLong(Number_Base_P.Text[i]) >= int.Parse(Base_P.Text))
                    {
                        Data_Label.Text += $"В исходном числе присутствует цифра \"{Number_Base_P.Text[i]}\" недопустимая в системе счисления {Base_P.Text}. \n";
                        Number_Base_P_Error.Visible = true;
                        num_Fail = true;
                        break;
                    }
                }
            }

            // Если все проверки прошли
            if (!num_Fail && !P_Fail && !Q_Fail && !acc_Fail)
            {
                // Наше число не может быть больше чем 2^63 - 1,иначе будет переполнение переменной 
                try
                {
                    string result = NumberTranslator.FromPtoQ(Number_Base_P.Text, int.Parse(Base_P.Text), int.Parse(Base_Q.Text), int.Parse(Accuracy.Text));
                    Number_Base_Q.Text = result.Substring(0, Math.Min(50, result.Length));      // Чтобы результат не выходил за границы textBox
                }
                catch (Exception)
                {
                    Data_Label.Text += "Целая часть числа вызвала переполнение. \n";
                    Number_Base_P_Error.Visible = true;
                }
            }
        }
    }
}