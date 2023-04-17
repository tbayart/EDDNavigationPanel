namespace EDDNavigationPanel
{
    partial class UCNavigationPanel
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
            this._elementHost = new System.Windows.Forms.Integration.ElementHost();
            this._ucContentControl = new EDDNavigationPanel.UserControls.UCContentControl();
            this.SuspendLayout();
            // 
            // _elementHost
            // 
            this._elementHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._elementHost.Location = new System.Drawing.Point(0, 0);
            this._elementHost.Name = "_elementHost";
            this._elementHost.Size = new System.Drawing.Size(800, 400);
            this._elementHost.TabIndex = 2;
            this._elementHost.Text = "elementHost";
            this._elementHost.Child = this._ucContentControl;
            // 
            // UCNavigationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._elementHost);
            this.Name = "UCNavigationPanel";
            this.Size = new System.Drawing.Size(800, 400);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Integration.ElementHost _elementHost;
        private UserControls.UCContentControl _ucContentControl;
    }
}
