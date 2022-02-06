namespace timetracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.timeSessionLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textSessionLabel = new System.Windows.Forms.Label();
            this.timeTotalLabel = new System.Windows.Forms.Label();
            this.textTotalLabel = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolOpenButton = new System.Windows.Forms.ToolStripButton();
            this.toolCreateButton = new System.Windows.Forms.ToolStripButton();
            this.toolExportButton = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.projectLabel = new System.Windows.Forms.Label();
            this.textTodayLabel = new System.Windows.Forms.Label();
            this.timeTodayLabel = new System.Windows.Forms.Label();
            this.timerIdle = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.startButton.Enabled = false;
            this.startButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.startButton.ForeColor = System.Drawing.Color.Gray;
            this.startButton.Location = new System.Drawing.Point(72, 144);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 43);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.EnabledChanged += new System.EventHandler(this.startButton_enabledChanged);
            this.startButton.Click += new System.EventHandler(this.startButton_click);
            this.startButton.Paint += new System.Windows.Forms.PaintEventHandler(this.startButton_paint);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.DarkSalmon;
            this.stopButton.Enabled = false;
            this.stopButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.stopButton.ForeColor = System.Drawing.Color.Gray;
            this.stopButton.Location = new System.Drawing.Point(216, 144);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(100, 43);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Pause";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.EnabledChanged += new System.EventHandler(this.stopButton_enabledChanged);
            this.stopButton.Click += new System.EventHandler(this.stopButton_click);
            this.stopButton.Paint += new System.Windows.Forms.PaintEventHandler(this.stopButton_paint);
            // 
            // timeSessionLabel
            // 
            this.timeSessionLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.timeSessionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeSessionLabel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeSessionLabel.Location = new System.Drawing.Point(216, 220);
            this.timeSessionLabel.Name = "timeSessionLabel";
            this.timeSessionLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.timeSessionLabel.Size = new System.Drawing.Size(152, 48);
            this.timeSessionLabel.TabIndex = 2;
            this.timeSessionLabel.Text = "00:00";
            this.timeSessionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textSessionLabel
            // 
            this.textSessionLabel.AutoSize = true;
            this.textSessionLabel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textSessionLabel.Location = new System.Drawing.Point(12, 224);
            this.textSessionLabel.Name = "textSessionLabel";
            this.textSessionLabel.Size = new System.Drawing.Size(125, 41);
            this.textSessionLabel.TabIndex = 3;
            this.textSessionLabel.Text = "Session:";
            // 
            // timeTotalLabel
            // 
            this.timeTotalLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.timeTotalLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeTotalLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeTotalLabel.Location = new System.Drawing.Point(216, 343);
            this.timeTotalLabel.Name = "timeTotalLabel";
            this.timeTotalLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.timeTotalLabel.Size = new System.Drawing.Size(152, 38);
            this.timeTotalLabel.TabIndex = 4;
            this.timeTotalLabel.Text = "00:00";
            this.timeTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textTotalLabel
            // 
            this.textTotalLabel.AutoSize = true;
            this.textTotalLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textTotalLabel.Location = new System.Drawing.Point(16, 347);
            this.textTotalLabel.Name = "textTotalLabel";
            this.textTotalLabel.Size = new System.Drawing.Size(63, 30);
            this.textTotalLabel.TabIndex = 5;
            this.textTotalLabel.Text = "Total:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpenButton,
            this.toolCreateButton,
            this.toolExportButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(380, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolOpenButton
            // 
            this.toolOpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolOpenButton.Image = ((System.Drawing.Image)(resources.GetObject("toolOpenButton.Image")));
            this.toolOpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOpenButton.Name = "toolOpenButton";
            this.toolOpenButton.Size = new System.Drawing.Size(23, 22);
            this.toolOpenButton.Text = "Open project";
            this.toolOpenButton.Click += new System.EventHandler(this.toolOpenButton_Click);
            // 
            // toolCreateButton
            // 
            this.toolCreateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCreateButton.Image = ((System.Drawing.Image)(resources.GetObject("toolCreateButton.Image")));
            this.toolCreateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCreateButton.Name = "toolCreateButton";
            this.toolCreateButton.Size = new System.Drawing.Size(23, 22);
            this.toolCreateButton.Text = "Create project";
            this.toolCreateButton.Click += new System.EventHandler(this.toolCreateButton_click);
            // 
            // toolExportButton
            // 
            this.toolExportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolExportButton.Enabled = false;
            this.toolExportButton.Image = ((System.Drawing.Image)(resources.GetObject("toolExportButton.Image")));
            this.toolExportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExportButton.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolExportButton.Name = "toolExportButton";
            this.toolExportButton.Size = new System.Drawing.Size(23, 22);
            this.toolExportButton.Text = "Export project";
            this.toolExportButton.Click += new System.EventHandler(this.toolExportButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // projectLabel
            // 
            this.projectLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.projectLabel.Location = new System.Drawing.Point(12, 40);
            this.projectLabel.Name = "projectLabel";
            this.projectLabel.Size = new System.Drawing.Size(349, 85);
            this.projectLabel.TabIndex = 8;
            this.projectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textTodayLabel
            // 
            this.textTodayLabel.AutoSize = true;
            this.textTodayLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textTodayLabel.Location = new System.Drawing.Point(14, 288);
            this.textTodayLabel.Name = "textTodayLabel";
            this.textTodayLabel.Size = new System.Drawing.Size(86, 36);
            this.textTodayLabel.TabIndex = 9;
            this.textTodayLabel.Text = "Today:";
            // 
            // timeTodayLabel
            // 
            this.timeTodayLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.timeTodayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeTodayLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeTodayLabel.Location = new System.Drawing.Point(216, 284);
            this.timeTodayLabel.Name = "timeTodayLabel";
            this.timeTodayLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.timeTodayLabel.Size = new System.Drawing.Size(152, 42);
            this.timeTodayLabel.TabIndex = 10;
            this.timeTodayLabel.Text = "00:00";
            this.timeTodayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerIdle
            // 
            this.timerIdle.Interval = 1000;
            this.timerIdle.Tick += new System.EventHandler(this.timerIdle_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(380, 392);
            this.Controls.Add(this.timeTodayLabel);
            this.Controls.Add(this.textTodayLabel);
            this.Controls.Add(this.projectLabel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.textTotalLabel);
            this.Controls.Add(this.timeTotalLabel);
            this.Controls.Add(this.textSessionLabel);
            this.Controls.Add(this.timeSessionLabel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Time Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startButton;
        private Button stopButton;
        private Label timeSessionLabel;
        private System.Windows.Forms.Timer timer1;
        private Label textSessionLabel;
        private Label timeTotalLabel;
        private Label textTotalLabel;
        private Label projectLabel;
        private ToolStrip toolStrip1;
        private ToolStripButton toolCreateButton;
        private ToolStripButton toolOpenButton;
        private OpenFileDialog openFileDialog1;
        private Label textTodayLabel;
        private Label timeTodayLabel;
        private System.Windows.Forms.Timer timerIdle;
        private ToolStripButton toolExportButton;
    }
}