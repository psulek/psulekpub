﻿partial class FormInputBox
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInputBox));
		this.btnOk = new System.Windows.Forms.Button();
		this.btnCancel = new System.Windows.Forms.Button();
		this.lbMessage = new System.Windows.Forms.Label();
		this.edValue = new System.Windows.Forms.TextBox();
		this.lineControl1 = new LineControl();
		this.SuspendLayout();
		// 
		// btnOk
		// 
		this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOk.Location = new System.Drawing.Point(197, 70);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(75, 23);
		this.btnOk.TabIndex = 2;
		this.btnOk.Text = "&Ok";
		this.btnOk.UseVisualStyleBackColor = true;
		// 
		// btnCancel
		// 
		this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.Location = new System.Drawing.Point(278, 70);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(75, 23);
		this.btnCancel.TabIndex = 3;
		this.btnCancel.Text = "&Cancel";
		this.btnCancel.UseVisualStyleBackColor = true;
		// 
		// lbMessage
		// 
		this.lbMessage.AutoSize = true;
		this.lbMessage.Location = new System.Drawing.Point(16, 12);
		this.lbMessage.Name = "lbMessage";
		this.lbMessage.Size = new System.Drawing.Size(10, 13);
		this.lbMessage.TabIndex = 3;
		this.lbMessage.Text = "-";
		// 
		// edValue
		// 
		this.edValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
					| System.Windows.Forms.AnchorStyles.Right)));
		this.edValue.Location = new System.Drawing.Point(19, 28);
		this.edValue.Name = "edValue";
		this.edValue.Size = new System.Drawing.Size(320, 20);
		this.edValue.TabIndex = 0;
		// 
		// lineControl1
		// 
		this.lineControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.lineControl1.Location = new System.Drawing.Point(0, 59);
		this.lineControl1.Name = "lineControl1";
		this.lineControl1.Size = new System.Drawing.Size(364, 43);
		this.lineControl1.TabIndex = 1;
		this.lineControl1.Text = "lineControl1";
		// 
		// FormInputBox
		// 
		this.AcceptButton = this.btnOk;
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(364, 102);
		this.Controls.Add(this.edValue);
		this.Controls.Add(this.lbMessage);
		this.Controls.Add(this.btnCancel);
		this.Controls.Add(this.btnOk);
		this.Controls.Add(this.lineControl1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FormInputBox";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.ResumeLayout(false);
		this.PerformLayout();

	}

	#endregion

	private LineControl lineControl1;
	private System.Windows.Forms.Button btnOk;
	private System.Windows.Forms.Button btnCancel;
	private System.Windows.Forms.Label lbMessage;
	private System.Windows.Forms.TextBox edValue;
}