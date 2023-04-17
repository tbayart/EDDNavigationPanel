namespace PanelTester
{
    partial class NavigationPanelTester
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
            this._ucNavigationPanel = new EDDNavigationPanel.UCNavigationPanel();
            this._listView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // _ucNavigationPanel
            // 
            this._ucNavigationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ucNavigationPanel.Location = new System.Drawing.Point(0, 0);
            this._ucNavigationPanel.Name = "_ucNavigationPanel";
            this._ucNavigationPanel.Size = new System.Drawing.Size(643, 400);
            this._ucNavigationPanel.TabIndex = 0;
            // 
            // _listView
            // 
            this._listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._listView.HideSelection = false;
            this._listView.Location = new System.Drawing.Point(649, 0);
            this._listView.MultiSelect = false;
            this._listView.Name = "_listView";
            this._listView.Size = new System.Drawing.Size(150, 398);
            this._listView.TabIndex = 1;
            this._listView.UseCompatibleStateImageBehavior = false;
            this._listView.View = System.Windows.Forms.View.List;
            // 
            // NavigationPanelTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this._listView);
            this.Controls.Add(this._ucNavigationPanel);
            this.Name = "NavigationPanelTester";
            this.Text = "NavigationPanelTester";
            this.ResumeLayout(false);

        }

        #endregion
        private EDDNavigationPanel.UCNavigationPanel _ucNavigationPanel;
        private System.Windows.Forms.ListView _listView;
    }
}