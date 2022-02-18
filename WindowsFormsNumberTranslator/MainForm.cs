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
            P_Fail = P_Base_Checks();
            num_Fail = Number_Base_P_Checks(P_Fail);
            Q_Fail = Q_Base_Checks();
            acc_Fail = Accuracy_Checks();

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
                string result = FromPtoQ(Number_Base_P.Text, int.Parse(Base_P.Text), int.Parse(Base_Q.Text), int.Parse(Accuracy.Text));
                Number_Base_Q.Text = result.Substring(0, Math.Min(58, result.Length));      // Чтобы результат не выходил за границы textBox
            }
            catch (Exception)
            {
                Data_Label.Text += "Целая часть числа вызвала переполнение. \n";
                Number_Base_P_Error.Visible = true;
            }
        }

        string FromPtoQ(string number, int P, int Q, int accuracy)
        {
            string[] input = number.Split('.', ',');
            string[] res = { "", "" };
            if (input[0][0] == '-') // Для отрицательных чисел 
            {
                input[0] = input[0].Remove(0, 1);
                res[0] += "-";
            }
            res[0] += NumberTranslator.From10toQInt(NumberTranslator.FromPto10Int(input[0], P), Q);

            // Когда есть нецелая часть (дробная)
            if (input.Length == 2 && accuracy != 0 && double.Parse(NumberTranslator.FromPto10Frac(input[1], P)) != 0)
            {
                res[1] = NumberTranslator.From10toQFrac(NumberTranslator.FromPto10Frac(input[1], P), Q, accuracy);
                if (res[1] == "")      // на случай, если дробная часть введённого числа очень близка к единице (1,9999..)
                {
                    return $"{res[0]}.({NumberTranslator.LongToChar(Q - 1)})";
                }
                return $"{res[0]}.{res[1]}";
            }
            return $"{res[0]}";
        }


        #region Number_Base_P_Checks

        bool Number_Base_P_Checks(bool P_Fail)
        {
            // Введено ли что либо в поле текста?
            bool num_Fail = Number_Base_P_IsEmpty_Check();

            // В исходном числе должен быть максимум 1 знак '-'
            if (!num_Fail)
            {
                num_Fail = Number_Base_P_NegativeSignCount_Check();
            }

            // В исходном числе знак '-' может стоять только на первой позиции
            if (!num_Fail)
            {
                num_Fail = Number_Base_P_MinusSignIsNotFirst_Check();
            }

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

            // В исходном числе допустимы только символы: '-', 0..9, a..z, A..Z, '.', ','
            if (!num_Fail)
            {
                num_Fail = Number_Base_P_SymbolValidity_Check();
            }

            // Все цифры числа исходного числа должны быть допустимыми в выбранной системе счисления
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
                return true;
            }

            return false;
        }

        bool Number_Base_P_NegativeSignCount_Check()
        {
            if (Number_Base_P.Text.IndexOf("-") != Number_Base_P.Text.LastIndexOf("-"))
            {
                Data_Label.Text += "В исходном числе присутствует более чем один символ '-'. \n";
                Number_Base_P_Error.Visible = true;
                return true;
            }

            return false;
        }

        bool Number_Base_P_MinusSignIsNotFirst_Check()
        {
            if (Number_Base_P.Text.IndexOf("-") != -1 && Number_Base_P.Text.IndexOf("-") != 0)
            {
                Data_Label.Text += "В исходном числе символ '-' стоит не на первой позиции. \n";
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
                    return true;
                }
            }

            return false;
        }

        bool Number_Base_P_SomeNumberDoNotExist_Check()
        {
            foreach (char c in Number_Base_P.Text)
            {
                if (NumberTranslator.CharToLong(c) >= int.Parse(Base_P.Text))
                {
                    Data_Label.Text += $"В исходном числе присутствует цифра \"{c}\" недопустимая в системе счисления {Base_P.Text}. \n";
                    Number_Base_P_Error.Visible = true;
                    return true;
                }
            }

            return false;
        }

        #endregion


        #region P_Base_Checks

        bool P_Base_Checks()
        {
            // Введено ли что либо в поле текста?
            bool P_Fail = P_Base_IsEmpty_Check();

            // Основания и количество знаков после запятой должны приводиться к целому типу
            if (!P_Fail)
            {
                P_Fail = P_base_IsNotConvertableToInt_Check();
            }

            // Основания должны быть в промежутке от 2 до 36 включительно
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


        #region Q_Base_Checks

        bool Q_Base_Checks()
        {
            // Введено ли что либо в поле текста?
            bool Q_Fail = Q_Base_IsEmpty_Check();

            // Основания и количество знаков после запятой должны приводиться к целому типу
            if (!Q_Fail)
            {
                Q_Fail = Q_base_Interval_Check();
            }

            // Основания должны быть в промежутке от 2 до 36 включительно
            if (!Q_Fail)
            {
                Q_Fail = Q_base_IsNotConvertableToInt_Check();
            }
            
            return Q_Fail;
        }

        bool Q_Base_IsEmpty_Check()
        {
            if (Base_Q.Text == "")
            {
                Data_Label.Text += "Введите основание результата. \n";
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


        #region Accuracy_Checks

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