
namespace main_screen
{
    partial class Manual
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bt_Stop = new System.Windows.Forms.Button();
            this.bt_U_Robot = new System.Windows.Forms.Button();
            this.bt_REV = new System.Windows.Forms.Button();
            this.bt_FWD_Conv1 = new System.Windows.Forms.Button();
            this.bt_FWD_Conv2 = new System.Windows.Forms.Button();
            this.bt_FWD_Conv3 = new System.Windows.Forms.Button();
            this.bt_FWD_Conv4 = new System.Windows.Forms.Button();
            this.bt_REV_Conv1 = new System.Windows.Forms.Button();
            this.bt_REV_Conv2 = new System.Windows.Forms.Button();
            this.bt_REV_Conv3 = new System.Windows.Forms.Button();
            this.bt_REV_Conv4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_speed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_Home = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Stop
            // 
            this.bt_Stop.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Stop.Location = new System.Drawing.Point(450, 56);
            this.bt_Stop.Name = "bt_Stop";
            this.bt_Stop.Size = new System.Drawing.Size(87, 262);
            this.bt_Stop.TabIndex = 3;
            this.bt_Stop.Text = "DỪNG";
            this.bt_Stop.UseVisualStyleBackColor = true;
            this.bt_Stop.Click += new System.EventHandler(this.button2_Click);
            // 
            // bt_U_Robot
            // 
            this.bt_U_Robot.Location = new System.Drawing.Point(343, 56);
            this.bt_U_Robot.Name = "bt_U_Robot";
            this.bt_U_Robot.Size = new System.Drawing.Size(101, 79);
            this.bt_U_Robot.TabIndex = 4;
            this.bt_U_Robot.Text = "ĐI TIẾN";
            this.bt_U_Robot.UseVisualStyleBackColor = true;
            this.bt_U_Robot.Click += new System.EventHandler(this.bt_FWD_Robot_Click);
            // 
            // bt_REV
            // 
            this.bt_REV.Location = new System.Drawing.Point(343, 239);
            this.bt_REV.Name = "bt_REV";
            this.bt_REV.Size = new System.Drawing.Size(101, 79);
            this.bt_REV.TabIndex = 5;
            this.bt_REV.Text = "ĐI LÙI";
            this.bt_REV.UseVisualStyleBackColor = true;
            this.bt_REV.Click += new System.EventHandler(this.button3_Click);
            // 
            // bt_FWD_Conv1
            // 
            this.bt_FWD_Conv1.Location = new System.Drawing.Point(565, 56);
            this.bt_FWD_Conv1.Name = "bt_FWD_Conv1";
            this.bt_FWD_Conv1.Size = new System.Drawing.Size(160, 61);
            this.bt_FWD_Conv1.TabIndex = 7;
            this.bt_FWD_Conv1.Text = "BĂNG TẢI 1 FWD";
            this.bt_FWD_Conv1.UseVisualStyleBackColor = true;
            this.bt_FWD_Conv1.Click += new System.EventHandler(this.button4_Click);
            // 
            // bt_FWD_Conv2
            // 
            this.bt_FWD_Conv2.Location = new System.Drawing.Point(565, 123);
            this.bt_FWD_Conv2.Name = "bt_FWD_Conv2";
            this.bt_FWD_Conv2.Size = new System.Drawing.Size(160, 61);
            this.bt_FWD_Conv2.TabIndex = 9;
            this.bt_FWD_Conv2.Text = "BĂNG TẢI 2 FWD";
            this.bt_FWD_Conv2.UseVisualStyleBackColor = true;
            this.bt_FWD_Conv2.Click += new System.EventHandler(this.button6_Click);
            // 
            // bt_FWD_Conv3
            // 
            this.bt_FWD_Conv3.Location = new System.Drawing.Point(565, 190);
            this.bt_FWD_Conv3.Name = "bt_FWD_Conv3";
            this.bt_FWD_Conv3.Size = new System.Drawing.Size(160, 61);
            this.bt_FWD_Conv3.TabIndex = 10;
            this.bt_FWD_Conv3.Text = "BĂNG TẢI 3 FWD";
            this.bt_FWD_Conv3.UseVisualStyleBackColor = true;
            this.bt_FWD_Conv3.Click += new System.EventHandler(this.button7_Click);
            // 
            // bt_FWD_Conv4
            // 
            this.bt_FWD_Conv4.Location = new System.Drawing.Point(565, 257);
            this.bt_FWD_Conv4.Name = "bt_FWD_Conv4";
            this.bt_FWD_Conv4.Size = new System.Drawing.Size(160, 61);
            this.bt_FWD_Conv4.TabIndex = 11;
            this.bt_FWD_Conv4.Text = "BĂNG TẢI 4 FWD";
            this.bt_FWD_Conv4.UseVisualStyleBackColor = true;
            this.bt_FWD_Conv4.Click += new System.EventHandler(this.button8_Click);
            // 
            // bt_REV_Conv1
            // 
            this.bt_REV_Conv1.Location = new System.Drawing.Point(731, 56);
            this.bt_REV_Conv1.Name = "bt_REV_Conv1";
            this.bt_REV_Conv1.Size = new System.Drawing.Size(160, 61);
            this.bt_REV_Conv1.TabIndex = 12;
            this.bt_REV_Conv1.Text = "BĂNG TẢI 1 REV";
            this.bt_REV_Conv1.UseVisualStyleBackColor = true;
            this.bt_REV_Conv1.Click += new System.EventHandler(this.button5_Click);
            // 
            // bt_REV_Conv2
            // 
            this.bt_REV_Conv2.Location = new System.Drawing.Point(731, 123);
            this.bt_REV_Conv2.Name = "bt_REV_Conv2";
            this.bt_REV_Conv2.Size = new System.Drawing.Size(160, 61);
            this.bt_REV_Conv2.TabIndex = 13;
            this.bt_REV_Conv2.Text = "BĂNG TẢI 2 REV";
            this.bt_REV_Conv2.UseVisualStyleBackColor = true;
            this.bt_REV_Conv2.Click += new System.EventHandler(this.button9_Click);
            // 
            // bt_REV_Conv3
            // 
            this.bt_REV_Conv3.Location = new System.Drawing.Point(731, 190);
            this.bt_REV_Conv3.Name = "bt_REV_Conv3";
            this.bt_REV_Conv3.Size = new System.Drawing.Size(160, 61);
            this.bt_REV_Conv3.TabIndex = 14;
            this.bt_REV_Conv3.Text = "BĂNG TẢI 3 REV";
            this.bt_REV_Conv3.UseVisualStyleBackColor = true;
            this.bt_REV_Conv3.Click += new System.EventHandler(this.button10_Click);
            // 
            // bt_REV_Conv4
            // 
            this.bt_REV_Conv4.Location = new System.Drawing.Point(731, 257);
            this.bt_REV_Conv4.Name = "bt_REV_Conv4";
            this.bt_REV_Conv4.Size = new System.Drawing.Size(160, 61);
            this.bt_REV_Conv4.TabIndex = 15;
            this.bt_REV_Conv4.Text = "BĂNG TẢI 4 REV";
            this.bt_REV_Conv4.UseVisualStyleBackColor = true;
            this.bt_REV_Conv4.Click += new System.EventHandler(this.button11_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(388, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "DI CHUYỂN";
            // 
            // textbox_speed
            // 
            this.textbox_speed.BackColor = System.Drawing.Color.White;
            this.textbox_speed.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_speed.Location = new System.Drawing.Point(358, 351);
            this.textbox_speed.Name = "textbox_speed";
            this.textbox_speed.Size = new System.Drawing.Size(159, 32);
            this.textbox_speed.TabIndex = 17;
            this.textbox_speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_speed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.box_speed_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(393, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 22);
            this.label2.TabIndex = 18;
            this.label2.Text = "TỐC ĐỘ";
            // 
            // bt_Home
            // 
            this.bt_Home.Location = new System.Drawing.Point(343, 148);
            this.bt_Home.Name = "bt_Home";
            this.bt_Home.Size = new System.Drawing.Size(101, 79);
            this.bt_Home.TabIndex = 19;
            this.bt_Home.Text = "HOME";
            this.bt_Home.UseVisualStyleBackColor = true;
            this.bt_Home.Click += new System.EventHandler(this.button12_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(682, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 22);
            this.label3.TabIndex = 20;
            this.label3.Text = "BĂNG TẢI";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pictureBox1.Location = new System.Drawing.Point(327, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(3, 389);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::main_screen.Properties.Resources.Capture1212;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(321, 389);
            this.pictureBox4.TabIndex = 39;
            this.pictureBox4.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bt_Home);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textbox_speed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_REV_Conv4);
            this.Controls.Add(this.bt_REV_Conv3);
            this.Controls.Add(this.bt_REV_Conv2);
            this.Controls.Add(this.bt_REV_Conv1);
            this.Controls.Add(this.bt_FWD_Conv4);
            this.Controls.Add(this.bt_FWD_Conv3);
            this.Controls.Add(this.bt_FWD_Conv2);
            this.Controls.Add(this.bt_FWD_Conv1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bt_REV);
            this.Controls.Add(this.bt_U_Robot);
            this.Controls.Add(this.bt_Stop);
            this.Name = "Manual";
            this.Size = new System.Drawing.Size(909, 389);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_Stop;
        private System.Windows.Forms.Button bt_U_Robot;
        private System.Windows.Forms.Button bt_REV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bt_FWD_Conv1;
        private System.Windows.Forms.Button bt_FWD_Conv2;
        private System.Windows.Forms.Button bt_FWD_Conv3;
        private System.Windows.Forms.Button bt_FWD_Conv4;
        private System.Windows.Forms.Button bt_REV_Conv1;
        private System.Windows.Forms.Button bt_REV_Conv2;
        private System.Windows.Forms.Button bt_REV_Conv3;
        private System.Windows.Forms.Button bt_REV_Conv4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_speed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_Home;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Timer timer2;
    }
}
