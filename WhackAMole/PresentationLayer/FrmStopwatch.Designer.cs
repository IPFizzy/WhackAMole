namespace WhackAMole
{
    partial class FrmStopwatch
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
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            btnStop = new Button();
            btnReset = new Button();
            lblTimeElapsed = new Label();
            tmrStopwatch = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(108, 144);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += BtnStartClickEH;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(108, 192);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += BtnStopClickEH;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(108, 240);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 2;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += BtnResetClickEH;
            // 
            // lblTimeElapsed
            // 
            lblTimeElapsed.AutoSize = true;
            lblTimeElapsed.Location = new Point(107, 103);
            lblTimeElapsed.Name = "lblTimeElapsed";
            lblTimeElapsed.Size = new Size(77, 15);
            lblTimeElapsed.TabIndex = 3;
            lblTimeElapsed.Text = "Time Elapsed";
            // 
            // tmrStopwatch
            // 
            tmrStopwatch.Enabled = true;
            tmrStopwatch.Interval = 1000;
            tmrStopwatch.Tick += TmrStopwatchTickEH;
            // 
            // FrmStopwatch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 380);
            Controls.Add(lblTimeElapsed);
            Controls.Add(btnReset);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Name = "FrmStopwatch";
            Text = "Stopwatch";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Button btnReset;
        private Label lblTimeElapsed;
        private System.Windows.Forms.Timer tmrStopwatch;
    }
}
