namespace Lab5
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsPngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAstxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineWithCirclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolBtn1 = new System.Windows.Forms.ToolStripButton();
            this.toolBtn2 = new System.Windows.Forms.ToolStripButton();
            this.OpenBtn = new System.Windows.Forms.ToolStripButton();
            this.toolBtn3 = new System.Windows.Forms.ToolStripButton();
            this.toolBtn4 = new System.Windows.Forms.ToolStripButton();
            this.toolBtn5 = new System.Windows.Forms.ToolStripButton();
            this.toolBtn6 = new System.Windows.Forms.ToolStripButton();
            this.drawLineBtn = new System.Windows.Forms.ToolStripButton();
            this.drawCubeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolBtn7 = new System.Windows.Forms.ToolStripButton();
            this.DialogBtn = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.ToolStripMenu,
            this.listToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1042, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.printToolStripMenuItem,
            this.OpenFileBtn,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 34);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsPngToolStripMenuItem,
            this.saveAstxtToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsPngToolStripMenuItem
            // 
            this.saveAsPngToolStripMenuItem.Name = "saveAsPngToolStripMenuItem";
            this.saveAsPngToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveAsPngToolStripMenuItem.Text = "Save as png";
            this.saveAsPngToolStripMenuItem.Click += new System.EventHandler(this.saveAsPngToolStripMenuItem_Click);
            // 
            // saveAstxtToolStripMenuItem
            // 
            this.saveAstxtToolStripMenuItem.Name = "saveAstxtToolStripMenuItem";
            this.saveAstxtToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveAstxtToolStripMenuItem.Text = "Save as .txt";
            this.saveAstxtToolStripMenuItem.Click += new System.EventHandler(this.saveAstxtToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // OpenFileBtn
            // 
            this.OpenFileBtn.Name = "OpenFileBtn";
            this.OpenFileBtn.Size = new System.Drawing.Size(224, 26);
            this.OpenFileBtn.Text = "Open File";
            this.OpenFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ToolStripMenu
            // 
            this.ToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.rectangleToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.lineWithCirclesToolStripMenuItem,
            this.cubeToolStripMenuItem});
            this.ToolStripMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ToolStripMenu.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.ToolStripMenu.Name = "ToolStripMenu";
            this.ToolStripMenu.Size = new System.Drawing.Size(73, 24);
            this.ToolStripMenu.Text = "Objects";
            // 
            // pointToolStripMenuItem
            // 
            this.pointToolStripMenuItem.Name = "pointToolStripMenuItem";
            this.pointToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.pointToolStripMenuItem.Text = "Point";
            this.pointToolStripMenuItem.Click += new System.EventHandler(this.pointToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.rectangleToolStripMenuItem_Click);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.ellipseToolStripMenuItem.Text = "Ellipse";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.ellipseToolStripMenuItem_Click);
            // 
            // lineWithCirclesToolStripMenuItem
            // 
            this.lineWithCirclesToolStripMenuItem.Name = "lineWithCirclesToolStripMenuItem";
            this.lineWithCirclesToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.lineWithCirclesToolStripMenuItem.Text = "Line with circles";
            this.lineWithCirclesToolStripMenuItem.Click += new System.EventHandler(this.lineWithCirclesToolStripMenuItem_Click);
            // 
            // cubeToolStripMenuItem
            // 
            this.cubeToolStripMenuItem.Name = "cubeToolStripMenuItem";
            this.cubeToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.cubeToolStripMenuItem.Text = "Cube";
            this.cubeToolStripMenuItem.Click += new System.EventHandler(this.cubeToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(45, 34);
            this.listToolStripMenuItem.Text = "List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(49, 34);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtn1,
            this.toolBtn2,
            this.OpenBtn,
            this.toolBtn3,
            this.toolBtn4,
            this.toolBtn5,
            this.toolBtn6,
            this.drawLineBtn,
            this.drawCubeBtn,
            this.toolBtn7,
            this.DialogBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 38);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1042, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolBtn1
            // 
            this.toolBtn1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtn1.Image = global::WindowsFormsApp1.Resource1.save_file_bmp;
            this.toolBtn1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtn1.Name = "toolBtn1";
            this.toolBtn1.Size = new System.Drawing.Size(29, 24);
            this.toolBtn1.Text = "Save as png";
            // 
            // toolBtn2
            // 
            this.toolBtn2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtn2.Image = global::WindowsFormsApp1.Resource1.print_file_bmp;
            this.toolBtn2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtn2.Name = "toolBtn2";
            this.toolBtn2.Size = new System.Drawing.Size(29, 24);
            this.toolBtn2.Text = "Print current";
            // 
            // OpenBtn
            // 
            this.OpenBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenBtn.Image = global::WindowsFormsApp1.Resource1.open_file_bmp;
            this.OpenBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(29, 24);
            this.OpenBtn.Text = "Open File";
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // toolBtn3
            // 
            this.toolBtn3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtn3.Image = global::WindowsFormsApp1.Resource1.point_bmp;
            this.toolBtn3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtn3.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolBtn3.Name = "toolBtn3";
            this.toolBtn3.Size = new System.Drawing.Size(29, 24);
            this.toolBtn3.Text = "Draw Point";
            // 
            // toolBtn4
            // 
            this.toolBtn4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtn4.Image = global::WindowsFormsApp1.Resource1.line_bmp;
            this.toolBtn4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtn4.Name = "toolBtn4";
            this.toolBtn4.Size = new System.Drawing.Size(29, 24);
            this.toolBtn4.Text = "Draw Line";
            // 
            // toolBtn5
            // 
            this.toolBtn5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtn5.Image = global::WindowsFormsApp1.Resource1.rectangle_bmp;
            this.toolBtn5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtn5.Name = "toolBtn5";
            this.toolBtn5.Size = new System.Drawing.Size(29, 24);
            this.toolBtn5.Text = "Draw Rectangle";
            // 
            // toolBtn6
            // 
            this.toolBtn6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtn6.Image = ((System.Drawing.Image)(resources.GetObject("toolBtn6.Image")));
            this.toolBtn6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtn6.Name = "toolBtn6";
            this.toolBtn6.Size = new System.Drawing.Size(29, 24);
            this.toolBtn6.Text = "Draw Ellipse";
            // 
            // drawLineBtn
            // 
            this.drawLineBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawLineBtn.Image = global::WindowsFormsApp1.Resource1.lineoo_bmp;
            this.drawLineBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawLineBtn.Name = "drawLineBtn";
            this.drawLineBtn.Size = new System.Drawing.Size(29, 24);
            this.drawLineBtn.Text = "Draw Line with circles";
            // 
            // drawCubeBtn
            // 
            this.drawCubeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawCubeBtn.Image = global::WindowsFormsApp1.Resource1.cube_bmp;
            this.drawCubeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawCubeBtn.Name = "drawCubeBtn";
            this.drawCubeBtn.Size = new System.Drawing.Size(29, 24);
            this.drawCubeBtn.Text = "Draw Cube";
            // 
            // toolBtn7
            // 
            this.toolBtn7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtn7.Image = global::WindowsFormsApp1.Resource1.rubber_bmp;
            this.toolBtn7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtn7.Name = "toolBtn7";
            this.toolBtn7.Size = new System.Drawing.Size(29, 24);
            this.toolBtn7.Text = "Delete all";
            this.toolBtn7.Click += new System.EventHandler(this.toolBtn7_Click);
            // 
            // DialogBtn
            // 
            this.DialogBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DialogBtn.Image = global::WindowsFormsApp1.Properties.Resources.list_bmp;
            this.DialogBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DialogBtn.Name = "DialogBtn";
            this.DialogBtn.Size = new System.Drawing.Size(29, 24);
            this.DialogBtn.Text = "Objects List";
            this.DialogBtn.Click += new System.EventHandler(this.DialogBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1042, 653);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graphic Editor";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem pointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolBtn1;
        private System.Windows.Forms.ToolStripButton toolBtn2;
        private System.Windows.Forms.ToolStripButton toolBtn3;
        private System.Windows.Forms.ToolStripButton toolBtn4;
        private System.Windows.Forms.ToolStripButton toolBtn5;
        private System.Windows.Forms.ToolStripButton toolBtn6;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolBtn7;
        private System.Windows.Forms.ToolStripButton drawLineBtn;
        private System.Windows.Forms.ToolStripButton drawCubeBtn;
        private System.Windows.Forms.ToolStripMenuItem lineWithCirclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cubeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton DialogBtn;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton OpenBtn;
        private System.Windows.Forms.ToolStripMenuItem OpenFileBtn;
        private System.Windows.Forms.ToolStripMenuItem saveAsPngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAstxtToolStripMenuItem;
    }
}

