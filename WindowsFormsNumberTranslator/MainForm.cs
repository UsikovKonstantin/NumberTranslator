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

        #region Main Region

        void At_Change()
        {
            // Зануление выводов
            Data_Label.Text = "";
            Number_Base_Q.Text = "";

            // Выключение подсветки ошибочного ввода
            Base_P_Error.Visible = false;
            Base_Q_Error.Visible = false;
            Number_Base_P_Error.Visible = false;
            Accuracy_Error.Visible = false;

            // Эти переменные нужны чтобы в вывод не попадало конфликтующих, неверных и других противоречащих утверждний
            bool P_Fail = P_Base_Checks();
            bool num_Fail = Number_Base_P_Checks(P_Fail);
            bool Q_Fail = Q_Base_Checks();
            bool acc_Fail = Accuracy_Checks();

            // Если все проверки прошли
            if (!num_Fail && !P_Fail && !Q_Fail && !acc_Fail)
            {
                Try_Translation();
            }
        }

        void Try_Translation()
        {
            // Наше число не может быть больше чем 2^63 - 1,иначе будет переполнение переменной 
            try
            {
                string[] input = Number_Base_P.Text.Split('.', ',');
                string result = "";
                result += NumberTranslator.FromPtoQInt(input[0], int.Parse(Base_P.Text), int.Parse(Base_Q.Text));
                if (input.Length == 2 && int.Parse(Accuracy.Text) != 0 && double.Parse(input[1]) != 0) // Когда есть нецелая часть (дробная)
                {
                    result += $".{NumberTranslator.FromPtoQFrac(input[1], int.Parse(Base_P.Text), int.Parse(Base_Q.Text), int.Parse(Accuracy.Text))}";
                    if (result.Split('.')[1] == "")
                    {
                        result = result.Remove(result.Length - 2, 1);
                    }
                }
                Number_Base_Q.Text = result.Substring(0, Math.Min(58, result.Length));      // Чтобы результат не выходил за границы textBox
            }
            catch (OverflowException)
            {
                Data_Label.Text += "Целая часть числа вызвала переполнение. \n";
                Number_Base_P_Error.Visible = true;
            }
        }
        #endregion

        #region Number Base P Checks

        bool Number_Base_P_Checks(bool P_Fail)
        {
            // Введено ли что либо в поле текста?
            bool num_Fail = Number_Base_P_IsEmpty_Check();

            // В исходном числе символ пунктуации не может стоять на первой или последней позиции
            if (!num_Fail)
            {
                num_Fail = Number_Base_P_PunctuationMarkPlace_Check();
            }

            // В исходном числе должен быть только один знак пунктуации
            if (!num_Fail)
            {
                num_Fail = Number_Base_P_HasMoreThanOnePunctuationMark_Check();
            }

            // В исходном числе допустимы только символы: 0..9, a..z, A..Z, '.', ','
            if (!num_Fail)
            {
                num_Fail = Number_Base_P_SymbolValidity_Check();
            }

            // Все цифры исходного числа должны быть допустимыми в выбранной системе счисления
            if (!num_Fail && !P_Fail)
            {
                num_Fail = Number_Base_P_SomeNumberDoNotExist_Check();
            }

            return num_Fail;
        }

        bool Number_Base_P_IsEmpty_Check()
        {
            if (Number_Base_P.Text == "")
            {
                Data_Label.Text += "Введите исходное число. \n";
                Number_Base_P_Error.Visible = true;
                return true;
            }

            return false;
        }

        bool Number_Base_P_PunctuationMarkPlace_Check()
        {
            if (Number_Base_P.Text[0] == '.' || Number_Base_P.Text[0] == ','
                            || Number_Base_P.Text[Number_Base_P.Text.Length - 1] == '.'
                            || Number_Base_P.Text[Number_Base_P.Text.Length - 1] == ',')
            {
                Data_Label.Text += "Исходное число начинается или заканчивается символом пунктуации. \n";
                Number_Base_P_Error.Visible = true;
                return true;
            }

            return false;
        }

        bool Number_Base_P_HasMoreThanOnePunctuationMark_Check()
        {
            if (Number_Base_P.Text.IndexOf(".") != Number_Base_P.Text.LastIndexOf(".") ||
                            Number_Base_P.Text.IndexOf(",") != Number_Base_P.Text.LastIndexOf(",") || (
                            Number_Base_P.Text.IndexOf(".") > -1 && Number_Base_P.Text.LastIndexOf(",") > -1))
            {
                Data_Label.Text += "В исходном числе присутствует более чем один символ пунктуации. \n";
                Number_Base_P_Error.Visible = true;
                return true;
            }

            return false;
        }

        bool Number_Base_P_SymbolValidity_Check()
        {
            foreach (char v in Number_Base_P.Text)
            {
                if (!(char.IsNumber(v)
                    || (v >= 'A' && v <= 'Z')
                    || (v >= 'a' && v <= 'z')
                    || v == '.' || v == ','))
                {
                    Data_Label.Text += "Неверный ввод исходного числа. Допустимые символы: 0..9, a..z, A..Z, '.', ','. \n";
                    Number_Base_P_Error.Visible = true;
                    return true;
                }
            }
            return false;
        }

        bool Number_Base_P_SomeNumberDoNotExist_Check()
        {
            foreach (char c in Number_Base_P.Text)
            {
                if (NumberTranslator.FromCharToInt(c) >= int.Parse(Base_P.Text))
                {
                    Data_Label.Text += $"В исходном числе присутствует цифра \"{c}\" недопустимая в системе счисления {Base_P.Text}. \n";
                    Number_Base_P_Error.Visible = true;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region P Base Checks

        bool P_Base_Checks()
        {
            // Введено ли что либо в поле текста?
            bool P_Fail = P_Base_IsEmpty_Check();

            // Основание должно приводиться к целому типу
            if (!P_Fail)
            {
                P_Fail = P_base_IsNotConvertableToInt_Check();
            }

            // Основание должно быть в промежутке от 2 до 36 включительно
            if (!P_Fail)
            {
                P_Fail = P_base_Interval_Check();
            }

            return P_Fail;
        }

        bool P_Base_IsEmpty_Check()
        {
            if (Base_P.Text == "")
            {
                Data_Label.Text += "Введите исходное основание. \n";
                Base_P_Error.Visible = true;
                return true;
            }

            return false;
        }

        bool P_base_IsNotConvertableToInt_Check()
        {
            try
            {
                int.Parse(Base_P.Text);
            }
            catch (Exception)
            {
                Data_Label.Text += "Исходное основание нельзя привести к целому типу. \n";
                Base_P_Error.Visible = true;
                return true;
            }

            return false;
        }

        bool P_base_Interval_Check()
        {
            if (int.Parse(Base_P.Text) <= 1 || int.Parse(Base_P.Text) > 36)
            {
                Data_Label.Text += "Исходное основание должно быть в промежутке от 2 до 36 включительно. \n";
                Base_P_Error.Visible = true;
                return true;
            }

            return false;
        }

        #endregion

        #region Q Base Checks

        bool Q_Base_Checks()
        {
            // Введено ли что либо в поле текста?
            bool Q_Fail = Q_Base_IsEmpty_Check();

            // Основание должно быть в промежутке от 2 до 36 включительно
            if (!Q_Fail)
            {
                Q_Fail = Q_base_IsNotConvertableToInt_Check();
            }

            // Основание должно приводиться к целому типу
            if (!Q_Fail)
            {
                Q_Fail = Q_base_Interval_Check();
            }

            return Q_Fail;
        }

        bool Q_Base_IsEmpty_Check()
        {
            if (Base_Q.Text == "")
            {
                Data_Label.Text += "Введите основание результата. \n";
                Base_Q_Error.Visible = true;
                return true;
            }

            return false;
        }

        bool Q_base_Interval_Check()
        {
            if (int.Parse(Base_Q.Text) <= 1 || int.Parse(Base_Q.Text) > 36)
            {
                Data_Label.Text += "Основание результата должно быть в промежутке от 2 до 36 включительно. \n";
                Base_Q_Error.Visible = true;
                return true;
            }

            return false;
        }

        bool Q_base_IsNotConvertableToInt_Check()
        {
            try
            {
                int.Parse(Base_Q.Text);
            }
            catch (Exception)
            {
                Data_Label.Text += "Основание результата нельзя привести к целому типу. \n";
                Base_Q_Error.Visible = true;
                return true;
            }

            return false;
        }

        #endregion

        #region Accuracy Checks

        bool Accuracy_Checks()
        {
            // Введено ли что либо в поле текста?
            bool acc_Fail = Accuracy_IsEmpty_Check();

            // Основания и количество знаков после запятой должны приводиться к целому типу
            if (!acc_Fail)
            {
                acc_Fail = Accuracy_IsNotConvertableToInt_Check();
            }

            // Количество знаков после запятой должно быть не отрицательным
            if (!acc_Fail)
            {
                acc_Fail = Accuracy_IsNegative_Check();
            }

            return acc_Fail;
        }

        bool Accuracy_IsEmpty_Check()
        {
            if (Accuracy.Text == "")
            {
                Data_Label.Text += "Введите количество знаков после запятой. \n";
                Accuracy_Error.Visible = true;
                return true;
            }

            return false;
        }

        bool Accuracy_IsNotConvertableToInt_Check()
        {
            try
            {
                int.Parse(Accuracy.Text);
            }
            catch (Exception)
            {
                Data_Label.Text += "Количество знаков после запятой нельзя привести к целому типу. \n";
                Accuracy_Error.Visible = true;
                return true;
            }

            return false;
        }

        bool Accuracy_IsNegative_Check()
        {
            if (int.Parse(Accuracy.Text) < 0)
            {
                Data_Label.Text += "Количество знаков после запятой должно быть не отрицательным. \n";
                Accuracy_Error.Visible = true;
                return true;
            }

            return false;
        }

        #endregion
    }
}