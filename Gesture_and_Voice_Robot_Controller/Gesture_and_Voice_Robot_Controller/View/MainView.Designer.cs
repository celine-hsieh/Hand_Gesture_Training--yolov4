namespace Gesture_and_Voice_Robot_Controller
{
    partial class MainView
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.BtnInitial = new System.Windows.Forms.Button();
            this.BtnServoOn = new System.Windows.Forms.Button();
            this.BtnServoOff = new System.Windows.Forms.Button();
            this.MainPnl = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button_Home = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BtnLoad
            // 
            this.BtnLoad.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLoad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnLoad.Location = new System.Drawing.Point(9, 10);
            this.BtnLoad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(115, 42);
            this.BtnLoad.TabIndex = 0;
            this.BtnLoad.Text = "Load";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // BtnInitial
            // 
            this.BtnInitial.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInitial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnInitial.Location = new System.Drawing.Point(137, 10);
            this.BtnInitial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnInitial.Name = "BtnInitial";
            this.BtnInitial.Size = new System.Drawing.Size(115, 42);
            this.BtnInitial.TabIndex = 1;
            this.BtnInitial.Text = "Initial";
            this.BtnInitial.UseVisualStyleBackColor = true;
            this.BtnInitial.Click += new System.EventHandler(this.BtnInitial_Click);
            // 
            // BtnServoOn
            // 
            this.BtnServoOn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnServoOn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnServoOn.Location = new System.Drawing.Point(9, 74);
            this.BtnServoOn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnServoOn.Name = "BtnServoOn";
            this.BtnServoOn.Size = new System.Drawing.Size(115, 42);
            this.BtnServoOn.TabIndex = 2;
            this.BtnServoOn.Text = "Servo On";
            this.BtnServoOn.UseVisualStyleBackColor = true;
            this.BtnServoOn.Click += new System.EventHandler(this.BtnServoOn_Click);
            // 
            // BtnServoOff
            // 
            this.BtnServoOff.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnServoOff.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnServoOff.Location = new System.Drawing.Point(137, 74);
            this.BtnServoOff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnServoOff.Name = "BtnServoOff";
            this.BtnServoOff.Size = new System.Drawing.Size(115, 42);
            this.BtnServoOff.TabIndex = 3;
            this.BtnServoOff.Text = "Servo Off";
            this.BtnServoOff.UseVisualStyleBackColor = true;
            this.BtnServoOff.Click += new System.EventHandler(this.BtnServoOff_Click);
            // 
            // MainPnl
            // 
            this.MainPnl.Location = new System.Drawing.Point(264, 10);
            this.MainPnl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MainPnl.Name = "MainPnl";
            this.MainPnl.Size = new System.Drawing.Size(562, 480);
            this.MainPnl.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(10, 224);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 68);
            this.button1.TabIndex = 5;
            this.button1.Text = "Gesture and Speech Control Mode";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(10, 140);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(242, 68);
            this.button3.TabIndex = 7;
            this.button3.Text = "Manual Control Mode";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button_Home
            // 
            this.button_Home.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Home.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Home.Location = new System.Drawing.Point(9, 305);
            this.button_Home.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Home.Name = "button_Home";
            this.button_Home.Size = new System.Drawing.Size(116, 59);
            this.button_Home.TabIndex = 0;
            this.button_Home.Text = "Home";
            this.button_Home.UseVisualStyleBackColor = true;
            this.button_Home.Click += new System.EventHandler(this.Button_Home_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Stop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Stop.Location = new System.Drawing.Point(135, 305);
            this.button_Stop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(117, 59);
            this.button_Stop.TabIndex = 43;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("PMingLiU", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(12, 389);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(240, 74);
            this.button2.TabIndex = 44;
            this.button2.Text = "材料點/目的點設定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 496);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Home);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MainPnl);
            this.Controls.Add(this.BtnServoOff);
            this.Controls.Add(this.BtnServoOn);
            this.Controls.Add(this.BtnInitial);
            this.Controls.Add(this.BtnLoad);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainView";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.Button BtnInitial;
        private System.Windows.Forms.Button BtnServoOn;
        private System.Windows.Forms.Button BtnServoOff;
        private System.Windows.Forms.Panel MainPnl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button_Home;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button2;
    }
}

