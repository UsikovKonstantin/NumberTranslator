
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Data_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Number_Base_P
            // 
            this.Number_Base_P.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Number_Base_P.Location = new System.Drawing.Point(12, 12);
            this.Number_Base_P.Name = "Number_Base_P";
            this.Number_Base_P.Size = new System.Drawing.Size(100, 32);
            this.Number_Base_P.TabIndex = 0;
            this.Number_Base_P.TextChanged += new System.EventHandler(this.Number_Base_P_TextChanged);
            // 
            // Number_Base_Q
            // 
            this.Number_Base_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Number_Base_Q.Location = new System.Drawing.Point(12, 50);
            this.Number_Base_Q.Name = "Number_Base_Q";
            this.Number_Base_Q.ReadOnly = true;
            this.Number_Base_Q.Size = new System.Drawing.Size(100, 32);
            this.Number_Base_Q.TabIndex = 1;
            // 
            // Base_P
            // 
            this.Base_P.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Base_P.Location = new System.Drawing.Point(383, 12);
            this.Base_P.Name = "Base_P";
            this.Base_P.Size = new System.Drawing.Size(30, 32);
            this.Base_P.TabIndex = 2;
            this.Base_P.TextChanged += new System.EventHandler(this.Base_P_TextChanged);
            // 
            // Base_Q
            // 
            this.Base_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Base_Q.Location = new System.Drawing.Point(383, 50);
            this.Base_Q.Name = "Base_Q";
            this.Base_Q.Size = new System.Drawing.Size(30, 32);
            this.Base_Q.TabIndex = 3;
            this.Base_Q.TextChanged += new System.EventHandler(this.Base_Q_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(118, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Число Основание числа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(118, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Число Основание числа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(419, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Переводим из";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(419, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Переводим в";
            // 
            // Data_Label
            // 
            this.Data_Label.AutoSize = true;
            this.Data_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Data_Label.Location = new System.Drawing.Point(12, 105);
            this.Data_Label.Name = "Data_Label";
            this.Data_Label.Size = new System.Drawing.Size(164, 26);
            this.Data_Label.TabIndex = 8;
            this.Data_Label.Text = "Введите число";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 399);
            this.Controls.Add(this.Data_Label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Base_Q);
            this.Controls.Add(this.Base_P);
            this.Controls.Add(this.Number_Base_Q);
            this.Controls.Add(this.Number_Base_P);
            this.Name = "MainForm";
            this.Text = "Number translator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Number_Base_P;
        private System.Windows.Forms.TextBox Number_Base_Q;
        private System.Windows.Forms.TextBox Base_P;
        private System.Windows.Forms.TextBox Base_Q;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Data_Label;
    }
}

