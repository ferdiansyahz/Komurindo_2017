namespace WindowsFormsApplication3
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.DOOM = new System.Windows.Forms.MenuStrip();
            this.RPY = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.DOOM.SuspendLayout();
            this.SuspendLayout();
            // 
            // DOOM
            // 
            this.DOOM.BackgroundImage = global::WindowsFormsApplication3.Properties.Resources.rsz_bhgy;
            this.DOOM.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.DOOM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RPY,
            this.toolStripMenuItem2});
            this.DOOM.Location = new System.Drawing.Point(0, 0);
            this.DOOM.Name = "DOOM";
            this.DOOM.Size = new System.Drawing.Size(1284, 24);
            this.DOOM.TabIndex = 0;
            this.DOOM.Text = "DOOM";
            // 
            // RPY
            // 
            this.RPY.BackgroundImage = global::WindowsFormsApplication3.Properties.Resources.guagebg;
            this.RPY.Name = "RPY";
            this.RPY.Size = new System.Drawing.Size(74, 20);
            this.RPY.Text = "RPY DATA";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(125, 20);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 642);
            this.Controls.Add(this.DOOM);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.DOOM;
            this.Name = "Form2";
            this.Text = "GroundFak";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.DOOM.ResumeLayout(false);
            this.DOOM.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.MenuStrip DOOM;
        private System.Windows.Forms.ToolStripMenuItem RPY;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}