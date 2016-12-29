using System.Windows.Forms;

namespace GraphicEditor
{
	partial class GraphicEditor
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.ReturnButton = new System.Windows.Forms.Button();
			this.CancellationButton = new System.Windows.Forms.Button();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.RelocateButton = new System.Windows.Forms.Button();
			this.Picture = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.ReturnButton);
			this.panel1.Controls.Add(this.CancellationButton);
			this.panel1.Controls.Add(this.DeleteButton);
			this.panel1.Controls.Add(this.RelocateButton);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(108, 172);
			this.panel1.TabIndex = 0;
			// 
			// ReturnButton
			// 
			this.ReturnButton.Location = new System.Drawing.Point(53, 115);
			this.ReturnButton.Name = "ReturnButton";
			this.ReturnButton.Size = new System.Drawing.Size(50, 50);
			this.ReturnButton.TabIndex = 4;
			this.ReturnButton.Text = "Return";
			this.ReturnButton.UseVisualStyleBackColor = true;
			ReturnButton.Click += new System.EventHandler(ReturnButtonClick);
			// 
			// CancellationButton
			// 
			this.CancellationButton.Location = new System.Drawing.Point(3, 115);
			this.CancellationButton.Name = "CancellationButton";
			this.CancellationButton.Size = new System.Drawing.Size(50, 50);
			this.CancellationButton.TabIndex = 3;
			this.CancellationButton.Text = "Cancel";
			this.CancellationButton.UseVisualStyleBackColor = true;
			CancellationButton.Click += new System.EventHandler(CancellationButtonClick);
			// 
			// DeleteButton
			// 
			this.DeleteButton.Location = new System.Drawing.Point(3, 59);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(100, 50);
			this.DeleteButton.TabIndex = 2;
			this.DeleteButton.Text = "Delete line";
			this.DeleteButton.UseVisualStyleBackColor = true;
			DeleteButton.Click += new System.EventHandler(DeleteButtonClick);
			// 
			// RelocateButton
			// 
			this.RelocateButton.Location = new System.Drawing.Point(3, 3);
			this.RelocateButton.Name = "RelocateButton";
			this.RelocateButton.Size = new System.Drawing.Size(100, 50);
			this.RelocateButton.TabIndex = 1;
			this.RelocateButton.Text = "Relocate line";
			this.RelocateButton.UseVisualStyleBackColor = true;
			RelocateButton.Click += new System.EventHandler(RelocateButtonClick);
			// 
			// Picture
			// 
			this.Picture.BackColor = System.Drawing.Color.White;
			this.Picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Picture.Location = new System.Drawing.Point(126, 12);
			this.Picture.Name = "Picture";
			this.Picture.Size = new System.Drawing.Size(650, 530);
			this.Picture.TabIndex = 1;
			this.Picture.TabStop = false;
			this.Picture.Paint += new PaintEventHandler(this.Draw);
			this.Picture.MouseClick += new MouseEventHandler(this.MouseClicked);
			this.Picture.MouseMove += new MouseEventHandler(this.MouseMoved);
			// 
			// GraphicEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.Picture);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GraphicEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Graphic Editor";
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox Picture;
		private System.Windows.Forms.Button ReturnButton;
		private System.Windows.Forms.Button CancellationButton;
		private System.Windows.Forms.Button DeleteButton;
		private System.Windows.Forms.Button RelocateButton;
	}
}