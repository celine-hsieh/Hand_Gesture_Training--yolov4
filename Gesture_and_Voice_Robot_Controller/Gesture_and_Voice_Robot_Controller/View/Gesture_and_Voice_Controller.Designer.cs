namespace Gesture_and_Voice_Robot_Controller.View
{
    partial class Gesture_and_Voice_Controller
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelMotionMode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSpeechRec = new System.Windows.Forms.Button();
            this.btnGestureRec = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelSpeech = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelLeftHand = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelRightHand = new System.Windows.Forms.Label();
            this.TextBox_Guide = new System.Windows.Forms.RichTextBox();
            this.timerUpdateLabel = new System.Windows.Forms.Timer(this.components);
            this.btnSimulation = new System.Windows.Forms.Button();
            this.btnOperation = new System.Windows.Forms.Button();
            this.dgv_Path = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Path)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeed.Location = new System.Drawing.Point(191, 355);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(34, 37);
            this.labelSpeed.TabIndex = 33;
            this.labelSpeed.Text = "0";
            this.labelSpeed.Visible = false;
            // 
            // labelMotionMode
            // 
            this.labelMotionMode.AutoSize = true;
            this.labelMotionMode.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMotionMode.Location = new System.Drawing.Point(215, 314);
            this.labelMotionMode.Name = "labelMotionMode";
            this.labelMotionMode.Size = new System.Drawing.Size(0, 37);
            this.labelMotionMode.TabIndex = 46;
            this.labelMotionMode.TextChanged += new System.EventHandler(this.LabelMotionMode_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 37);
            this.label2.TabIndex = 45;
            this.label2.Text = "Motion:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 37);
            this.label1.TabIndex = 44;
            this.label1.Text = "Speed:";
            this.label1.Visible = false;
            // 
            // BtnSpeechRec
            // 
            this.BtnSpeechRec.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BtnSpeechRec.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSpeechRec.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnSpeechRec.Location = new System.Drawing.Point(31, 8);
            this.BtnSpeechRec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSpeechRec.Name = "BtnSpeechRec";
            this.BtnSpeechRec.Size = new System.Drawing.Size(153, 52);
            this.BtnSpeechRec.TabIndex = 47;
            this.BtnSpeechRec.Text = "Speech Recognition";
            this.BtnSpeechRec.UseVisualStyleBackColor = false;
            this.BtnSpeechRec.Click += new System.EventHandler(this.BtnSpeechRec_Click);
            // 
            // btnGestureRec
            // 
            this.btnGestureRec.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestureRec.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGestureRec.Location = new System.Drawing.Point(31, 87);
            this.btnGestureRec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGestureRec.Name = "btnGestureRec";
            this.btnGestureRec.Size = new System.Drawing.Size(153, 52);
            this.btnGestureRec.TabIndex = 48;
            this.btnGestureRec.Text = "Hand Gesture Recognition";
            this.btnGestureRec.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(190, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 27);
            this.label3.TabIndex = 51;
            this.label3.Text = "Speech Command:";
            // 
            // labelSpeech
            // 
            this.labelSpeech.AutoSize = true;
            this.labelSpeech.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeech.Location = new System.Drawing.Point(408, 20);
            this.labelSpeech.Name = "labelSpeech";
            this.labelSpeech.Size = new System.Drawing.Size(0, 27);
            this.labelSpeech.TabIndex = 50;
            this.labelSpeech.TextChanged += new System.EventHandler(this.LabelSpeech_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(193, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 27);
            this.label5.TabIndex = 53;
            this.label5.Text = "Left:";
            // 
            // labelLeftHand
            // 
            this.labelLeftHand.AutoSize = true;
            this.labelLeftHand.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLeftHand.Location = new System.Drawing.Point(325, 99);
            this.labelLeftHand.Name = "labelLeftHand";
            this.labelLeftHand.Size = new System.Drawing.Size(0, 27);
            this.labelLeftHand.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(433, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 27);
            this.label7.TabIndex = 55;
            this.label7.Text = "Right:";
            // 
            // labelRightHand
            // 
            this.labelRightHand.AutoSize = true;
            this.labelRightHand.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRightHand.Location = new System.Drawing.Point(550, 99);
            this.labelRightHand.Name = "labelRightHand";
            this.labelRightHand.Size = new System.Drawing.Size(0, 27);
            this.labelRightHand.TabIndex = 54;
            // 
            // TextBox_Guide
            // 
            this.TextBox_Guide.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TextBox_Guide.Location = new System.Drawing.Point(31, 233);
            this.TextBox_Guide.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox_Guide.Name = "TextBox_Guide";
            this.TextBox_Guide.Size = new System.Drawing.Size(688, 70);
            this.TextBox_Guide.TabIndex = 56;
            this.TextBox_Guide.Text = "";
            // 
            // timerUpdateLabel
            // 
            this.timerUpdateLabel.Tick += new System.EventHandler(this.TimerUpdateLabel_Tick);
            // 
            // btnSimulation
            // 
            this.btnSimulation.Enabled = false;
            this.btnSimulation.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimulation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSimulation.Location = new System.Drawing.Point(31, 165);
            this.btnSimulation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSimulation.Name = "btnSimulation";
            this.btnSimulation.Size = new System.Drawing.Size(153, 52);
            this.btnSimulation.TabIndex = 57;
            this.btnSimulation.Text = "Simulation";
            this.btnSimulation.UseVisualStyleBackColor = true;
            this.btnSimulation.Click += new System.EventHandler(this.Simulation_Switch);
            // 
            // btnOperation
            // 
            this.btnOperation.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOperation.Location = new System.Drawing.Point(208, 165);
            this.btnOperation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOperation.Name = "btnOperation";
            this.btnOperation.Size = new System.Drawing.Size(153, 52);
            this.btnOperation.TabIndex = 58;
            this.btnOperation.Text = "Operation";
            this.btnOperation.UseVisualStyleBackColor = true;
            this.btnOperation.Click += new System.EventHandler(this.Simulation_Switch);
            // 
            // dgv_Path
            // 
            this.dgv_Path.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Path.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgv_Path.Location = new System.Drawing.Point(31, 405);
            this.dgv_Path.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Path.Name = "dgv_Path";
            this.dgv_Path.RowHeadersWidth = 51;
            this.dgv_Path.RowTemplate.Height = 24;
            this.dgv_Path.Size = new System.Drawing.Size(688, 176);
            this.dgv_Path.TabIndex = 59;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Type";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "J1 || X";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "J2 || Y";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "J3 || Z";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "J4 || RX";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "J5 || RY";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "J6 || RZ";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "I/O";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            // 
            // Gesture_and_Voice_Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_Path);
            this.Controls.Add(this.btnOperation);
            this.Controls.Add(this.btnSimulation);
            this.Controls.Add(this.TextBox_Guide);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelRightHand);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelLeftHand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelSpeech);
            this.Controls.Add(this.btnGestureRec);
            this.Controls.Add(this.BtnSpeechRec);
            this.Controls.Add(this.labelMotionMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSpeed);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Gesture_and_Voice_Controller";
            this.Size = new System.Drawing.Size(749, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Path)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label labelMotionMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Button BtnSpeechRec;
        private System.Windows.Forms.Button btnGestureRec;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label labelSpeech;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label labelLeftHand;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label labelRightHand;
        private System.Windows.Forms.RichTextBox TextBox_Guide;
        private System.Windows.Forms.Timer timerUpdateLabel;
        private System.Windows.Forms.Button btnSimulation;
        private System.Windows.Forms.Button btnOperation;
        public System.Windows.Forms.DataGridView dgv_Path;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}
