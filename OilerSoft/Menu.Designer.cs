namespace OilerSoft
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.buttonClient = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonCarRegistration = new System.Windows.Forms.Button();
            this.buttonSpare = new System.Windows.Forms.Button();
            this.buttonOrderSpare = new System.Windows.Forms.Button();
            this.buttonServices = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClient
            // 
            this.buttonClient.BackColor = System.Drawing.Color.Tomato;
            this.buttonClient.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.buttonClient.FlatAppearance.BorderSize = 0;
            this.buttonClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClient.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonClient.Location = new System.Drawing.Point(12, 131);
            this.buttonClient.Margin = new System.Windows.Forms.Padding(15);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Padding = new System.Windows.Forms.Padding(10);
            this.buttonClient.Size = new System.Drawing.Size(232, 48);
            this.buttonClient.TabIndex = 1;
            this.buttonClient.Text = "Клиенты";
            this.buttonClient.UseVisualStyleBackColor = false;
            this.buttonClient.Click += new System.EventHandler(this.buttonClient_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OilerSoft.Properties.Resources.imgonline_com_ua_Transparent_backgr_rITe6ZcDdlYY1Of_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(33, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonCarRegistration
            // 
            this.buttonCarRegistration.BackColor = System.Drawing.Color.Tomato;
            this.buttonCarRegistration.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.buttonCarRegistration.FlatAppearance.BorderSize = 0;
            this.buttonCarRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCarRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCarRegistration.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonCarRegistration.Location = new System.Drawing.Point(12, 193);
            this.buttonCarRegistration.Margin = new System.Windows.Forms.Padding(15);
            this.buttonCarRegistration.Name = "buttonCarRegistration";
            this.buttonCarRegistration.Padding = new System.Windows.Forms.Padding(10);
            this.buttonCarRegistration.Size = new System.Drawing.Size(232, 48);
            this.buttonCarRegistration.TabIndex = 1;
            this.buttonCarRegistration.Text = "Регистрация автомобиля";
            this.buttonCarRegistration.UseVisualStyleBackColor = false;
            this.buttonCarRegistration.Click += new System.EventHandler(this.buttonCarRegistration_Click);
            // 
            // buttonSpare
            // 
            this.buttonSpare.BackColor = System.Drawing.Color.Tomato;
            this.buttonSpare.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.buttonSpare.FlatAppearance.BorderSize = 0;
            this.buttonSpare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSpare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSpare.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSpare.Location = new System.Drawing.Point(12, 255);
            this.buttonSpare.Margin = new System.Windows.Forms.Padding(15);
            this.buttonSpare.Name = "buttonSpare";
            this.buttonSpare.Padding = new System.Windows.Forms.Padding(10);
            this.buttonSpare.Size = new System.Drawing.Size(232, 48);
            this.buttonSpare.TabIndex = 1;
            this.buttonSpare.Text = "Запчасти";
            this.buttonSpare.UseVisualStyleBackColor = false;
            this.buttonSpare.Click += new System.EventHandler(this.buttonSpare_Click);
            // 
            // buttonOrderSpare
            // 
            this.buttonOrderSpare.BackColor = System.Drawing.Color.Tomato;
            this.buttonOrderSpare.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.buttonOrderSpare.FlatAppearance.BorderSize = 0;
            this.buttonOrderSpare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOrderSpare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOrderSpare.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonOrderSpare.Location = new System.Drawing.Point(12, 319);
            this.buttonOrderSpare.Margin = new System.Windows.Forms.Padding(15);
            this.buttonOrderSpare.Name = "buttonOrderSpare";
            this.buttonOrderSpare.Padding = new System.Windows.Forms.Padding(10);
            this.buttonOrderSpare.Size = new System.Drawing.Size(232, 48);
            this.buttonOrderSpare.TabIndex = 1;
            this.buttonOrderSpare.Text = "Заказ запчастей";
            this.buttonOrderSpare.UseVisualStyleBackColor = false;
            // 
            // buttonServices
            // 
            this.buttonServices.BackColor = System.Drawing.Color.Tomato;
            this.buttonServices.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.buttonServices.FlatAppearance.BorderSize = 0;
            this.buttonServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonServices.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonServices.Location = new System.Drawing.Point(12, 382);
            this.buttonServices.Margin = new System.Windows.Forms.Padding(15);
            this.buttonServices.Name = "buttonServices";
            this.buttonServices.Padding = new System.Windows.Forms.Padding(10);
            this.buttonServices.Size = new System.Drawing.Size(232, 48);
            this.buttonServices.TabIndex = 1;
            this.buttonServices.Text = "Оказанные услуги";
            this.buttonServices.UseVisualStyleBackColor = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(258, 450);
            this.Controls.Add(this.buttonServices);
            this.Controls.Add(this.buttonOrderSpare);
            this.Controls.Add(this.buttonSpare);
            this.Controls.Add(this.buttonCarRegistration);
            this.Controls.Add(this.buttonClient);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.Menu;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Oiler";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonClient;
        private System.Windows.Forms.Button buttonCarRegistration;
        private System.Windows.Forms.Button buttonSpare;
        private System.Windows.Forms.Button buttonOrderSpare;
        private System.Windows.Forms.Button buttonServices;
    }
}

