
namespace WindowsFormsNumberTranslator
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Number_Base_P = new System.Windows.Forms.TextBox();
            this.Number_Base_Q = new System.Windows.Forms.TextBox();
            this.Base_P = new System.Windows.Forms.TextBox();
            this.Base_Q = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Data_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Accuracy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Base_P_Error = new System.Windows.Forms.PictureBox();
            this.Accuracy_Error = new System.Windows.Forms.PictureBox();
            this.Number_Base_P_Error = new System.Windows.Forms.PictureBox();
            this.Base_Q_Error = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Base_P_Error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Accuracy_Error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Base_P_Error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Base_Q_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // Number_Base_P
            // 
            this.Number_Base_P.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Number_Base_P.Location = new System.Drawing.Point(24, 137);
            this.Number_Base_P.MaxLength = 58;
            this.Number_Base_P.Name = "Number_Base_P";
            this.Number_Base_P.Size = new System.Drawing.Size(706, 32);
            this.Number_Base_P.TabIndex = 0;
            this.Number_Base_P.TextChanged += new System.EventHandler(this.Number_Base_P_TextChanged);
            // 
            // Number_Base_Q
            // 
            this.Number_Base_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Number_Base_Q.Location = new System.Drawing.Point(24, 213);
            this.Number_Base_Q.Name = "Number_Base_Q";
            this.Number_Base_Q.ReadOnly = true;
            this.Number_Base_Q.Size = new System.Drawing.Size(706, 32);
            this.Number_Base_Q.TabIndex = 1;
            // 
            // Base_P
            // 
            this.Base_P.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Base_P.Location = new System.Drawing.Point(24, 61);
            this.Base_P.MaxLength = 2;
            this.Base_P.Name = "Base_P";
            this.Base_P.Size = new System.Drawing.Size(31, 32);
            this.Base_P.TabIndex = 2;
            this.Base_P.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Base_P.TextChanged += new System.EventHandler(this.Base_P_TextChanged);
            // 
            // Base_Q
            // 
            this.Base_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Base_Q.Location = new System.Drawing.Point(24, 99);
            this.Base_Q.MaxLength = 2;
            this.Base_Q.Name = "Base_Q";
            this.Base_Q.Size = new System.Drawing.Size(31, 32);
            this.Base_Q.TabIndex = 3;
            this.Base_Q.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Base_Q.TextChanged += new System.EventHandler(this.Base_Q_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(60, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Исходное основание";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(60, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Основание результата";
            // 
            // Data_Label
            // 
            this.Data_Label.AutoSize = true;
            this.Data_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Data_Label.Location = new System.Drawing.Point(24, 256);
            this.Data_Label.Name = "Data_Label";
            this.Data_Label.Size = new System.Drawing.Size(456, 104);
            this.Data_Label.TabIndex = 8;
            this.Data_Label.Text = "Введите исходное число.\r\nВведите исходное основание.\r\nВведите основание результат" +
    "а.\r\nВведите количество знаков после запятой.\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(60, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Знаков после запятой";
            // 
            // Accuracy
            // 
            this.Accuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Accuracy.Location = new System.Drawing.Point(24, 175);
            this.Accuracy.MaxLength = 2;
            this.Accuracy.Name = "Accuracy";
            this.Accuracy.Size = new System.Drawing.Size(31, 32);
            this.Accuracy.TabIndex = 9;
            this.Accuracy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Accuracy.TextChanged += new System.EventHandler(this.Accuracy_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(888, 39);
            this.label2.TabIndex = 11;
            this.label2.Text = "Перевод вещественных чисел из одной системы счисления в другую";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label5.Location = new System.Drawing.Point(736, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 26);
            this.label5.TabIndex = 12;
            this.label5.Text = "Исходное число";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label6.Location = new System.Drawing.Point(736, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "Результат";
            // 
            // Base_P_Error
            // 
            this.Base_P_Error.Image = global::WindowsFormsNumberTranslator.Properties.Resources.ErrorCircle;
            this.Base_P_Error.Location = new System.Drawing.Point(8, 71);
            this.Base_P_Error.Name = "Base_P_Error";
            this.Base_P_Error.Size = new System.Drawing.Size(10, 10);
            this.Base_P_Error.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Base_P_Error.TabIndex = 18;
            this.Base_P_Error.TabStop = false;
            this.Base_P_Error.Visible = false;
            // 
            // Accuracy_Error
            // 
            this.Accuracy_Error.Image = global::WindowsFormsNumberTranslator.Properties.Resources.ErrorCircle;
            this.Accuracy_Error.Location = new System.Drawing.Point(8, 185);
            this.Accuracy_Error.Name = "Accuracy_Error";
            this.Accuracy_Error.Size = new System.Drawing.Size(10, 10);
            this.Accuracy_Error.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Accuracy_Error.TabIndex = 17;
            this.Accuracy_Error.TabStop = false;
            this.Accuracy_Error.Visible = false;
            // 
            // Number_Base_P_Error
            // 
            this.Number_Base_P_Error.Image = global::WindowsFormsNumberTranslator.Properties.Resources.ErrorCircle;
            this.Number_Base_P_Error.Location = new System.Drawing.Point(8, 147);
            this.Number_Base_P_Error.Name = "Number_Base_P_Error";
            this.Number_Base_P_Error.Size = new System.Drawing.Size(10, 10);
            this.Number_Base_P_Error.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Number_Base_P_Error.TabIndex = 16;
            this.Number_Base_P_Error.TabStop = false;
            this.Number_Base_P_Error.Visible = false;
            // 
            // Base_Q_Error
            // 
            this.Base_Q_Error.Image = global::WindowsFormsNumberTranslator.Properties.Resources.ErrorCircle;
            this.Base_Q_Error.Location = new System.Drawing.Point(8, 109);
            this.Base_Q_Error.Name = "Base_Q_Error";
            this.Base_Q_Error.Size = new System.Drawing.Size(10, 10);
            this.Base_Q_Error.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Base_Q_Error.TabIndex = 15;
            this.Base_Q_Error.TabStop = false;
            this.Base_Q_Error.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 399);
            this.Controls.Add(this.Base_P_Error);
            this.Controls.Add(this.Accuracy_Error);
            this.Controls.Add(this.Number_Base_P_Error);
            this.Controls.Add(this.Base_Q_Error);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Accuracy);
            this.Controls.Add(this.Data_Label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Base_Q);
            this.Controls.Add(this.Base_P);
            this.Controls.Add(this.Number_Base_Q);
            this.Controls.Add(this.Number_Base_P);
            this.Name = "MainForm";
            this.Text = "Number translator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Base_P_Error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Accuracy_Error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Base_P_Error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Base_Q_Error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Number_Base_P;
        private System.Windows.Forms.TextBox Number_Base_Q;
        private System.Windows.Forms.TextBox Base_P;
        private System.Windows.Forms.TextBox Base_Q;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Data_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Accuracy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox Base_Q_Error;
        private System.Windows.Forms.PictureBox Number_Base_P_Error;
        private System.Windows.Forms.PictureBox Accuracy_Error;
        private System.Windows.Forms.PictureBox Base_P_Error;
    }
}

