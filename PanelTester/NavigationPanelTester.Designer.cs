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
            this.ucNavigationPanel = new EDDNavigationPanel.UCNavigationPanel();
            this.listView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // ucNavigationPanel
            // 
            this.ucNavigationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucNavigationPanel.Location = new System.Drawing.Point(0, 0);
            this.ucNavigationPanel.Name = "ucNavigationPanel";
            this.ucNavigationPanel.Size = new System.Drawing.Size(643, 400);
            this.ucNavigationPanel.TabIndex = 0;
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(649, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(150, 398);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.List;
            // 
            // NavigationPanelTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.ucNavigationPanel);
            this.Name = "NavigationPanelTester";
            this.Text = "NavigationPanelTester";
            this.ResumeLayout(false);

        }

        #endregion
        private EDDNavigationPanel.UCNavigationPanel ucNavigationPanel;
        private System.Windows.Forms.ListView listView;
    }
}