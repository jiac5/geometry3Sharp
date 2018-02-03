#define USE_VTK
namespace GeometryProcessing {
    partial class FormGeometryProcessing {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplacianSmoothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qualityStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.processToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1022, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.laplacianSmoothToolStripMenuItem,
            this.qualityStatisticsToolStripMenuItem});
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.processToolStripMenuItem.Text = "Process";
            // 
            // laplacianSmoothToolStripMenuItem
            // 
            this.laplacianSmoothToolStripMenuItem.Name = "laplacianSmoothToolStripMenuItem";
            this.laplacianSmoothToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.laplacianSmoothToolStripMenuItem.Text = "Laplacian Smooth";
            this.laplacianSmoothToolStripMenuItem.Click += new System.EventHandler(this.laplacianSmoothToolStripMenuItem_Click);
            // 
            // qualityStatisticsToolStripMenuItem
            // 
            this.qualityStatisticsToolStripMenuItem.Name = "qualityStatisticsToolStripMenuItem";
            this.qualityStatisticsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.qualityStatisticsToolStripMenuItem.Text = "Quality Statistics";
            this.qualityStatisticsToolStripMenuItem.Click += new System.EventHandler(this.qualityStatisticsToolStripMenuItem_Click);
#if USE_VTK
            InitializeRenderWindow();
#endif
            // 
            // FormGeometryProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 811);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGeometryProcessing";
            this.Text = "GeometryProcessing";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



#endregion
        private void InitializeRenderWindow() {
            this.renderWindowControl = new Kitware.VTK.RenderWindowControl();
            this.renderWindowControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderWindowControl.AddTestActors = false;
            this.renderWindowControl.Location = new System.Drawing.Point(3, 3);
            this.renderWindowControl.Name = "renderWindowControl1";
            this.renderWindowControl.Size = new System.Drawing.Size(600, 400);
            this.renderWindowControl.TabIndex = 0;
            this.renderWindowControl.TestText = null;
            this.Controls.Add(this.renderWindowControl);
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplacianSmoothToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qualityStatisticsToolStripMenuItem;
#if USE_VTK
        private Kitware.VTK.RenderWindowControl renderWindowControl;
#endif
    }
}

