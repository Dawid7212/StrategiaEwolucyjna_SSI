namespace StrategiaEwolucyjna_SSI
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
            PB1 = new PictureBox();
            RTB1 = new RichTextBox();
            BTN1 = new Button();
            ((System.ComponentModel.ISupportInitialize)PB1).BeginInit();
            SuspendLayout();
            // 
            // PB1
            // 
            PB1.BackColor = SystemColors.ControlLightLight;
            PB1.Location = new Point(14, 20);
            PB1.Name = "PB1";
            PB1.Size = new Size(488, 405);
            PB1.TabIndex = 0;
            PB1.TabStop = false;
            // 
            // RTB1
            // 
            RTB1.Location = new Point(527, 27);
            RTB1.Name = "RTB1";
            RTB1.Size = new Size(232, 298);
            RTB1.TabIndex = 1;
            RTB1.Text = "";
            // 
            // BTN1
            // 
            BTN1.Location = new Point(527, 377);
            BTN1.Name = "BTN1";
            BTN1.Size = new Size(75, 23);
            BTN1.TabIndex = 2;
            BTN1.Text = "Start";
            BTN1.UseVisualStyleBackColor = true;
            BTN1.Click += BTN1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BTN1);
            Controls.Add(RTB1);
            Controls.Add(PB1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PB1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PB1;
        private RichTextBox RTB1;
        private Button BTN1;
    }
}
