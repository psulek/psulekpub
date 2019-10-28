using System;
using System.Windows.Forms;

namespace TXSoftware.DataObjectsNetEntityModel.Common.UIEditors.Forms
{
    public partial class FlagsEditorControl
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlagsEditorControl));
            this.lvwItems = new System.Windows.Forms.CheckedListBox();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.bottomMenu = new System.Windows.Forms.ToolStrip();
            this.btnReset = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnOk = new System.Windows.Forms.ToolStripButton();
            this.bottomMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwItems
            // 
            this.lvwItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwItems.FormattingEnabled = true;
            this.lvwItems.IntegralHeight = false;
            this.lvwItems.Location = new System.Drawing.Point(0, 0);
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.Size = new System.Drawing.Size(150, 125);
            this.lvwItems.TabIndex = 0;
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Fuchsia;
            this.images.Images.SetKeyName(0, "refresh_16.png");
            this.images.Images.SetKeyName(1, "cancel_16.png");
            this.images.Images.SetKeyName(2, "confirm_16.png");
            // 
            // bottomMenu
            // 
            this.bottomMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bottomMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReset,
            this.btnCancel,
            this.btnOk});
            this.bottomMenu.Location = new System.Drawing.Point(0, 125);
            this.bottomMenu.Name = "bottomMenu";
            this.bottomMenu.Size = new System.Drawing.Size(150, 25);
            this.bottomMenu.TabIndex = 1;
            // 
            // buttonReset
            // 
            this.btnReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReset.Name = "buttonReset";
            this.btnReset.Size = new System.Drawing.Size(23, 22);
            this.btnReset.Text = "Reset Value";
            this.btnReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // cancelButton
            // 
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancel.Name = "cancelButton";
            this.btnCancel.Size = new System.Drawing.Size(23, 22);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okeyButton
            // 
            this.btnOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOk.Name = "okeyButton";
            this.btnOk.Size = new System.Drawing.Size(23, 22);
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.okeyButton_Click);
            // 
            // FlagsEditorControl
            // 
            this.Controls.Add(this.lvwItems);
            this.Controls.Add(this.bottomMenu);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "FlagsEditorControl";
            this.bottomMenu.ResumeLayout(false);
            this.bottomMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private CheckedListBox lvwItems;
        private ToolStrip bottomMenu;
        private ToolStripButton btnReset;
        private ToolStripButton btnCancel;
        private ToolStripButton btnOk;
        private ImageList images;
    }
}