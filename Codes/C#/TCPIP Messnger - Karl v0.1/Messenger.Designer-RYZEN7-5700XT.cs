namespace TCPIP_Messnger___Karl_v0._1
{
    partial class MessengerForm
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
            this.Main_TextBox = new System.Windows.Forms.RichTextBox();
            this.Title_Label = new System.Windows.Forms.Label();
            this.Send_Button = new System.Windows.Forms.Button();
            this.IP_Label = new System.Windows.Forms.Label();
            this.Port_Label = new System.Windows.Forms.Label();
            this.Connect_Button = new System.Windows.Forms.Button();
            this.Sending_TextBox = new System.Windows.Forms.RichTextBox();
            this.IP_TextBox = new System.Windows.Forms.TextBox();
            this.Port_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Main_TextBox
            // 
            this.Main_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Main_TextBox.Location = new System.Drawing.Point(12, 85);
            this.Main_TextBox.Name = "Main_TextBox";
            this.Main_TextBox.Size = new System.Drawing.Size(373, 217);
            this.Main_TextBox.TabIndex = 0;
            this.Main_TextBox.Text = "";
            // 
            // Title_Label
            // 
            this.Title_Label.AutoSize = true;
            this.Title_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_Label.ForeColor = System.Drawing.Color.White;
            this.Title_Label.Location = new System.Drawing.Point(12, 9);
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.Size = new System.Drawing.Size(525, 73);
            this.Title_Label.TabIndex = 1;
            this.Title_Label.Text = "Karl\'s Messenger";
            // 
            // Send_Button
            // 
            this.Send_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Send_Button.BackgroundImage = global::TCPIP_Messnger___Karl_v0._1.Properties.Resources.http___pluspng_com_img_png_paper_airplane_png_hd_paper_plane_black_600;
            this.Send_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Send_Button.FlatAppearance.BorderSize = 0;
            this.Send_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Send_Button.Location = new System.Drawing.Point(424, 300);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(104, 77);
            this.Send_Button.TabIndex = 2;
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // IP_Label
            // 
            this.IP_Label.AutoSize = true;
            this.IP_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP_Label.ForeColor = System.Drawing.Color.White;
            this.IP_Label.Location = new System.Drawing.Point(409, 105);
            this.IP_Label.Name = "IP_Label";
            this.IP_Label.Size = new System.Drawing.Size(24, 20);
            this.IP_Label.TabIndex = 5;
            this.IP_Label.Text = "IP";
            // 
            // Port_Label
            // 
            this.Port_Label.AutoSize = true;
            this.Port_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Port_Label.ForeColor = System.Drawing.Color.White;
            this.Port_Label.Location = new System.Drawing.Point(395, 129);
            this.Port_Label.Name = "Port_Label";
            this.Port_Label.Size = new System.Drawing.Size(38, 20);
            this.Port_Label.TabIndex = 6;
            this.Port_Label.Text = "Port";
            // 
            // Connect_Button
            // 
            this.Connect_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Connect_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connect_Button.ForeColor = System.Drawing.Color.White;
            this.Connect_Button.Location = new System.Drawing.Point(413, 168);
            this.Connect_Button.Name = "Connect_Button";
            this.Connect_Button.Size = new System.Drawing.Size(106, 45);
            this.Connect_Button.TabIndex = 7;
            this.Connect_Button.Text = "Connect";
            this.Connect_Button.UseVisualStyleBackColor = true;
            this.Connect_Button.Click += new System.EventHandler(this.Connect_Button_Click);
            // 
            // Sending_TextBox
            // 
            this.Sending_TextBox.Location = new System.Drawing.Point(12, 324);
            this.Sending_TextBox.Name = "Sending_TextBox";
            this.Sending_TextBox.Size = new System.Drawing.Size(373, 53);
            this.Sending_TextBox.TabIndex = 8;
            this.Sending_TextBox.Text = "";
            // 
            // IP_TextBox
            // 
            this.IP_TextBox.Location = new System.Drawing.Point(437, 105);
            this.IP_TextBox.Name = "IP_TextBox";
            this.IP_TextBox.Size = new System.Drawing.Size(91, 20);
            this.IP_TextBox.TabIndex = 9;
            // 
            // Port_TextBox
            // 
            this.Port_TextBox.Location = new System.Drawing.Point(437, 131);
            this.Port_TextBox.Name = "Port_TextBox";
            this.Port_TextBox.Size = new System.Drawing.Size(46, 20);
            this.Port_TextBox.TabIndex = 10;
            // 
            // MessengerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(540, 389);
            this.Controls.Add(this.Port_TextBox);
            this.Controls.Add(this.IP_TextBox);
            this.Controls.Add(this.Sending_TextBox);
            this.Controls.Add(this.Connect_Button);
            this.Controls.Add(this.Port_Label);
            this.Controls.Add(this.IP_Label);
            this.Controls.Add(this.Send_Button);
            this.Controls.Add(this.Title_Label);
            this.Controls.Add(this.Main_TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MessengerForm";
            this.Text = "Messenger v.01";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessengerForm_FormClosing);
            this.Load += new System.EventHandler(this.MessengerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Main_TextBox;
        private System.Windows.Forms.Label Title_Label;
        private System.Windows.Forms.Button Send_Button;
        private System.Windows.Forms.Label IP_Label;
        private System.Windows.Forms.Label Port_Label;
        private System.Windows.Forms.Button Connect_Button;
        private System.Windows.Forms.RichTextBox Sending_TextBox;
        private System.Windows.Forms.TextBox IP_TextBox;
        private System.Windows.Forms.TextBox Port_TextBox;
    }
}

