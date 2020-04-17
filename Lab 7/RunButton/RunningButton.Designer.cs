namespace RunButton
{
    partial class RunningButton
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
            this.pushButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pushButton
            // 
            this.pushButton.Location = new System.Drawing.Point(575, 350);
            this.pushButton.MaximumSize = new System.Drawing.Size(185, 69);
            this.pushButton.MinimumSize = new System.Drawing.Size(185, 69);
            this.pushButton.Name = "pushButton";
            this.pushButton.Size = new System.Drawing.Size(185, 69);
            this.pushButton.TabIndex = 0;
            this.pushButton.Text = "Push me";
            this.pushButton.UseVisualStyleBackColor = true;
            this.pushButton.Click += new System.EventHandler(this.pushButton_Click);
            // 
            // RunningButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 839);
            this.Controls.Add(this.pushButton);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "RunningButton";
            this.ShowIcon = false;
            this.Text = "Running Button";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.MouseLeave += new System.EventHandler(this.RunningButton_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pushButton;
    }
}

