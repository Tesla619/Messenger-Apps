namespace Messenger_v2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Port_TextBox = new System.Windows.Forms.TextBox();
            this.IP_TextBox = new System.Windows.Forms.TextBox();
            this.Sending_TextBox = new System.Windows.Forms.RichTextBox();
            this.Connect_Button = new System.Windows.Forms.Button();
            this.Port_Label = new System.Windows.Forms.Label();
            this.IP_Label = new System.Windows.Forms.Label();
            this.Send_Button = new System.Windows.Forms.Button();
            this.Main_TextBox = new System.Windows.Forms.RichTextBox();
            this.Server_Button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ID_Label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Port_TextBox
            // 
            this.Port_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Port_TextBox.Location = new System.Drawing.Point(441, 65);
            this.Port_TextBox.Name = "Port_TextBox";
            this.Port_TextBox.Size = new System.Drawing.Size(46, 20);
            this.Port_TextBox.TabIndex = 19;
            // 
            // IP_TextBox
            // 
            this.IP_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IP_TextBox.Location = new System.Drawing.Point(441, 39);
            this.IP_TextBox.Name = "IP_TextBox";
            this.IP_TextBox.Size = new System.Drawing.Size(91, 20);
            this.IP_TextBox.TabIndex = 18;
            // 
            // Sending_TextBox
            // 
            this.Sending_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Sending_TextBox.Location = new System.Drawing.Point(8, 152);
            this.Sending_TextBox.Name = "Sending_TextBox";
            this.Sending_TextBox.Size = new System.Drawing.Size(373, 33);
            this.Sending_TextBox.TabIndex = 17;
            this.Sending_TextBox.Text = "";
            // 
            // Connect_Button
            // 
            this.Connect_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Connect_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Connect_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connect_Button.ForeColor = System.Drawing.Color.White;
            this.Connect_Button.Location = new System.Drawing.Point(387, 95);
            this.Connect_Button.Name = "Connect_Button";
            this.Connect_Button.Size = new System.Drawing.Size(91, 40);
            this.Connect_Button.TabIndex = 16;
            this.Connect_Button.Text = "Connect";
            this.Connect_Button.UseVisualStyleBackColor = true;
            this.Connect_Button.Click += new System.EventHandler(this.Connect_Button_Click);
            // 
            // Port_Label
            // 
            this.Port_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Port_Label.AutoSize = true;
            this.Port_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Port_Label.ForeColor = System.Drawing.Color.White;
            this.Port_Label.Location = new System.Drawing.Point(397, 65);
            this.Port_Label.Name = "Port_Label";
            this.Port_Label.Size = new System.Drawing.Size(38, 20);
            this.Port_Label.TabIndex = 15;
            this.Port_Label.Text = "Port";
            // 
            // IP_Label
            // 
            this.IP_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IP_Label.AutoSize = true;
            this.IP_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP_Label.ForeColor = System.Drawing.Color.White;
            this.IP_Label.Location = new System.Drawing.Point(411, 39);
            this.IP_Label.Name = "IP_Label";
            this.IP_Label.Size = new System.Drawing.Size(24, 20);
            this.IP_Label.TabIndex = 14;
            this.IP_Label.Text = "IP";
            // 
            // Send_Button
            // 
            this.Send_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Send_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Send_Button.FlatAppearance.BorderSize = 0;
            this.Send_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Send_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_Button.ForeColor = System.Drawing.SystemColors.Window;
            this.Send_Button.Location = new System.Drawing.Point(413, 152);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(106, 33);
            this.Send_Button.TabIndex = 13;
            this.Send_Button.Text = "Send";
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // Main_TextBox
            // 
            this.Main_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Main_TextBox.Location = new System.Drawing.Point(8, 12);
            this.Main_TextBox.Name = "Main_TextBox";
            this.Main_TextBox.Size = new System.Drawing.Size(373, 123);
            this.Main_TextBox.TabIndex = 11;
            this.Main_TextBox.Text = "";
            // 
            // Server_Button
            // 
            this.Server_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Server_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Server_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Server_Button.ForeColor = System.Drawing.Color.White;
            this.Server_Button.Location = new System.Drawing.Point(484, 95);
            this.Server_Button.Name = "Server_Button";
            this.Server_Button.Size = new System.Drawing.Size(53, 40);
            this.Server_Button.TabIndex = 20;
            this.Server_Button.Text = "Start";
            this.Server_Button.UseVisualStyleBackColor = true;
            this.Server_Button.Click += new System.EventHandler(this.Server_Button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(441, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(91, 20);
            this.textBox1.TabIndex = 22;
            // 
            // ID_Label
            // 
            this.ID_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ID_Label.AutoSize = true;
            this.ID_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_Label.ForeColor = System.Drawing.Color.White;
            this.ID_Label.Location = new System.Drawing.Point(409, 13);
            this.ID_Label.Name = "ID_Label";
            this.ID_Label.Size = new System.Drawing.Size(26, 20);
            this.ID_Label.TabIndex = 21;
            this.ID_Label.Text = "ID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(387, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "R";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(540, 197);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ID_Label);
            this.Controls.Add(this.Server_Button);
            this.Controls.Add(this.Port_TextBox);
            this.Controls.Add(this.IP_TextBox);
            this.Controls.Add(this.Sending_TextBox);
            this.Controls.Add(this.Connect_Button);
            this.Controls.Add(this.Port_Label);
            this.Controls.Add(this.IP_Label);
            this.Controls.Add(this.Send_Button);
            this.Controls.Add(this.Main_TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Messenger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Port_TextBox;
        private System.Windows.Forms.TextBox IP_TextBox;
        private System.Windows.Forms.RichTextBox Sending_TextBox;
        private System.Windows.Forms.Button Connect_Button;
        private System.Windows.Forms.Label Port_Label;
        private System.Windows.Forms.Label IP_Label;
        private System.Windows.Forms.Button Send_Button;
        private System.Windows.Forms.RichTextBox Main_TextBox;
        private System.Windows.Forms.Button Server_Button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label ID_Label;
        private System.Windows.Forms.Button button1;
    }
}

