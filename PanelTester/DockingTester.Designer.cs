namespace PanelTester
{
    partial class DockingTester
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
            this.ucNavigationPanel = new EDDNavigationPanel.UCNavigationPanel();
            this.labelPadNumber = new System.Windows.Forms.Label();
            this.padNumber = new System.Windows.Forms.NumericUpDown();
            this.stationType = new System.Windows.Forms.ComboBox();
            this.labelStationType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.padNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // ucDockingPanel
            // 
            this.ucNavigationPanel.Location = new System.Drawing.Point(0, 60);
            this.ucNavigationPanel.Name = "ucNavigationPanel";
            this.ucNavigationPanel.Size = new System.Drawing.Size(800, 400);
            this.ucNavigationPanel.TabIndex = 0;
            // 
            // labelPad
            // 
            this.labelPadNumber.AutoSize = true;
            this.labelPadNumber.Location = new System.Drawing.Point(12, 0);
            this.labelPadNumber.Name = "labelPadNamber";
            this.labelPadNumber.Size = new System.Drawing.Size(66, 13);
            this.labelPadNumber.TabIndex = 1;
            this.labelPadNumber.Text = "Pad Number";
            // 
            // padNumber
            // 
            this.padNumber.Location = new System.Drawing.Point(12, 16);
            this.padNumber.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.padNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.padNumber.Name = "padNumber";
            this.padNumber.Size = new System.Drawing.Size(120, 20);
            this.padNumber.TabIndex = 2;
            this.padNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.padNumber.ValueChanged += new System.EventHandler(this.padNumber_ValueChanged);
            // 
            // stationType
            // 
            this.stationType.FormattingEnabled = true;
            this.stationType.Location = new System.Drawing.Point(178, 16);
            this.stationType.Name = "stationType";
            this.stationType.Size = new System.Drawing.Size(121, 21);
            this.stationType.TabIndex = 3;
            this.stationType.SelectedIndexChanged += new System.EventHandler(this.stationType_SelectedIndexChanged);
            // 
            // labelStationType
            // 
            this.labelStationType.AutoSize = true;
            this.labelStationType.Location = new System.Drawing.Point(175, 0);
            this.labelStationType.Name = "labelStationType";
            this.labelStationType.Size = new System.Drawing.Size(67, 13);
            this.labelStationType.TabIndex = 4;
            this.labelStationType.Text = "Station Type";
            // 
            // DockingTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.labelStationType);
            this.Controls.Add(this.stationType);
            this.Controls.Add(this.padNumber);
            this.Controls.Add(this.labelPadNumber);
            this.Controls.Add(this.ucNavigationPanel);
            this.Name = "DockingTester";
            this.Text = "DockingTester";
            ((System.ComponentModel.ISupportInitialize)(this.padNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDDNavigationPanel.UCNavigationPanel ucNavigationPanel;
        private System.Windows.Forms.Label labelPadNumber;
        private System.Windows.Forms.NumericUpDown padNumber;
        private System.Windows.Forms.ComboBox stationType;
        private System.Windows.Forms.Label labelStationType;
    }
}

